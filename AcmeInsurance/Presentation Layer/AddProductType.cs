using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcmeInsurance.Business_Logic_Layer;
using AcmeInsurance.Data_Access_Layer;
using System.Data.SqlClient;

namespace AcmeInsurance.Presentation_Layer
{
    public partial class frmAddProductType : Form
    {
        public frmAddProductType()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Returns to ViewProductTypes form upon clicking close button in bottom right corner
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clears all fields on form
            txtProductTypeID.Clear();
            txtProductType.Clear();
        }

        private void frmAddProductType_Load(object sender, EventArgs e)
        {
            // Determines whether user is creating or updating a Product Type 
            if (GlobalVariables.selectedProductTypeID == 0)
            {
                btnAdd.Text = "&Add";
            }
            else
            {
                btnAdd.Text = "&Update";
            }

            // Update Product Type
            if (GlobalVariables.selectedProductTypeID > 0)
            {
                // Define SQL statement to return record set
                string selectQuery = "SELECT * FROM ProductTypes WHERE ProductTypeID = " +
                    GlobalVariables.selectedProductTypeID.ToString();

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

                    // Use data from database to fill fields on form
                    rdr.Read();
                    txtProductTypeID.Text = rdr["ProductTypeID"].ToString();
                    txtProductType.Text = rdr["ProductType"].ToString();

                    // Close the reader and the connection to the database
                    rdr.Close();
                    conn.Close();
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
            if (String.IsNullOrEmpty(txtProductType.Text))
            {
                MessageBox.Show("Please enter Product Type.");
                return;
            }

            //  Add row to ProductTypes class
            ProductTypes productType = new ProductTypes(GlobalVariables.selectedProductTypeID,
                txtProductType.Text);

            // Check product type does not already exist before adding
            if(GlobalVariables.selectedProductTypeID == 0)
            {
                string existQuery;
                existQuery = "sp_ProductTypes_ExistsProductType";
                SqlConnection conn = ConnectionManager.DatabaseConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(existQuery, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ProductType", txtProductType.Text);
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int);
                cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                cmd.Transaction = conn.BeginTransaction();
                cmd.ExecuteNonQuery();
                // Returns 1 if record already exists
                int rtn = (int)cmd.Parameters["@RecordCount"].Value;
                cmd.Transaction.Commit();

                if (rtn == 1)
                {
                    MessageBox.Show("Product Type already exists.");
                    return;
                }
                conn.Close();
            }

            // Using a stored procedure to add a row
            string addQuery;
            if (GlobalVariables.selectedProductTypeID == 0)
            {
                addQuery = "sp_ProductTypes_CreateProductType";
                MessageBox.Show("Product Type successfully added.");
            }
            // Using a stored procedure to update a row
            else
            {
                addQuery = "sp_ProductTypes_UpdateProductType";
                MessageBox.Show("Product Type successfully updated.");
            }

            SqlConnection conn1 = ConnectionManager.DatabaseConnection();
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand(addQuery, conn1);
            cmd1.CommandType = CommandType.StoredProcedure;

            // Update row in database
            if (GlobalVariables.selectedProductTypeID != 0)
            {
                cmd1.Parameters.AddWithValue("@ProductTypeID", productType.ProductTypeID);
            }
            cmd1.Parameters.AddWithValue("@ProductType", productType.ProductType);

            // Give unique ID to added row
            if (GlobalVariables.selectedProductTypeID == 0)
            {
                cmd1.Parameters.AddWithValue("@NewProductTypeID", SqlDbType.Int).Direction =
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
