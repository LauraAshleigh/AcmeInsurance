namespace AcmeInsurance.Presentation_Layer
{
    partial class frmAddSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSale));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblPayable = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.txtSaleID = new System.Windows.Forms.TextBox();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.rbFortnightly = new System.Windows.Forms.RadioButton();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.rbYearly = new System.Windows.Forms.RadioButton();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblSaleID = new System.Windows.Forms.Label();
            this.lbCustomerID = new System.Windows.Forms.ListBox();
            this.lbProductID = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(268, 263);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(175, 263);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(80, 263);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(28, 80);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Customer:";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(28, 122);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(47, 13);
            this.lblProduct.TabIndex = 4;
            this.lblProduct.Text = "Product:";
            // 
            // lblPayable
            // 
            this.lblPayable.AutoSize = true;
            this.lblPayable.Location = new System.Drawing.Point(28, 164);
            this.lblPayable.Name = "lblPayable";
            this.lblPayable.Size = new System.Drawing.Size(48, 13);
            this.lblPayable.TabIndex = 6;
            this.lblPayable.Text = "Payable:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(28, 206);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 10;
            this.lblStartDate.Text = "Start Date:";
            // 
            // txtSaleID
            // 
            this.txtSaleID.Enabled = false;
            this.txtSaleID.Location = new System.Drawing.Point(133, 34);
            this.txtSaleID.Name = "txtSaleID";
            this.txtSaleID.Size = new System.Drawing.Size(245, 20);
            this.txtSaleID.TabIndex = 1;
            // 
            // cbCustomer
            // 
            this.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(133, 76);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(245, 21);
            this.cbCustomer.TabIndex = 3;
            // 
            // cbProduct
            // 
            this.cbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(133, 118);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(245, 21);
            this.cbProduct.TabIndex = 5;
            // 
            // rbFortnightly
            // 
            this.rbFortnightly.AutoSize = true;
            this.rbFortnightly.Location = new System.Drawing.Point(133, 162);
            this.rbFortnightly.Name = "rbFortnightly";
            this.rbFortnightly.Size = new System.Drawing.Size(73, 17);
            this.rbFortnightly.TabIndex = 7;
            this.rbFortnightly.TabStop = true;
            this.rbFortnightly.Text = "Fortnightly";
            this.rbFortnightly.UseVisualStyleBackColor = true;
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Location = new System.Drawing.Point(234, 162);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(62, 17);
            this.rbMonthly.TabIndex = 8;
            this.rbMonthly.TabStop = true;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = true;
            // 
            // rbYearly
            // 
            this.rbYearly.AutoSize = true;
            this.rbYearly.Location = new System.Drawing.Point(324, 164);
            this.rbYearly.Name = "rbYearly";
            this.rbYearly.Size = new System.Drawing.Size(54, 17);
            this.rbYearly.TabIndex = 9;
            this.rbYearly.TabStop = true;
            this.rbYearly.Text = "Yearly";
            this.rbYearly.UseVisualStyleBackColor = true;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(133, 202);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(93, 20);
            this.dtpStartDate.TabIndex = 11;
            // 
            // lblSaleID
            // 
            this.lblSaleID.AutoSize = true;
            this.lblSaleID.Location = new System.Drawing.Point(28, 38);
            this.lblSaleID.Name = "lblSaleID";
            this.lblSaleID.Size = new System.Drawing.Size(45, 13);
            this.lblSaleID.TabIndex = 0;
            this.lblSaleID.Text = "Sale ID:";
            // 
            // lbCustomerID
            // 
            this.lbCustomerID.FormattingEnabled = true;
            this.lbCustomerID.Location = new System.Drawing.Point(404, 80);
            this.lbCustomerID.Name = "lbCustomerID";
            this.lbCustomerID.Size = new System.Drawing.Size(10, 17);
            this.lbCustomerID.TabIndex = 15;
            this.lbCustomerID.Visible = false;
            // 
            // lbProductID
            // 
            this.lbProductID.FormattingEnabled = true;
            this.lbProductID.Location = new System.Drawing.Point(404, 122);
            this.lbProductID.Name = "lbProductID";
            this.lbProductID.Size = new System.Drawing.Size(10, 17);
            this.lbProductID.TabIndex = 16;
            this.lbProductID.Visible = false;
            // 
            // frmAddSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 318);
            this.Controls.Add(this.lbProductID);
            this.Controls.Add(this.lbCustomerID);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.rbYearly);
            this.Controls.Add(this.rbMonthly);
            this.Controls.Add(this.rbFortnightly);
            this.Controls.Add(this.cbProduct);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.txtSaleID);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblPayable);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblSaleID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update Sale";
            this.Load += new System.EventHandler(this.frmAddSale_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblPayable;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.TextBox txtSaleID;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.RadioButton rbFortnightly;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.RadioButton rbYearly;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblSaleID;
        private System.Windows.Forms.ListBox lbCustomerID;
        private System.Windows.Forms.ListBox lbProductID;
    }
}