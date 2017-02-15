namespace ANS.VehicleDocumentManagement
{
    partial class FrmCarDocumentDetails
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
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn3 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarDocumentDetails));
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEmailIdVal = new System.Windows.Forms.Label();
            this.lblMobileNoVal = new System.Windows.Forms.Label();
            this.lblCustomerNameVal = new System.Windows.Forms.Label();
            this.lblContactPersonVal = new System.Windows.Forms.Label();
            this.lblEmailId = new System.Windows.Forms.Label();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.Black;
            this.lblHeaderTitle.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(964, 41);
            this.lblHeaderTitle.TabIndex = 33;
            this.lblHeaderTitle.Text = "Car Document Details Form";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblEmailIdVal);
            this.panel1.Controls.Add(this.lblMobileNoVal);
            this.panel1.Controls.Add(this.lblCustomerNameVal);
            this.panel1.Controls.Add(this.lblContactPersonVal);
            this.panel1.Controls.Add(this.lblEmailId);
            this.panel1.Controls.Add(this.lblMobileNo);
            this.panel1.Controls.Add(this.lblContactNo);
            this.panel1.Controls.Add(this.lblCustomerName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 92);
            this.panel1.TabIndex = 34;
            // 
            // lblEmailIdVal
            // 
            this.lblEmailIdVal.AutoSize = true;
            this.lblEmailIdVal.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblEmailIdVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblEmailIdVal.Location = new System.Drawing.Point(630, 56);
            this.lblEmailIdVal.Name = "lblEmailIdVal";
            this.lblEmailIdVal.Size = new System.Drawing.Size(0, 17);
            this.lblEmailIdVal.TabIndex = 17;
            // 
            // lblMobileNoVal
            // 
            this.lblMobileNoVal.AutoSize = true;
            this.lblMobileNoVal.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblMobileNoVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblMobileNoVal.Location = new System.Drawing.Point(148, 56);
            this.lblMobileNoVal.Name = "lblMobileNoVal";
            this.lblMobileNoVal.Size = new System.Drawing.Size(0, 17);
            this.lblMobileNoVal.TabIndex = 16;
            // 
            // lblCustomerNameVal
            // 
            this.lblCustomerNameVal.AutoSize = true;
            this.lblCustomerNameVal.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblCustomerNameVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblCustomerNameVal.Location = new System.Drawing.Point(148, 20);
            this.lblCustomerNameVal.Name = "lblCustomerNameVal";
            this.lblCustomerNameVal.Size = new System.Drawing.Size(0, 17);
            this.lblCustomerNameVal.TabIndex = 15;
            // 
            // lblContactPersonVal
            // 
            this.lblContactPersonVal.AutoSize = true;
            this.lblContactPersonVal.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblContactPersonVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblContactPersonVal.Location = new System.Drawing.Point(630, 20);
            this.lblContactPersonVal.Name = "lblContactPersonVal";
            this.lblContactPersonVal.Size = new System.Drawing.Size(0, 17);
            this.lblContactPersonVal.TabIndex = 14;
            // 
            // lblEmailId
            // 
            this.lblEmailId.AutoSize = true;
            this.lblEmailId.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblEmailId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblEmailId.Location = new System.Drawing.Point(490, 56);
            this.lblEmailId.Name = "lblEmailId";
            this.lblEmailId.Size = new System.Drawing.Size(53, 17);
            this.lblEmailId.TabIndex = 13;
            this.lblEmailId.Text = "Email Id";
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblMobileNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblMobileNo.Location = new System.Drawing.Point(27, 56);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(66, 17);
            this.lblMobileNo.TabIndex = 9;
            this.lblMobileNo.Text = "Mobile No";
            // 
            // lblContactNo
            // 
            this.lblContactNo.AutoSize = true;
            this.lblContactNo.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblContactNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblContactNo.Location = new System.Drawing.Point(490, 20);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(93, 17);
            this.lblContactNo.TabIndex = 7;
            this.lblContactNo.Text = "Contact Person";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblCustomerName.Location = new System.Drawing.Point(27, 20);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(99, 17);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 436);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(964, 54);
            this.panel2.TabIndex = 35;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(117)))), ((int)(((byte)(220)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Location = new System.Drawing.Point(655, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 26);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Location = new System.Drawing.Point(866, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 26);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(964, 303);
            this.panel3.TabIndex = 36;
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.SystemColors.Control;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 0);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FieldName = "DocumentId";
            gridViewComboBoxColumn1.HeaderText = "Document Name";
            gridViewComboBoxColumn1.Name = "gvCboDocumentId";
            gridViewComboBoxColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewComboBoxColumn1.Width = 189;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDate;
            gridViewDateTimeColumn1.FieldName = "IssueDate";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            gridViewDateTimeColumn1.FormatString = "{0: dd/MM/yyyy}";
            gridViewDateTimeColumn1.HeaderText = "Issue Date";
            gridViewDateTimeColumn1.Name = "IssueDate";
            gridViewDateTimeColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDateTimeColumn1.Width = 189;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Validity";
            gridViewTextBoxColumn1.HeaderText = "Validity";
            gridViewTextBoxColumn1.Name = "Validity";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn1.Width = 189;
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDate;
            gridViewDateTimeColumn2.FieldName = "ExpireDate";
            gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            gridViewDateTimeColumn2.FormatString = "{0: dd/MM/yyyy}";
            gridViewDateTimeColumn2.HeaderText = "Expiry Date";
            gridViewDateTimeColumn2.Name = "ExpireDate";
            gridViewDateTimeColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDateTimeColumn2.Width = 189;
            gridViewDateTimeColumn3.EnableExpressionEditor = false;
            gridViewDateTimeColumn3.ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDate;
            gridViewDateTimeColumn3.FieldName = "RenewDate";
            gridViewDateTimeColumn3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            gridViewDateTimeColumn3.FormatString = "{0: dd/MM/yyyy}";
            gridViewDateTimeColumn3.HeaderText = "Renew Date";
            gridViewDateTimeColumn3.Name = "RenewDate";
            gridViewDateTimeColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDateTimeColumn3.Width = 191;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewComboBoxColumn1,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn1,
            gridViewDateTimeColumn2,
            gridViewDateTimeColumn3});
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            sortDescriptor1.PropertyName = "gvCboDocumentId";
            sortDescriptor2.PropertyName = "gvCboProductId";
            this.radGridView1.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1,
            sortDescriptor2});
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.radGridView1.RootElement.AccessibleDescription = null;
            this.radGridView1.RootElement.AccessibleName = null;
            this.radGridView1.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 240, 150);
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(964, 303);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.Text = "S";
            // 
            // FrmCarDocumentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 490);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHeaderTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCarDocumentDetails";
            this.Text = "Car Document Details";
            this.Load += new System.EventHandler(this.FrmCarDocumentDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Label lblCustomerName;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        internal System.Windows.Forms.Label lblContactNo;
        internal System.Windows.Forms.Label lblMobileNo;
        internal System.Windows.Forms.Label lblEmailId;
        internal System.Windows.Forms.Label lblCustomerNameVal;
        internal System.Windows.Forms.Label lblContactPersonVal;
        internal System.Windows.Forms.Label lblMobileNoVal;
        internal System.Windows.Forms.Label lblEmailIdVal;
    }
}