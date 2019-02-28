namespace AcmeInsurance.Presentation_Layer
{
    partial class frmAddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddProduct));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblProductID = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblYearlyPremium = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtYearlyPremium = new System.Windows.Forms.TextBox();
            this.cbProductType = new System.Windows.Forms.ComboBox();
            this.lbProductTypeID = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(238, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(145, 230);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(50, 230);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(33, 45);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(61, 13);
            this.lblProductID.TabIndex = 0;
            this.lblProductID.Text = "Product ID:";
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(33, 90);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(74, 13);
            this.lblProductType.TabIndex = 2;
            this.lblProductType.Text = "Product Type:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(33, 135);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(78, 13);
            this.lblProductName.TabIndex = 4;
            this.lblProductName.Text = "Product Name:";
            // 
            // lblYearlyPremium
            // 
            this.lblYearlyPremium.AutoSize = true;
            this.lblYearlyPremium.Location = new System.Drawing.Point(33, 180);
            this.lblYearlyPremium.Name = "lblYearlyPremium";
            this.lblYearlyPremium.Size = new System.Drawing.Size(82, 13);
            this.lblYearlyPremium.TabIndex = 6;
            this.lblYearlyPremium.Text = "Yearly Premium:";
            // 
            // txtProductID
            // 
            this.txtProductID.Enabled = false;
            this.txtProductID.Location = new System.Drawing.Point(128, 41);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(204, 20);
            this.txtProductID.TabIndex = 1;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(128, 131);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(204, 20);
            this.txtProductName.TabIndex = 5;
            // 
            // txtYearlyPremium
            // 
            this.txtYearlyPremium.Location = new System.Drawing.Point(128, 176);
            this.txtYearlyPremium.Name = "txtYearlyPremium";
            this.txtYearlyPremium.Size = new System.Drawing.Size(204, 20);
            this.txtYearlyPremium.TabIndex = 7;
            // 
            // cbProductType
            // 
            this.cbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductType.FormattingEnabled = true;
            this.cbProductType.Location = new System.Drawing.Point(128, 86);
            this.cbProductType.Name = "cbProductType";
            this.cbProductType.Size = new System.Drawing.Size(204, 21);
            this.cbProductType.TabIndex = 3;
            // 
            // lbProductTypeID
            // 
            this.lbProductTypeID.FormattingEnabled = true;
            this.lbProductTypeID.Location = new System.Drawing.Point(357, 90);
            this.lbProductTypeID.Name = "lbProductTypeID";
            this.lbProductTypeID.Size = new System.Drawing.Size(10, 17);
            this.lbProductTypeID.TabIndex = 11;
            this.lbProductTypeID.Visible = false;
            // 
            // frmAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 283);
            this.Controls.Add(this.lbProductTypeID);
            this.Controls.Add(this.cbProductType);
            this.Controls.Add(this.txtYearlyPremium);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.lblYearlyPremium);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update Product";
            this.Load += new System.EventHandler(this.frmAddProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblYearlyPremium;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtYearlyPremium;
        private System.Windows.Forms.ComboBox cbProductType;
        private System.Windows.Forms.ListBox lbProductTypeID;
    }
}