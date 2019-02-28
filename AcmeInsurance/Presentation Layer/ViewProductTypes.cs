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
    public partial class frmViewProductTypes : Form
    {
        public frmViewProductTypes()
        {
            InitializeComponent();
        }

        private void frmViewProductTypes_FormClosing(object sender, FormClosingEventArgs e)
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
            // Opens AddProductType form and ensures no record is currently selected
            GlobalVariables.selectedProductTypeID = 0;
            frmAddProductType editForm = new frmAddProductType();
            editForm.ShowDialog();
            lvProductTypes.Items.Clear();
            DisplayProductTypes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Checks user has selected a product type
            if(lvProductTypes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Product Type to update");
                return;
            }
            // Stores ProductID to be updated
            GlobalVariables.selectedProductTypeID = int.Parse(lvProductTypes.SelectedItems[0].Text);

            // Opens AddProductType form
            frmAddProductType editForm = new frmAddProductType();
            editForm.ShowDialog();
            lvProductTypes.Items.Clear();
            DisplayProductTypes();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Opens SearchProductTypes form
            GlobalVariables.productTypeSearchCriteria = "";
            frmSearchProductTypes searchForm = new frmSearchProductTypes();
            searchForm.ShowDialog();
            lvProductTypes.Items.Clear();
            DisplayProductTypes();
        }

        private void DisplayProductTypes()
        {
            // Define SQL statement to return record set
            string selectQuery;
            selectQuery = "SELECT ProductTypeID, ProductType ";
            selectQuery = selectQuery + "FROM ProductTypes";
            selectQuery = selectQuery + " " + GlobalVariables.productTypeSearchCriteria;

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

                // Loop through the record set and add each row to an instance of the ProductTypes class
                while (rdr.Read())
                {
                    ProductTypes productTypes = new ProductTypes(int.Parse(rdr["ProductTypeID"].ToString()),
                        rdr["ProductType"].ToString());

                    ListViewItem lvi = new ListViewItem(productTypes.ProductTypeID.ToString());
                    lvi.SubItems.Add(productTypes.ProductType);
                    // Add information from database to ListViewItem on form
                    lvProductTypes.Items.Add(lvi);
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

        private void frmViewProductTypes_Load(object sender, EventArgs e)
        {
            // Upon loading form, DisplayProductTypes method is called
            DisplayProductTypes();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Checks user has selected a record to delete
            if (lvProductTypes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Product Type to delete.");
                return;
            }

            // Checks record is able to be deleted
            int selectedProductTypeID = int.Parse(lvProductTypes.SelectedItems[0].Text);
            string deleteQuery = "sp_ProductTypes_AllowDeleteProductType";
            // Connect to the database
            SqlConnection conn = ConnectionManager.DatabaseConnection();

            // Open connection to the database
            conn.Open();
            //Create SqlCommand object to pass string with stored procedure and the SqlConnection object
            SqlCommand cmd = new SqlCommand(deleteQuery, conn);

            // Passing parameters to the stored procedure and executing procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductTypeID", selectedProductTypeID);
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
                    "Product Type Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                
                string deleteQuery1 = "sp_ProductTypes_DeleteProductType";

                // Create SqlCommand object to pass string with stored procedure and the SqlConnection object
                SqlCommand cmd1 = new SqlCommand(deleteQuery1, conn);

                // Passing parameters to the stored procedure and executing procedure
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@ProductTypeID", selectedProductTypeID);
                cmd1.Transaction = conn.BeginTransaction();
                cmd1.ExecuteNonQuery();
                cmd1.Transaction.Commit();

                // Close connection to the database
                conn.Close();

                lvProductTypes.Items.Clear();
                // Displays new record set
                DisplayProductTypes();
            }
            else
            {
                MessageBox.Show("Record cannot be deleted");
                conn.Close();
            }
        }
    }
}
