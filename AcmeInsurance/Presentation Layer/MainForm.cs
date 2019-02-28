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

namespace AcmeInsurance
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewCategories viewForm = new frmViewCategories();
            viewForm.Show();
            this.Hide();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewCustomers viewForm = new frmViewCustomers();
            viewForm.Show();
            this.Hide();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewProducts viewForm = new frmViewProducts();
            viewForm.Show();
            this.Hide();
        }

        private void productTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewProductTypes viewForm = new frmViewProductTypes();
            viewForm.Show();
            this.Hide();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewSales viewForm = new frmViewSales();
            viewForm.Show();
            this.Hide();
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTutorial tutForm = new frmTutorial();
            tutForm.ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout abForm = new frmAbout();
            abForm.Show(this);
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            string selectQuery;
            selectQuery = "SELECT Products.ProductName, ProductTypes.ProductType, COUNT(Sales.ProductID) AS TotalSales " +
                "FROM Products INNER JOIN ProductTypes ON Products.ProductTypeID = ProductTypes.ProductTypeID " +
                "INNER JOIN Sales ON Sales.ProductID = Products.ProductID " +
                "GROUP BY Products.ProductName, ProductTypes.ProductType, Sales.ProductID";

            SqlConnection conn = ConnectionManager.DatabaseConnection();
            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ListViewItem lvi = new ListViewItem(rdr["ProductName"].ToString());
                    lvi.SubItems.Add(rdr["ProductType"].ToString());
                    lvi.SubItems.Add(rdr["TotalSales"].ToString());
                    lvMain.Items.Add(lvi);
                }

                if(rdr != null)
                {
                    rdr.Close();
                }
                conn.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show("Unsuccessful " + ex);
            }
        }
    }
}
