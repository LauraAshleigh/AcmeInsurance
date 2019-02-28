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
using System.Data.SqlClient;

namespace AcmeInsurance.Presentation_Layer
{
    public partial class frmSearchCustomers : Form
    {
        public frmSearchCustomers()
        {
            InitializeComponent();
        }

        private void rbAll_Click(object sender, EventArgs e)
        {
            // Search boxes are not visible to user
            txtSearch.Visible = false;
            cbCategory.Visible = false;
        }

        private void rbLast_Click(object sender, EventArgs e)
        {
            // Text box visible to type last name into
            txtSearch.Visible = true;
            cbCategory.Visible = false;
            // Cursor focused to text box to improve user experience
            txtSearch.Focus();
        }

        private void rbCategory_Click(object sender, EventArgs e)
        {
            // Combo box box of categories to search by visible to user
            txtSearch.Visible = false;
            cbCategory.Visible = true;
            cbCategory.Top = txtSearch.Top;
            cbCategory.Left = txtSearch.Left;
            // Cursor focused to combo box to improve user experience
            cbCategory.Focus();
        }

        private void rbPostcode_Click(object sender, EventArgs e)
        {
            // Text box visible to type postcode into
            txtSearch.Visible = true;
            cbCategory.Visible = false;
            // Cursor focused to text box to improve user experience
            txtSearch.Focus();
        }

        private void frmSearchCustomers_Load(object sender, EventArgs e)
        {
            // Keeps search boxes hidden from user until search option selected
            txtSearch.Visible = false;
            cbCategory.Visible = false;

            // Define SQL statement to return record set
            string selectQuery;
            selectQuery = "SELECT * FROM Categories";

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
                    lbCategory.Items.Add(rdr["CategoryID"].ToString());
                    cbCategory.Items.Add(rdr["Category"].ToString());
                }

                // Close the reader once data has been read
                if (rdr != null)
                {
                    rdr.Close();
                }
                // Close the connection to the database    
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unsuccessful" + ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Searches all customers
            if (rbAll.Checked == true)
            {
                GlobalVariables.customerSearchCriteria = "";
            }

            // Searches customers based on last name entered
            if(rbLast.Checked == true)
            {
                GlobalVariables.customerSearchCriteria = "WHERE LastName = '" +
                    txtSearch.Text + "'";
            }

            // Searches customers based on category selected
            if(rbCategory.Checked == true)
            {
                GlobalVariables.customerSearchCriteria = "WHERE Customers.CategoryID = " +
                    lbCategory.Items[cbCategory.SelectedIndex].ToString() + "";
            }

            // Searches customers based on postcode entered
            if(rbPostcode.Checked == true)
            {
                GlobalVariables.customerSearchCriteria = "WHERE Postcode = '" +
                    txtSearch.Text + "'";
            }

            this.Close();
        }
    }
}
