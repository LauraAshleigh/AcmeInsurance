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
    public partial class frmSearchSales : Form
    {
        public frmSearchSales()
        {
            InitializeComponent();
        }

        private void rbAll_Click(object sender, EventArgs e)
        {
            // Search boxes are not visible to user
            txtSearch.Visible = false;
            cbProduct.Visible = false;
            dtpStartDate.Visible = false;
        }

        private void rbCustomer_Click(object sender, EventArgs e)
        {
            // Text box visible to type last name into
            txtSearch.Visible = true;
            cbProduct.Visible = false;
            dtpStartDate.Visible = false;
            // Cursor focused to text box to improve user experience
            txtSearch.Focus();
        }

        private void rbProduct_Click(object sender, EventArgs e)
        {
            // Combo box of products to search by visible to user
            txtSearch.Visible = false;
            cbProduct.Visible = true;
            dtpStartDate.Visible = false;
            cbProduct.Top = txtSearch.Top;
            cbProduct.Left = txtSearch.Left;
            // Cursor focused to combo box to improve user experience
            cbProduct.Focus();
        }

        private void rbDate_Click(object sender, EventArgs e)
        {
            // Date time picker to search by date visible to user
            txtSearch.Visible = false;
            cbProduct.Visible = false;
            dtpStartDate.Visible = true;
            dtpStartDate.Top = txtSearch.Top;
            dtpStartDate.Left = txtSearch.Left;
        }

        private void frmSearchSales_Load(object sender, EventArgs e)
        {
            // Keeps search boxes hidden from user until search option selected
            txtSearch.Visible = false;
            cbProduct.Visible = false;

            // Define SQL statement to return record set
            string selectQuery;
            selectQuery = "SELECT ProductID, ProductName FROM Products";

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

                // Fills combo box with products from database
                while (rdr.Read())
                {
                    lbProduct.Items.Add(rdr["ProductID"].ToString());
                    cbProduct.Items.Add(rdr["ProductName"].ToString());
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
            // Searches all sales
            if (rbAll.Checked == true)
            {
                GlobalVariables.saleSearchCriteria = "";
            }

            // Searches sales based on customer last name entered
            if (rbCustomer.Checked == true)
            {
                GlobalVariables.saleSearchCriteria = "WHERE Customers.LastName LIKE '%" +
                    txtSearch.Text + "%'";
            }

            // Searches sales based on product selected
            if (rbProduct.Checked == true)
            {
                GlobalVariables.saleSearchCriteria = "WHERE Sales.ProductID = " +
                    lbProduct.Items[cbProduct.SelectedIndex].ToString() + "";
            }

            // Searches sales based on date entered
            if (rbDate.Checked == true)
            {
                GlobalVariables.saleSearchCriteria = "WHERE StartDate = '" +
                    dtpStartDate.Text.ToString() + "'";
            }

            this.Close();
        }
    }
}
