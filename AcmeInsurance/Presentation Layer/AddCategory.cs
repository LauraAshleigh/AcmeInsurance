using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AcmeInsurance.Data_Access_Layer;
using AcmeInsurance.Business_Logic_Layer;

namespace AcmeInsurance.Presentation_Layer
{
    public partial class frmAddCategory : Form
    {
        public frmAddCategory()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Returns to ViewCategories form upon clicking close button in bottom right corner
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clears all fields on form
            txtCategoryID.Clear();
            txtCategory.Clear();
        }

        private void frmAddCategory_Load(object sender, EventArgs e)
        {
            // Determines whether user is creating or updating a Category 
            if (GlobalVariables.selectedCategoryID == 0)
            {
                btnAdd.Text = "&Add";
            }
            else
            {
                btnAdd.Text = "&Update";
            }

            // Update Category
            if (GlobalVariables.selectedCategoryID > 0)
            {
                // Define SQL statement to return record set
                string selectQuery = "SELECT * FROM Categories WHERE CategoryID = " +
                    GlobalVariables.selectedCategoryID.ToString();

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
                    txtCategoryID.Text = rdr["CategoryID"].ToString();
                    txtCategory.Text = rdr["Category"].ToString();
                    
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
            if (String.IsNullOrEmpty(txtCategory.Text))
            {
                MessageBox.Show("Please enter Category.");
                return;
            }
            
            //  Add row to Categories class
            Categories category = new Categories(GlobalVariables.selectedCategoryID,
                txtCategory.Text);

            // Check category does not already exist before adding
            if(GlobalVariables.selectedCategoryID == 0)
            {
                string existQuery;
                existQuery = "sp_Categories_ExistsCategory";
                SqlConnection conn = ConnectionManager.DatabaseConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(existQuery, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Category", txtCategory.Text);
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int);
                cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                cmd.Transaction = conn.BeginTransaction();
                cmd.ExecuteNonQuery();
                // Returns 1 if record already exists
                int rtn = (int)cmd.Parameters["@RecordCount"].Value;
                cmd.Transaction.Commit();

                if (rtn == 1)
                {
                    MessageBox.Show("Category already exists.");
                    return;
                }
                conn.Close();
            }

            // Using a stored procedure to add a row
            string addQuery;
            if (GlobalVariables.selectedCategoryID == 0)
            {
                addQuery = "sp_Categories_CreateCategory";
                MessageBox.Show("Category successfully added.");
            }
            // Using a stored procedure to update a row
            else
            {
                addQuery = "sp_Categories_UpdateCategory";
                MessageBox.Show("Category successfully updated.");
            }

            SqlConnection conn1 = ConnectionManager.DatabaseConnection();
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand(addQuery, conn1);
            cmd1.CommandType = CommandType.StoredProcedure;

            // Update row in database
            if (GlobalVariables.selectedCategoryID != 0)
            {
                cmd1.Parameters.AddWithValue("@CategoryID", category.CategoryID);
            }
            cmd1.Parameters.AddWithValue("@Category", category.Category);

            // Give unique ID to added row
            if (GlobalVariables.selectedCategoryID == 0)
            {
                cmd1.Parameters.AddWithValue("@NewCategoryID", SqlDbType.Int).Direction =
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
