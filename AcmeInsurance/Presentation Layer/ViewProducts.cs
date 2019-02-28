using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcmeInsurance.Presentation_Layer;
using AcmeInsurance.Business_Logic_Layer;
using AcmeInsurance.Data_Access_Layer;
using System.Data.SqlClient;

namespace AcmeInsurance
{
    public partial class frmViewProducts : Form
    {
        public frmViewProducts()
        {
            InitializeComponent();
        }

        private void frmViewProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Returns to main form upon clicking red cross in top right corner
            frmMainForm mainForm = new frmMainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Returns to main form upon clicking close button in bottom right corner
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Opens AddProduct form and ensures no record is currently selected
            GlobalVariables.selectedProductID = 0;
            frmAddProduct editForm = new frmAddProduct();
            editForm.ShowDialog();
            lvProducts.Items.Clear();
            DisplayProducts();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Checks user has selected a product
            if(lvProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Product to update.");
                return;
            }
            // Stores ProductID to be updated
            GlobalVariables.selectedProductID = int.Parse(lvProducts.SelectedItems[0].Text);

            // Opens AddProduct form
            frmAddProduct editForm = new frmAddProduct();
            editForm.ShowDialog();
            lvProducts.Items.Clear();
            DisplayProducts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Opens SearchProducts form
            GlobalVariables.productSearchCriteria = "";
            frmSearchProducts searchForm = new frmSearchProducts();
            searchForm.ShowDialog();
            lvProducts.Items.Clear();
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            // Define SQL statement to return record set
            string selectQuery;
            selectQuery = "SELECT Products.ProductID, ProductTypes.ProductType, ";
            selectQuery = selectQuery + "Products.ProductName, Products.YearlyPremium";
            selectQuery = selectQuery + " FROM Products INNER JOIN ";
            selectQuery = selectQuery + "ProductTypes ON Products.ProductTypeID = ProductTypes.ProductTypeID";
            selectQuery = selectQuery + " " + GlobalVariables.productSearchCriteria;

            // Connect to the database and define a reader to store the record set
            SqlConnection conn = ConnectionManager.DatabaseConnection();
            SqlDataReader rdr = null;

            try
            {
                // Open the connection to the database
                conn.Open();
                // Create SqlCommand object to pass string with SQL statement and the SqlConnection object
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                // Send the SQL query to the SqlConnection object
                rdr = cmd.ExecuteReader();

                // Loop through the record set and add each row to an instance of the Products class
                while (rdr.Read())
                {
                    Products product = new Products(int.Parse(rdr["ProductID"].ToString()),
                        rdr["ProductType"].ToString(), rdr["ProductName"].ToString(),
                        float.Parse(rdr["YearlyPremium"].ToString()));

                    ListViewItem lvi = new ListViewItem(product.ProductID.ToString());
                    lvi.SubItems.Add(product.ProductType);
                    lvi.SubItems.Add(product.ProductName);
                    lvi.SubItems.Add(product.YearlyPremium.ToString());
                    // Add information from database to ListViewItem on form
                    lvProducts.Items.Add(lvi);
                }

                // Close the reader once data has been read
                if (rdr != null)
                {
                    rdr.Close();
                }
                // Close the connection to the database
                conn.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show("Unsuccessful " + ex);
            }
        }

        private void frmViewProducts_Load(object sender, EventArgs e)
        {
            // Upon loading form, DisplayProducts method is called
            DisplayProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Checks user has selected a record to delete
            if (lvProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Product to delete.");
                return;
            }

            // Checks record is able to be deleted
            int selectedProductID = int.Parse(lvProducts.SelectedItems[0].Text);
            string deleteQuery = "sp_Products_AllowDeleteProduct";
            // Connect to the database
            SqlConnection conn = ConnectionManager.DatabaseConnection();

            // Open connection to the database
            conn.Open();
            //Create SqlCommand object to pass string with stored procedure and the SqlConnection object
            SqlCommand cmd = new SqlCommand(deleteQuery, conn);

            // Passing parameters to the stored procedure and executing procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", selectedProductID);
            cmd.Parameters.Add("@RecordCount", SqlDbType.Int);
            cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
            cmd.Transaction = conn.BeginTransaction();
            cmd.ExecuteNonQuery();
            // Returns 0 if record is not attached to other data, and 1 if record cannot be deleted
            int rtn = (int)cmd.Parameters["@RecordCount"].Value;
            cmd.Transaction.Commit();

            if (rtn == 0)
            {
                // Checks user wishes to delete record before proceeding
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this record?",
                    "Product Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                string deleteQuery1 = "sp_Products_DeleteProduct";

                // Create SqlCommand object to pass string with stored procedure and the SqlConnection object
                SqlCommand cmd1 = new SqlCommand(deleteQuery1, conn);

                // Passing parameters to the stored procedure and executing procedure
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@ProductID", selectedProductID);
                cmd1.Transaction = conn.BeginTransaction();
                cmd1.ExecuteNonQuery();
                cmd1.Transaction.Commit();

                // Close connection to the database
                conn.Close();

                lvProducts.Items.Clear();
                // Displays new record set
                DisplayProducts();
            }
            else
            {
                MessageBox.Show("Record cannot be deleted");
                conn.Close();
            }
        }
    }
}
