namespace AcmeInsurance.Presentation_Layer
{
    partial class frmSearchSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchSales));
            this.lbProduct = new System.Windows.Forms.ListBox();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.rbProduct = new System.Windows.Forms.RadioButton();
            this.rbCustomer = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lbProduct
            // 
            this.lbProduct.FormattingEnabled = true;
            this.lbProduct.Location = new System.Drawing.Point(456, 78);
            this.lbProduct.Name = "lbProduct";
            this.lbProduct.Size = new System.Drawing.Size(20, 17);
            this.lbProduct.TabIndex = 8;
            this.lbProduct.Visible = false;
            // 
            // cbProduct
            // 
            this.cbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(238, 74);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(212, 21);
            this.cbProduct.TabIndex = 5;
            this.cbProduct.Visible = false;
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Location = new System.Drawing.Point(29, 166);
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(120, 17);
            this.rbDate.TabIndex = 3;
            this.rbDate.TabStop = true;
            this.rbDate.Text = "Search by start date";
            this.rbDate.UseVisualStyleBackColor = true;
            this.rbDate.Click += new System.EventHandler(this.rbDate_Click);
            // 
            // rbProduct
            // 
            this.rbProduct.AutoSize = true;
            this.rbProduct.Location = new System.Drawing.Point(29, 121);
            this.rbProduct.Name = "rbProduct";
            this.rbProduct.Size = new System.Drawing.Size(112, 17);
            this.rbProduct.TabIndex = 2;
            this.rbProduct.TabStop = true;
            this.rbProduct.Text = "Search by product";
            this.rbProduct.UseVisualStyleBackColor = true;
            this.rbProduct.Click += new System.EventHandler(this.rbProduct_Click);
            // 
            // rbCustomer
            // 
            this.rbCustomer.AutoSize = true;
            this.rbCustomer.Location = new System.Drawing.Point(29, 76);
            this.rbCustomer.Name = "rbCustomer";
            this.rbCustomer.Size = new System.Drawing.Size(167, 17);
            this.rbCustomer.TabIndex = 1;
            this.rbCustomer.TabStop = true;
            this.rbCustomer.Text = "Search by customer last name";
            this.rbCustomer.UseVisualStyleBackColor = true;
            this.rbCustomer.Click += new System.EventHandler(this.rbCustomer_Click);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(29, 31);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(79, 17);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "List all rows";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.Click += new System.EventHandler(this.rbAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(375, 166);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(238, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(212, 20);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.Visible = false;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(238, 121);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(102, 20);
            this.dtpStartDate.TabIndex = 6;
            this.dtpStartDate.Visible = false;
            // 
            // frmSearchSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 219);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lbProduct);
            this.Controls.Add(this.cbProduct);
            this.Controls.Add(this.rbDate);
            this.Controls.Add(this.rbProduct);
            this.Controls.Add(this.rbCustomer);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearchSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Sales";
            this.Load += new System.EventHandler(this.frmSearchSales_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbProduct;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.RadioButton rbProduct;
        private System.Windows.Forms.RadioButton rbCustomer;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
    }
}