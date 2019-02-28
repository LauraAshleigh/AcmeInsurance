namespace AcmeInsurance
{
    partial class frmAddCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddCustomer));
            this.gbCustomerDetails = new System.Windows.Forms.GroupBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lbCategoryID = new System.Windows.Forms.ListBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.gbCustomerAddress = new System.Windows.Forms.GroupBox();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.txtSuburb = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPostcode = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblSuburb = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbCustomerDetails.SuspendLayout();
            this.gbCustomerAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCustomerDetails
            // 
            this.gbCustomerDetails.Controls.Add(this.cbCategory);
            this.gbCustomerDetails.Controls.Add(this.lbCategoryID);
            this.gbCustomerDetails.Controls.Add(this.dtpBirthDate);
            this.gbCustomerDetails.Controls.Add(this.rbFemale);
            this.gbCustomerDetails.Controls.Add(this.rbMale);
            this.gbCustomerDetails.Controls.Add(this.txtLastName);
            this.gbCustomerDetails.Controls.Add(this.txtFirstName);
            this.gbCustomerDetails.Controls.Add(this.txtCustomerID);
            this.gbCustomerDetails.Controls.Add(this.lblBirthDate);
            this.gbCustomerDetails.Controls.Add(this.lblGender);
            this.gbCustomerDetails.Controls.Add(this.lblCategory);
            this.gbCustomerDetails.Controls.Add(this.lblCustomerID);
            this.gbCustomerDetails.Controls.Add(this.lblLastName);
            this.gbCustomerDetails.Controls.Add(this.lblFirstName);
            this.gbCustomerDetails.Location = new System.Drawing.Point(12, 56);
            this.gbCustomerDetails.Name = "gbCustomerDetails";
            this.gbCustomerDetails.Size = new System.Drawing.Size(301, 262);
            this.gbCustomerDetails.TabIndex = 0;
            this.gbCustomerDetails.TabStop = false;
            this.gbCustomerDetails.Text = "Customer Details";
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(93, 147);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(121, 21);
            this.cbCategory.TabIndex = 7;
            // 
            // lbCategoryID
            // 
            this.lbCategoryID.FormattingEnabled = true;
            this.lbCategoryID.Location = new System.Drawing.Point(235, 151);
            this.lbCategoryID.Name = "lbCategoryID";
            this.lbCategoryID.Size = new System.Drawing.Size(10, 17);
            this.lbCategoryID.TabIndex = 13;
            this.lbCategoryID.Visible = false;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CustomFormat = "yyyy-MM-dd";
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.Location = new System.Drawing.Point(93, 221);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(121, 20);
            this.dtpBirthDate.TabIndex = 12;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(155, 185);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(59, 17);
            this.rbFemale.TabIndex = 10;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(93, 186);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(48, 17);
            this.rbMale.TabIndex = 9;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(93, 109);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(121, 20);
            this.txtLastName.TabIndex = 5;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(93, 71);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(121, 20);
            this.txtFirstName.TabIndex = 3;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Enabled = false;
            this.txtCustomerID.Location = new System.Drawing.Point(93, 33);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(121, 20);
            this.txtCustomerID.TabIndex = 1;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(9, 227);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(57, 13);
            this.lblBirthDate.TabIndex = 11;
            this.lblBirthDate.Text = "Birth Date:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(9, 189);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 8;
            this.lblGender.Text = "Gender:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(9, 151);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Category:";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(9, 37);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(68, 13);
            this.lblCustomerID.TabIndex = 0;
            this.lblCustomerID.Text = "Customer ID:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(9, 113);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(9, 75);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name:";
            // 
            // gbCustomerAddress
            // 
            this.gbCustomerAddress.Controls.Add(this.txtPostcode);
            this.gbCustomerAddress.Controls.Add(this.cbState);
            this.gbCustomerAddress.Controls.Add(this.txtSuburb);
            this.gbCustomerAddress.Controls.Add(this.txtAddress);
            this.gbCustomerAddress.Controls.Add(this.lblPostcode);
            this.gbCustomerAddress.Controls.Add(this.lblState);
            this.gbCustomerAddress.Controls.Add(this.lblSuburb);
            this.gbCustomerAddress.Controls.Add(this.lblAddress);
            this.gbCustomerAddress.Location = new System.Drawing.Point(350, 57);
            this.gbCustomerAddress.Name = "gbCustomerAddress";
            this.gbCustomerAddress.Size = new System.Drawing.Size(234, 202);
            this.gbCustomerAddress.TabIndex = 1;
            this.gbCustomerAddress.TabStop = false;
            this.gbCustomerAddress.Text = "Customer Address";
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(75, 141);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(121, 20);
            this.txtPostcode.TabIndex = 7;
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "NSW",
            "VIC",
            "QLD",
            "WA",
            "TAS",
            "ACT",
            "NT"});
            this.cbState.Location = new System.Drawing.Point(75, 105);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(121, 21);
            this.cbState.TabIndex = 5;
            // 
            // txtSuburb
            // 
            this.txtSuburb.Location = new System.Drawing.Point(75, 69);
            this.txtSuburb.Name = "txtSuburb";
            this.txtSuburb.Size = new System.Drawing.Size(121, 20);
            this.txtSuburb.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(75, 33);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(121, 20);
            this.txtAddress.TabIndex = 1;
            // 
            // lblPostcode
            // 
            this.lblPostcode.AutoSize = true;
            this.lblPostcode.Location = new System.Drawing.Point(13, 145);
            this.lblPostcode.Name = "lblPostcode";
            this.lblPostcode.Size = new System.Drawing.Size(55, 13);
            this.lblPostcode.TabIndex = 6;
            this.lblPostcode.Text = "Postcode:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(13, 109);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 4;
            this.lblState.Text = "State:";
            // 
            // lblSuburb
            // 
            this.lblSuburb.AutoSize = true;
            this.lblSuburb.Location = new System.Drawing.Point(13, 73);
            this.lblSuburb.Name = "lblSuburb";
            this.lblSuburb.Size = new System.Drawing.Size(44, 13);
            this.lblSuburb.TabIndex = 2;
            this.lblSuburb.Text = "Suburb:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(13, 37);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(337, 295);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(433, 295);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(529, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 351);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbCustomerAddress);
            this.Controls.Add(this.gbCustomerDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update Customer";
            this.Load += new System.EventHandler(this.frmAddCustomer_Load);
            this.gbCustomerDetails.ResumeLayout(false);
            this.gbCustomerDetails.PerformLayout();
            this.gbCustomerAddress.ResumeLayout(false);
            this.gbCustomerAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCustomerDetails;
        private System.Windows.Forms.GroupBox gbCustomerAddress;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.TextBox txtPostcode;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.TextBox txtSuburb;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPostcode;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblSuburb;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ListBox lbCategoryID;
        private System.Windows.Forms.ComboBox cbCategory;
    }
}