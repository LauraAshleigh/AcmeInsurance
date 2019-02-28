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
    public partial class frmSearchProducts : Form
    {
        public frmSearchProducts()
        {
            InitializeComponent();
        }

        private void rbAll_Click(object sender, EventArgs e)
        {
            // Search boxes are not visible to user
            txtSearch.Visible = false;
            cbProductType.Visible = false;
        }

        private void rbProductType_Click(object sender, EventArgs e)
        {
            // Combo box of product types to search by visible to user
            txtSearch.Visible = false;
            cbProductType.Visible = true;
            cbProductType.Top = txtSearch.Top;
            cbProductType.Left = txtSearch.Left;
            // Cursor focused to combo box to improve user experience
            cbProductType.Focus();
        }

        private void rbPremium_Click(object sender, EventArgs e)
        {
            // Text box visible to type yearly premium into
            txtSearch.Visible = true;
            cbProductType.Visible = false;
            // Cursor focused to text box to improve user experience
            txtSearch.Focus();
        }

        private void frmSearchProducts_Load(object sender, EventArgs e)
        {
            // Keeps search boxes hidden from user until search option selected
            txtSearch.Visible = false;
            cbProductType.Visible = false;

            // Define SQL statement to return record set to fill product and product type combo boxes
            string selectQuery;
            selectQuery = "SELECT ProductTypeID, ProductType FROM ProductTypes";

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

                // Fills product type combo box with data from database
                while (rdr.Read())
                {
                    lbProductType.Items.Add(rdr["ProductTypeID"].ToString());
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
            catch (Exception ex)
            {
                MessageBox.Show("Unsuccessful" + ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Searches all products
            if (rbAll.Checked == true)
            {
                GlobalVariables.productSearchCriteria = "";
            }

            // Searches products based on product type selected
            if (rbProductType.Checked == true)
            {
                GlobalVariables.productSearchCriteria = "WHERE Products.ProductTypeID = " +
                    lbProductType.Items[cbProductType.SelectedIndex].ToString() + "";
            }

            // Searches products based on yearly premium entered
            if (rbPremium.Checked == true)
            {
                GlobalVariables.productSearchCriteria = "WHERE YearlyPremium = '" +
                    txtSearch.Text + "'";
            }

            this.Close();
        }
    }
}
