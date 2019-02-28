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
    public partial class frmSearchCategories : Form
    {
        public frmSearchCategories()
        {
            InitializeComponent();
        }

        private void rbAll_Click(object sender, EventArgs e)
        {
            // Search box not visible to user
            txtSearch.Visible = false;
        }

        private void rbCategory_Click(object sender, EventArgs e)
        {
            // Text box visible to type category into
            txtSearch.Visible = true;
            // Cursor focused to text box to improve user experience
            txtSearch.Focus();
        }

        private void frmSearchCategories_Load(object sender, EventArgs e)
        {
            // Keeps search box hidden from user until search option selected
            txtSearch.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Searches all categories
            if (rbAll.Checked == true)
            {
                GlobalVariables.categorySearchCriteria = "";
            }

            // Searches categories based on text entered
            if (rbCategory.Checked == true)
            {
                GlobalVariables.categorySearchCriteria = "WHERE Category LIKE '%" +
                    txtSearch.Text + "%'";
            }
            
            this.Close();
        }
    }
}
