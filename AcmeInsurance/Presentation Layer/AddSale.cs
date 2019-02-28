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
    public partial class frmAddSale : Form
    {
        public frmAddSale()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Returns to ViewSales form upon clicking close button in bottom right corner
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clears all fields on form
            txtSaleID.Clear();
            cbCustomer.SelectedIndex = -1;
            cbProduct.SelectedIndex = -1;
            rbFortnightly.Checked = false;
            rbMonthly.Checked = false;
            rbYearly.Checked = false;
            dtpStartDate.Value = DateTime.Now;
        }

        private void frmAddSale_Load(object sender, EventArgs e)
        {
            // Define SQL statement to return record set to fill customer and product combo boxes
            string selectQuery, selectQuery1;
            selectQuery = "SELECT CustomerID, (FirstName + ' ' + LastName + ', ' + Suburb) AS Customer FROM Customers";
            selectQuery1 = "SELECT ProductID, ProductName FROM Products";

            // Connect to the database and define a reader to store the record set
            SqlConnection conn = ConnectionManager.DatabaseConnection();
            SqlDataReader rdr = null;

            try
            {
                // Open the connection to the database
                conn.Open();
                // Create SqlCommand object to pass string with first SQL statement and the SqlConnection object
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                // Send the SQL query to the SqlConnection object
                rdr = cmd.ExecuteReader();

                // Fills customer combo box with data from database
                while (rdr.Read())
                {
                    lbCustomerID.Items.Add(rdr["CustomerID"].ToString());
                    cbCustomer.Items.Add(rdr["Customer"].ToString());
                }
                
                // Close the reader once data has been read
                if(rdr != null)
                {
                    rdr.Close();
                }

                // Create SqlCommand object to pass string with second SQL statement and the SqlConnection object
                SqlCommand cmd1 = new SqlCommand(selectQuery1, conn);
                // Send the SQL query to the SqlConnection object
                rdr = cmd1.ExecuteReader();

                // Fills product combo box with data from database
                while (rdr.Read())
                {
                    lbProductID.Items.Add(rdr["ProductID"].ToString());
                    cbProduct.Items.Add(rdr["ProductName"].ToString());
                }

                // Close the reader once data has been read
                if(rdr != null)
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

            // Determines whether user is creating or updating a Sale 
            if (GlobalVariables.selectedSaleID == 0)
            {
                btnAdd.Text = "&Add";
            }
            else
            {
                btnAdd.Text = "&Update";
            }

            // Update Sale
            if (GlobalVariables.selectedSaleID > 0)
            {
                // Update selectQuery to return new record set
                selectQuery = "SELECT * FROM Sales WHERE SaleID = " +
                    GlobalVariables.selectedSaleID.ToString();

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
                    txtSaleID.Text = rdr1["SaleID"].ToString();
                    cbCustomer.SelectedIndex = int.Parse(rdr1["CustomerID"].ToString()) - 1;
                    cbProduct.SelectedIndex = int.Parse(rdr1["ProductID"].ToString()) - 1;
                    if (rdr1["Payable"].ToString() == "F")
                        rbFortnightly.Checked = true;
                    else if (rdr1["Payable"].ToString() == "M")
                        rbMonthly.Checked = true;
                    else
                        rbYearly.Checked = true;
                    dtpStartDate.Value = (DateTime)rdr1["StartDate"];

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
            if (String.IsNullOrEmpty(cbCustomer.Text))
            {
                MessageBox.Show("Please select a Customer. If new Customer please add Customer first.");
                return;
            }

            if (String.IsNullOrEmpty(cbProduct.Text))
            {
                MessageBox.Show("Please select a Product.");
                return;
            }

            if (rbFortnightly.Checked == false && rbMonthly.Checked == false && rbYearly.Checked == false)
            {
                MessageBox.Show("Please select a Payable period.");
                return;
            }

            if (String.IsNullOrEmpty(dtpStartDate.ToString()))
            {
                MessageBox.Show("Please enter a Start Date.");
                return;
            }

            //  Add row to Sales class
            string payable = "F";
            if (rbMonthly.Checked)
            {
                payable = "M";
            }
            else if(rbYearly.Checked)
            {
                payable = "Y";
            }

            Sales sale = new Sales(GlobalVariables.selectedSaleID,
                lbCustomerID.Items[cbCustomer.SelectedIndex].ToString(), lbProductID.Items[cbProduct.SelectedIndex].ToString(),
                payable, dtpStartDate.Text.ToString());

            // Check sale does not already exist before adding
            if(GlobalVariables.selectedSaleID == 0)
            {
                string existQuery;
                existQuery = "sp_Sales_ExistsSale";
                SqlConnection conn = ConnectionManager.DatabaseConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(existQuery, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CustomerID", lbCustomerID.Items[cbCustomer.SelectedIndex].ToString());
                cmd.Parameters.AddWithValue("ProductID", lbProductID.Items[cbProduct.SelectedIndex].ToString());
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int);
                cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                cmd.Transaction = conn.BeginTransaction();
                cmd.ExecuteNonQuery();
                // Returns 1 if record already exists
                int rtn = (int)cmd.Parameters["@RecordCount"].Value;
                cmd.Transaction.Commit();

                if (rtn == 1)
                {
                    MessageBox.Show("Sale already exists.");
                    return;
                }
                conn.Close();
            }

            // Using a stored procedure to add a row
            string addQuery;
            if (GlobalVariables.selectedSaleID == 0)
            {
                addQuery = "sp_Sales_CreateSale";
                MessageBox.Show("Sale successfully added.");
            }
            // Using a stored procedure to update a row
            else
            {
                addQuery = "sp_Sales_UpdateSale";
                MessageBox.Show("Sale successfully updated.");
            }
            SqlConnection conn1 = ConnectionManager.DatabaseConnection();
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand(addQuery, conn1);
            cmd1.CommandType = CommandType.StoredProcedure;

            // Update row in database
            if (GlobalVariables.selectedSaleID != 0)
            {
                cmd1.Parameters.AddWithValue("@SaleID", sale.SaleID);
            }
            cmd1.Parameters.AddWithValue("@CustomerID", sale.Customer);
            cmd1.Parameters.AddWithValue("@ProductID", sale.Product);
            cmd1.Parameters.AddWithValue("@Payable", sale.Payable);
            cmd1.Parameters.AddWithValue("@StartDate", sale.StartDate);

            // Give unique ID to added row
            if (GlobalVariables.selectedSaleID == 0)
            {
                cmd1.Parameters.AddWithValue("@NewSaleID", SqlDbType.Int).Direction =
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
