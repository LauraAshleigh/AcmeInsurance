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

namespace AcmeInsurance
{
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Returns to ViewCustomers form upon clicking close button in bottom right corner
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clears all fields on form
            txtCustomerID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            cbCategory.SelectedIndex = -1;
            rbMale.Checked = false;
            rbFemale.Checked = false;
            dtpBirthDate.Value = DateTime.Now;
            txtAddress.Clear();
            txtSuburb.Clear();
            cbState.SelectedIndex = -1;
            txtPostcode.Clear();
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
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
                    lbCategoryID.Items.Add(rdr["CategoryID"].ToString());
                    cbCategory.Items.Add(rdr["Category"].ToString());
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
            
            // Determines whether user is creating or updating a Customer 
            if(GlobalVariables.selectedCustomerID == 0)
            {
                btnAdd.Text = "&Add";
            }
            else
            {
                btnAdd.Text = "&Update";
            }

            // Update Customer
            if(GlobalVariables.selectedCustomerID > 0)
            {
                // Update selectQuery to return new record set
                selectQuery = "SELECT * FROM Customers WHERE CustomerID = " +
                    GlobalVariables.selectedCustomerID.ToString();

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
                    txtCustomerID.Text = rdr1["CustomerID"].ToString();
                    txtFirstName.Text = rdr1["FirstName"].ToString();
                    txtLastName.Text = rdr1["LastName"].ToString();
                    cbCategory.SelectedIndex = int.Parse(rdr1["CategoryID"].ToString()) - 1;
                    if (rdr1["Gender"].ToString() == "M")
                        rbMale.Checked = true;
                    else
                        rbFemale.Checked = true;
                    dtpBirthDate.Value = (DateTime)rdr1["BirthDate"];
                    txtAddress.Text = rdr1["Address"].ToString();
                    txtSuburb.Text = rdr1["Suburb"].ToString();
                    cbState.Text = rdr1["State"].ToString();
                    txtPostcode.Text = rdr1["Postcode"].ToString();

                    // Close the reader and the connection to the database
                    rdr1.Close();
                    conn1.Close();
                }

                catch(Exception ex)
                {
                    MessageBox.Show("Unsuccessful " + ex);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate user input
            if (String.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("Please enter First Name.");
                return;
            }

            if(String.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Please enter Last Name.");
                return;
            }

            if(String.IsNullOrEmpty(cbCategory.Text))
            {
                MessageBox.Show("Please select a Category.");
                return;
            }

            if(rbMale.Checked == false && rbFemale.Checked == false)
            {
                MessageBox.Show("Please select a Gender");
                return;
            }

            if(String.IsNullOrEmpty(dtpBirthDate.ToString()))
            {
                MessageBox.Show("Please enter a Birth Date.");
                return;
            }

            if(String.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please enter an Address");
                return;
            }

            if(String.IsNullOrEmpty(txtSuburb.Text))
            {
                MessageBox.Show("Please enter a Suburb");
                return;
            }

            if(String.IsNullOrEmpty(cbState.Text))
            {
                MessageBox.Show("Please select a State.");
                return;
            }

            if(String.IsNullOrEmpty(txtPostcode.Text) || txtPostcode.Text.Length != 4)
            {
                MessageBox.Show("Please enter a 4 digit Postcode.");
                return;
            }

            int parsedValue;
            if(!int.TryParse(txtPostcode.Text, out parsedValue))
            {
                MessageBox.Show("Postcode must be a number.");
                return;
            }

            //  Add row to Customers class
            string gender = "M";
            if (rbFemale.Checked)
            {
                gender = "F";
            }

            Customers customer = new Customers(GlobalVariables.selectedCustomerID,
                txtFirstName.Text, txtLastName.Text, lbCategoryID.Items[cbCategory.SelectedIndex].ToString(),
                txtAddress.Text, txtSuburb.Text, cbState.Text, int.Parse(txtPostcode.Text), gender, dtpBirthDate.Text.ToString());


            // Check customer does not already exist before adding
            if (GlobalVariables.selectedCustomerID == 0)
            {
                string existQuery;
                existQuery = "sp_Customers_ExistsCustomer";
                SqlConnection conn = ConnectionManager.DatabaseConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(existQuery, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("Suburb", txtSuburb.Text);
                cmd.Parameters.AddWithValue("State", cbState.Text);
                cmd.Parameters.AddWithValue("Postcode", txtPostcode.Text);
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int);
                cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                cmd.Transaction = conn.BeginTransaction();
                cmd.ExecuteNonQuery();
                // Returns 1 if record already exists
                int rtn = (int)cmd.Parameters["@RecordCount"].Value;
                cmd.Transaction.Commit();

                if (rtn == 1)
                {
                    MessageBox.Show("Customer already exists.");
                    return;
                }
                conn.Close();
            }
            
            // Using a stored procedure to add a row
            string addQuery;
            if (GlobalVariables.selectedCustomerID == 0)
            {
                addQuery = "sp_Customers_CreateCustomer";
                MessageBox.Show("Customer successfully added.");
            }
            // Using a stored procedure to update a row
            else
            {
                addQuery = "sp_Customers_UpdateCustomer";
                MessageBox.Show("Customer successfully updated.");
            }

            SqlConnection conn1 = ConnectionManager.DatabaseConnection();
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand(addQuery, conn1);
            cmd1.CommandType = CommandType.StoredProcedure;

            // Update row in database
            if (GlobalVariables.selectedCustomerID != 0)
            {
                cmd1.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            }
            cmd1.Parameters.AddWithValue("@CategoryID", customer.Category);
            cmd1.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd1.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd1.Parameters.AddWithValue("@Address", customer.Address);
            cmd1.Parameters.AddWithValue("@Suburb", customer.Suburb);
            cmd1.Parameters.AddWithValue("@State", customer.State);
            cmd1.Parameters.AddWithValue("@Postcode", customer.PostCode);
            cmd1.Parameters.AddWithValue("@Gender", customer.Gender);
            cmd1.Parameters.AddWithValue("@BirthDate", customer.BirthDate);

            // Give unique ID to added row
            if (GlobalVariables.selectedCustomerID == 0)
            {
                cmd1.Parameters.AddWithValue("@NewCustomerID", SqlDbType.Int).Direction =
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
