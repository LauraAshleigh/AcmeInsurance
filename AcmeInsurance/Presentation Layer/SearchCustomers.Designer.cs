namespace AcmeInsurance.Presentation_Layer
{
    partial class frmSearchCustomers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchCustomers));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbLast = new System.Windows.Forms.RadioButton();
            this.rbCategory = new System.Windows.Forms.RadioButton();
            this.rbPostcode = new System.Windows.Forms.RadioButton();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lbCategory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(241, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 20);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(336, 171);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(32, 39);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(79, 17);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "List all rows";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.Click += new System.EventHandler(this.rbAll_Click);
            // 
            // rbLast
            // 
            this.rbLast.AutoSize = true;
            this.rbLast.Location = new System.Drawing.Point(32, 84);
            this.rbLast.Name = "rbLast";
            this.rbLast.Size = new System.Drawing.Size(121, 17);
            this.rbLast.TabIndex = 1;
            this.rbLast.TabStop = true;
            this.rbLast.Text = "Search by last name";
            this.rbLast.UseVisualStyleBackColor = true;
            this.rbLast.Click += new System.EventHandler(this.rbLast_Click);
            // 
            // rbCategory
            // 
            this.rbCategory.AutoSize = true;
            this.rbCategory.Location = new System.Drawing.Point(32, 129);
            this.rbCategory.Name = "rbCategory";
            this.rbCategory.Size = new System.Drawing.Size(117, 17);
            this.rbCategory.TabIndex = 2;
            this.rbCategory.TabStop = true;
            this.rbCategory.Text = "Search by category";
            this.rbCategory.UseVisualStyleBackColor = true;
            this.rbCategory.Click += new System.EventHandler(this.rbCategory_Click);
            // 
            // rbPostcode
            // 
            this.rbPostcode.AutoSize = true;
            this.rbPostcode.Location = new System.Drawing.Point(32, 174);
            this.rbPostcode.Name = "rbPostcode";
            this.rbPostcode.Size = new System.Drawing.Size(120, 17);
            this.rbPostcode.TabIndex = 3;
            this.rbPostcode.TabStop = true;
            this.rbPostcode.Text = "Search by postcode";
            this.rbPostcode.UseVisualStyleBackColor = true;
            this.rbPostcode.Click += new System.EventHandler(this.rbPostcode_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(241, 82);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(170, 21);
            this.cbCategory.TabIndex = 5;
            this.cbCategory.Visible = false;
            // 
            // lbCategory
            // 
            this.lbCategory.FormattingEnabled = true;
            this.lbCategory.Location = new System.Drawing.Point(417, 84);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(20, 17);
            this.lbCategory.TabIndex = 7;
            this.lbCategory.Visible = false;
            // 
            // frmSearchCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 229);
            this.Controls.Add(this.lbCategory);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.rbPostcode);
            this.Controls.Add(this.rbCategory);
            this.Controls.Add(this.rbLast);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearchCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Customers";
            this.Load += new System.EventHandler(this.frmSearchCustomers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbLast;
        private System.Windows.Forms.RadioButton rbCategory;
        private System.Windows.Forms.RadioButton rbPostcode;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ListBox lbCategory;
    }
}