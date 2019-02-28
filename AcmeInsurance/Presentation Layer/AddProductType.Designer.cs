namespace AcmeInsurance.Presentation_Layer
{
    partial class frmAddProductType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddProductType));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblProductTypeID = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.txtProductTypeID = new System.Windows.Forms.TextBox();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(237, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(144, 156);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(49, 156);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblProductTypeID
            // 
            this.lblProductTypeID.AutoSize = true;
            this.lblProductTypeID.Location = new System.Drawing.Point(35, 48);
            this.lblProductTypeID.Name = "lblProductTypeID";
            this.lblProductTypeID.Size = new System.Drawing.Size(88, 13);
            this.lblProductTypeID.TabIndex = 0;
            this.lblProductTypeID.Text = "Product Type ID:";
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(35, 100);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(74, 13);
            this.lblProductType.TabIndex = 2;
            this.lblProductType.Text = "Product Type:";
            // 
            // txtProductTypeID
            // 
            this.txtProductTypeID.Enabled = false;
            this.txtProductTypeID.Location = new System.Drawing.Point(162, 44);
            this.txtProductTypeID.Name = "txtProductTypeID";
            this.txtProductTypeID.Size = new System.Drawing.Size(172, 20);
            this.txtProductTypeID.TabIndex = 1;
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(162, 96);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(172, 20);
            this.txtProductType.TabIndex = 3;
            // 
            // frmAddProductType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 202);
            this.Controls.Add(this.txtProductType);
            this.Controls.Add(this.txtProductTypeID);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.lblProductTypeID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddProductType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update Product Type";
            this.Load += new System.EventHandler(this.frmAddProductType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblProductTypeID;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.TextBox txtProductTypeID;
        private System.Windows.Forms.TextBox txtProductType;
    }
}