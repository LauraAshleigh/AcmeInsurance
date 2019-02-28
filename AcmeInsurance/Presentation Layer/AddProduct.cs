using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcmeInsurance.Data_Access_Layer;
using AcmeInsurance.Business_Logic_Layer;
using System.Data.SqlClient;

namespace AcmeInsurance.Presentation_Layer
{
    public partial class frmAddProduct : Form
    {
        public frmAddProduct()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Returns to ViewProducts form upon clicking close button in bottom right corner
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clears all fields on form
            txtProductID.Clear();
            cbProductType.SelectedIndex = -1;
            txtProductName.Clear();
            txtYearlyPremium.Clear();
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            // Define SQL statement to return record set
            string selectQuery;
            selectQuery = "SELECT * FROM ProductTypes";

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

                // Fills combo box with categories from database
                while (rdr.Read())
                {
                    lbProductTypeID.Items.Add(rdr["ProductTypeID"].ToString());
                    cbProductType.Items.Add(rdr["ProductType"].ToString());
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

            // Determines whether user is creating or updating a Product 
            if (GlobalVariables.selectedProductID == 0)
            {
                btnAdd.Text = "&Add";
            }
            else
            {
                btnAdd.Text = "&Update";
            }

            // Update Product
            if (GlobalVariables.selectedProductID > 0)
            {
                // Update selectQuery to return new record set
                selectQuery = "SELECT * FROM Products WHERE ProductID = " +
                    GlobalVariables.selectedProductID.ToString();

                // Open new connection to database and create new reader to store new record set
                SqlConnection conn1 = ConnectionManager.DatabaseConnection();
                SqlDataReader rdr1 = null;
                try
                {
                    // Open the connection to the database 
                    conn1.Open();
                    // Create SqlCommand object to pass string with SQL statement and the SqlConnection object
                    SqlCommand cmd = new SqlCommand(selectQuery, conn1);
                    // Send the SQL query to the SqlConnection object
                    rdr1 = cmd.ExecuteReader();

                    // Use data from database to fill fields on form
                    rdr1.Read();
                    txtProductID.Text = rdr1["ProductID"].ToString();
                    cbProductType.SelectedIndex = int.Parse(rdr1["ProductTypeID"].ToString()) - 1;
                    txtProductName.Text = rdr1["ProductName"].ToString();
                    txtYearlyPremium.Text = rdr1["YearlyPremium"].ToString();

                    // Close the reader and the connection to the database
                    rdr1.Close();
                    conn1.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Unsuccessful " + ex);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate user input
            if (String.IsNullOrEmpty(cbProductType.Text))
            {
                MessageBox.Show("Please select a Product Type.");
                return;
            }

            if (String.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Please enter Product Name.");
                return;
            }

            if (String.IsNullOrEmpty(txtYearlyPremium.Text))
            {
                MessageBox.Show("Please enter a Yearly Premium.");
                return;
            }

            float parsedValue;
            if (!float.TryParse(txtYearlyPremium.Text, out parsedValue))
            {
                MessageBox.Show("Yearly Premium must be a number.");
                return;
            }

            //  Add row to Products class
            Products product = new Products(GlobalVariables.selectedProductID, 
                lbProductTypeID.Items[cbProductType.SelectedIndex].ToString(), txtProductName.Text, 
                float.Parse(txtYearlyPremium.Text));

            // Check product does not already exist before adding
            if(GlobalVariables.selectedProductID == 0)
            {
                string existQuery;
                existQuery = "sp_Products_ExistsProduct";
                SqlConnection conn = ConnectionManager.DatabaseConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(existQuery, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ProductTypeID", lbProductTypeID.Items[cbProductType.SelectedIndex].ToString());
                cmd.Parameters.AddWithValue("ProductName", txtProductName.Text);
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int);
                cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                cmd.Transaction = conn.BeginTransaction();
                cmd.ExecuteNonQuery();
                // Returns 1 if record already exists
                int rtn = (int)cmd.Parameters["@RecordCount"].Value;
                cmd.Transaction.Commit();

                if (rtn == 1)
                {
                    MessageBox.Show("Product already exists.");
                    return;
                }
                conn.Close();
            }

            // Using a stored procedure to add a row
            string addQuery;
            if (GlobalVariables.selectedProductID == 0)
            {
                addQuery = "sp_Products_CreateProduct";
                MessageBox.Show("Product successfully added.");
            }
            // Using a stored procedure to update a row
            else
            {
                addQuery = "sp_Products_UpdateProduct";
                MessageBox.Show("Product successfully updated.");
            }

            SqlConnection conn1 = ConnectionManager.DatabaseConnection();
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand(addQuery, conn1);
            cmd1.CommandType = CommandType.StoredProcedure;

            // Update row in database
            if (GlobalVariables.selectedProductID != 0)
            {
                cmd1.Parameters.AddWithValue("@ProductID", product.ProductID);
            }
            cmd1.Parameters.AddWithValue("@ProductTypeID", product.ProductType);
            cmd1.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd1.Parameters.AddWithValue("@YearlyPremium", product.YearlyPremium);

            // Give unique ID to added row
            if (GlobalVariables.selectedProductID == 0)
            {
                cmd1.Parameters.AddWithValue("@NewProductID", SqlDbType.Int).Direction =
                    ParameterDirection.Output;
            }
            cmd1.Transaction = conn1.BeginTransaction();
            cmd1.ExecuteNonQuery();
            cmd1.Transaction.Commit();
            
            // Close connection to the database and close form
            conn1.Close();
            this.Close();
        }
    }
}
