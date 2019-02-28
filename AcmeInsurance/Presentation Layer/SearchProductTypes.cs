using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcmeInsurance.Presentation_Layer
{
    public partial class frmSearchProductTypes : Form
    {
        public frmSearchProductTypes()
        {
            InitializeComponent();
        }

        private void rbAll_Click(object sender, EventArgs e)
        {
            // Search box not visible to user
            txtSearch.Visible = false;
        }

        private void rbProductType_Click(object sender, EventArgs e)
        {
            // Text box visible to type product type into
            txtSearch.Visible = true;
            // Cursor focused to text box to improve user experience
            txtSearch.Focus();
        }

        private void frmSearchProductTypes_Load(object sender, EventArgs e)
        {
            // Keeps search box hidden from user until search option selected
            txtSearch.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Searches all product types
            if (rbAll.Checked == true)
            {
                GlobalVariables.productTypeSearchCriteria = "";
            }

            // Searches product types based on text entered
            if (rbProductType.Checked == true)
            {
                GlobalVariables.customerSearchCriteria = "WHERE ProductType LIKE '%" +
                    txtSearch.Text + "%'";
            }

            this.Close();
        }
    }
}
