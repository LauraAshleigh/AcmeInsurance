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
using AcmeInsurance.Data_Access_Layer;
using AcmeInsurance.Business_Logic_Layer;
using System.Data.SqlClient;

namespace AcmeInsurance
{
    public partial class frmViewSales : Form
    {
        public frmViewSales()
        {
            InitializeComponent();
        }

        private void frmViewSales_FormClosing(object sender, FormClosingEventArgs e)
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
            // Opens AddSale form and ensures no record is currently selected
            GlobalVariables.selectedSaleID = 0;
            frmAddSale editForm = new frmAddSale();
            editForm.ShowDialog();
            lvSales.Items.Clear();
            DisplaySales();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Checks user has selected a sale
            if(lvSales.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Sale to update.");
                return;
            }
            // Stores SaleID to be updated
            GlobalVariables.selectedSaleID = int.Parse(lvSales.SelectedItems[0].Text);

            // Opens AddSale form
            frmAddSale editForm = new frmAddSale();
            editForm.ShowDialog();
            lvSales.Items.Clear();
            DisplaySales();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Opens SearchSales form
            GlobalVariables.saleSearchCriteria = "";
            frmSearchSales searchForm = new frmSearchSales();
            searchForm.ShowDialog();
            lvSales.Items.Clear();
            DisplaySales();
        }

        private void DisplaySales()
        {
            // Define SQL statement to return record set
            string selectQuery;
            selectQuery = "SELECT Sales.SaleID, (Customers.FirstName + ' ' + Customers.LastName + ', ' + Customers.Suburb) AS Customer, ";
            selectQuery = selectQuery + "Products.ProductName, Sales.Payable, (Products.YearlyPremium) AS Premium, CONVERT(VARCHAR, Sales.StartDate, 107) AS StartDate ";
            selectQuery = selectQuery + "FROM Sales JOIN Customers ON Sales.CustomerID = Customers.CustomerID ";
            selectQuery = selectQuery + "JOIN Products ON Sales.ProductID = Products.ProductID";
            selectQuery = selectQuery + " " + GlobalVariables.saleSearchCriteria;

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

                // Loop through the record set and add each row to an instance of the Sales class
                while (rdr.Read())
                {
                    // Define the list items
                    string payable = "Fortnightly";
                    if(rdr["Payable"].ToString() == "M")
                    {
                        payable = "Monthly";
                    }
                    else if(rdr["Payable"].ToString() == "Y")
                    {
                        payable = "Yearly";
                    }

                    decimal premium = decimal.Parse(rdr["Premium"].ToString());
                    if(payable == "Fortnightly")
                    {
                        premium = Math.Round(premium / 26, 2);
                    }
                    else if(payable == "Monthly")
                    {
                        premium = Math.Round(premium / 12, 2);
                    }
                    else
                    {
                        premium = Math.Round(premium, 2);
                    }

                    Sales sale = new Sales(int.Parse(rdr["SaleID"].ToString()),
                        rdr["Customer"].ToString(), rdr["ProductName"].ToString(),
                        payable, rdr["StartDate"].ToString());

                    ListViewItem lvi = new ListViewItem(sale.SaleID.ToString());
                    lvi.SubItems.Add(sale.Customer);
                    lvi.SubItems.Add(sale.Product);
                    lvi.SubItems.Add(sale.Payable);
                    lvi.SubItems.Add(premium.ToString());
                    lvi.SubItems.Add(sale.StartDate);
                    // Add information from database to ListViewItem on form
                    lvSales.Items.Add(lvi);
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

        private void frmViewSales_Load(object sender, EventArgs e)
        {
            // Upon loading form, DisplaySales method is called
            DisplaySales();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Checks user has selected a record to delete
            if (lvSales.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Sale to delete.");
                return;
            }

            // Checks user wishes to delete record before proceeding
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this record?",
                "Sale Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // Passes selected record to stored procedure to delete sale
            int selectedSaleID = int.Parse(lvSales.SelectedItems[0].Text);
            string deleteQuery = "sp_Sales_DeleteSale";
            // Connect to the database
            SqlConnection conn = ConnectionManager.DatabaseConnection();
            // Open connection to the database
            conn.Open();
            // Create SqlCommand object to pass string with stored procedure and the SqlConnection object
            SqlCommand cmd = new SqlCommand(deleteQuery, conn);

            // Passing parameters to the stored procedure and executing procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SaleID", selectedSaleID);
            cmd.Transaction = conn.BeginTransaction();
            cmd.ExecuteNonQuery();
            cmd.Transaction.Commit();

            // Close connection to the database
            conn.Close();

            lvSales.Items.Clear();
            // Displays new record set
            DisplaySales();
        }
    }
}
