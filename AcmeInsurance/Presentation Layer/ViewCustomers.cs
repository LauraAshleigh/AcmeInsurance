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
    public partial class frmViewCustomers : Form
    {
        public frmViewCustomers()
        {
            InitializeComponent();
        }

        private void frmViewCustomers_FormClosing(object sender, FormClosingEventArgs e)
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
            // Opens AddCustomer form and ensures no record is currently selected
            GlobalVariables.selectedCustomerID = 0;
            frmAddCustomer editForm = new frmAddCustomer();
            editForm.ShowDialog();
            lvCustomers.Items.Clear();
            DisplayCustomers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Checks user has selected a customer
            if(lvCustomers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Customer to update.");
                return;
            }
            // Stores CustomerID to be updated
            GlobalVariables.selectedCustomerID = int.Parse(lvCustomers.SelectedItems[0].Text);

            // Opens AddCustomer form
            frmAddCustomer editForm = new frmAddCustomer();
            editForm.ShowDialog();
            lvCustomers.Items.Clear();
            DisplayCustomers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Opens SearchCustomers form
            GlobalVariables.customerSearchCriteria = "";
            frmSearchCustomers searchForm = new frmSearchCustomers();
            searchForm.ShowDialog();
            lvCustomers.Items.Clear();
            DisplayCustomers();
        }

        private void DisplayCustomers()
        {
            // Define SQL statement to return record set
            string selectQuery;
            selectQuery = "SELECT Customers.CustomerID, Customers.FirstName, Customers.LastName, ";
            selectQuery = selectQuery + "Categories.Category, Customers.Address, Customers.Suburb, ";
            selectQuery = selectQuery + "Customers.State, Customers.Postcode, Customers.Gender, CONVERT(VARCHAR, Customers.BirthDate, 107) AS BirthDate";
            selectQuery = selectQuery + " FROM Customers INNER JOIN ";
            selectQuery = selectQuery + "Categories ON Customers.CategoryID = Categories.CategoryID";
            selectQuery = selectQuery + " " + GlobalVariables.customerSearchCriteria;

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

                // Loop through the record set and add each row to an instance of the Customers class
                while (rdr.Read())
                {
                    // Define the list items
                    string gender = "Male";
                    if(rdr["Gender"].ToString() == "F")
                    {
                        gender = "Female";
                    }

                    Customers customer = new Customers(int.Parse(rdr["CustomerID"].ToString()),
                                                rdr["FirstName"].ToString(), rdr["LastName"].ToString(),
                                                rdr["Category"].ToString(), rdr["Address"].ToString(),
                                                rdr["Suburb"].ToString(), rdr["State"].ToString(),
                                                int.Parse(rdr["Postcode"].ToString()), gender, rdr["BirthDate"].ToString());

                    ListViewItem lvi = new ListViewItem(customer.CustomerID.ToString());
                    lvi.SubItems.Add(customer.FirstName);
                    lvi.SubItems.Add(customer.LastName);
                    lvi.SubItems.Add(customer.Category);
                    lvi.SubItems.Add(customer.Address);
                    lvi.SubItems.Add(customer.Suburb);
                    lvi.SubItems.Add(customer.State);
                    lvi.SubItems.Add(customer.PostCode.ToString());
                    lvi.SubItems.Add(customer.Gender);
                    lvi.SubItems.Add(customer.BirthDate);
                    // Add information from database to ListViewItem on form
                    lvCustomers.Items.Add(lvi);
                }

                // Close the reader once data has been read
                if(rdr != null)
                {
                    rdr.Close();
                }
                // Close the connection to the database
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unsuccessful " + ex);
            }
        }

        private void frmViewCustomers_Load(object sender, EventArgs e)
        {
            // Upon loading form, DisplayCustomers method is called
            DisplayCustomers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Checks user has selected a record to delete
            if(lvCustomers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Customer to delete.");
                return;
            }

            // Checks record is able to be deleted
            int selectedCustomerID = int.Parse(lvCustomers.SelectedItems[0].Text);
            string deleteQuery = "sp_Customers_AllowDeleteCustomer";
            // Connect to the database
            SqlConnection conn = ConnectionManager.DatabaseConnection();

            // Open connection to the database
            conn.Open();
            //Create SqlCommand object to pass string with stored procedure and the SqlConnection object
            SqlCommand cmd = new SqlCommand(deleteQuery, conn);

            // Passing parameters to the stored procedure and executing procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", selectedCustomerID);
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
                    "Customer Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                string deleteQuery1 = "sp_Customers_DeleteCustomer";

                // Create SqlCommand object to pass string with stored procedure and the SqlConnection object
                SqlCommand cmd1 = new SqlCommand(deleteQuery1, conn);

                // Passing parameters to the stored procedure and executing procedure
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@CustomerID", selectedCustomerID);
                cmd1.Transaction = conn.BeginTransaction();
                cmd1.ExecuteNonQuery();
                cmd1.Transaction.Commit();

                // Close connection to the database
                conn.Close();

                lvCustomers.Items.Clear();
                // Displays new record set
                DisplayCustomers();
            }
            else
            {
                MessageBox.Show("Record cannot be deleted");
                conn.Close();
            }
        }
    }
}
