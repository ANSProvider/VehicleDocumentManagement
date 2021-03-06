﻿using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ANS.VehicleDocumentManagement.BL;

namespace ANS.VehicleDocumentManagement
{
    public partial class FrmCarDocumentDetails : Form
    {
        public String Mode { get; set; }
        public CarRegistration carRegistration { get; set; }
        public List<DocumentMaster> cListDocumentMaster = null;
        public FrmCarDocumentDetails()
        {
            InitializeComponent();
            cSqlConnectionString.ConnectionString = ANSSetting.Current.GetConnectionString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<CarDocumentDetails> mList = new List<CarDocumentDetails>();
        SqlConnectionStringBuilder cSqlConnectionString = new SqlConnectionStringBuilder();
        private void FrmCarDocumentDetails_Load(object sender, EventArgs e)
        {
            FillDocument();
            DispalyCarRegistrationDeatils();
            EditRecord();
            radGridView1.AutoGenerateColumns = false;
            radGridView1.DataSource = mList;
        }

        private void DispalyCarRegistrationDeatils()
        {
            if (carRegistration != null && carRegistration.CarCustomerDetails != null)
            {
                lblContactPersonVal.Text = carRegistration.CarCustomerDetails.ContactPerson;
                lblCustomerNameVal.Text = carRegistration.CarCustomerDetails.CustomerName;
                lblMobileNoVal.Text = carRegistration.CarCustomerDetails.MobileNo;
                lblEmailIdVal.Text = carRegistration.CarCustomerDetails.EmailId;
                lblCarRegisterationNoVal.Text = carRegistration.CarRegistrationNo;
                lblDateOfRegVal.Text = carRegistration.DateOfRegistration.ToString("dd/MMM/yyyy");
            }
        }

        private void FillDocument()
        {
            GridViewComboBoxColumn mGridViewComboBoxColumn = (GridViewComboBoxColumn)radGridView1.Columns["gvCboDocumentId"];
            DocumentMaster cDocumentMaster = new DocumentMaster(cSqlConnectionString);
            cListDocumentMaster = cDocumentMaster.Load();
            mGridViewComboBoxColumn.DataSource = cListDocumentMaster;
            mGridViewComboBoxColumn.DisplayMember = "DocumentName";
            mGridViewComboBoxColumn.ValueMember = "DocumentID";
        }

        private void EditRecord()
        {
            if (Mode == "Edit")
            {
                CarDocumentDetails cCarDocumentDetails = new CarDocumentDetails(cSqlConnectionString);
                cCarDocumentDetails.FilterCarRegistrationID = carRegistration.CarRegistrationID;
                mList = cCarDocumentDetails.Load();
                radGridView1.DataSource = mList;
                FillData();
            }
        }

        private void FillData()
        {
            //foreach (var item in radGridView1.Rows)
            //{
            //    CustomerDetails cproductMaster = cListProductMaster.Where(e1 => e1.ProductID == Convert.ToInt64(item.Cells["gvCboProductId"].Value)).FirstOrDefault();

            //    item.Cells["PricePerUnit"].Value = cproductMaster.SalePrice;
            //    item.Cells["Amount"].Value = Convert.ToInt64(item.Cells["gvProductQuantity"].Value) * cproductMaster.SalePrice;
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Data Saved Successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveData()
        {
            Database cDbConnection = new Database(cSqlConnectionString.ConnectionString, "System.Data.SqlClient");
            foreach (var item in mList)
            {
                item.cDbConnection = cDbConnection;
                item.CarRegistrationID = carRegistration.CarRegistrationID;
                item.UpdateOn = DateTime.Now;
                if (item.CarDocumentDetailID == 0)
                {
                    item.CreatedOn = DateTime.Now;
                }
                item.Save();
            }
        }

        private void radGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DocumentMaster cDocumentMaster = cListDocumentMaster.Where(e1 => e1.DocumentId == Convert.ToInt64(e.Value)).FirstOrDefault();
                e.Row.Cells["Validity"].Value = cDocumentMaster.ValiditiyMonth;

                if (e.Row.Cells["IssueDate"].Value == null)
                {
                    e.Row.Cells["IssueDate"].Value = DateTime.Now.Date;
                }
                if (e.Row.Cells["IssueDate"].Value != null && !string.IsNullOrEmpty(e.Row.Cells["IssueDate"].Value.ToString()))
                {
                    e.Row.Cells["ExpireDate"].Value = Convert.ToDateTime(e.Row.Cells["IssueDate"].Value.ToString()).AddMonths(Convert.ToInt32(e.Row.Cells["Validity"].Value));
                }

                if (e.Row.Cells["ExpireDate"].Value != null && !string.IsNullOrEmpty(e.Row.Cells["ExpireDate"].Value.ToString()))
                {
                    e.Row.Cells["RenewDate"].Value = Convert.ToDateTime(e.Row.Cells["ExpireDate"].Value.ToString()).AddDays(1);
                }


            }
            else if (e.ColumnIndex == 3)
            {
             
                if (e.Row.Cells["ExpireDate"].Value != null && !string.IsNullOrEmpty(e.Row.Cells["ExpireDate"].Value.ToString()))
                {
                    e.Row.Cells["RenewDate"].Value = Convert.ToDateTime(e.Row.Cells["ExpireDate"].Value.ToString()).AddDays(1);
                }

            }
            else
            {
                if (e.Row.Cells["IssueDate"].Value != null && !string.IsNullOrEmpty(e.Row.Cells["IssueDate"].Value.ToString()))
                {
                    e.Row.Cells["ExpireDate"].Value = Convert.ToDateTime(e.Row.Cells["IssueDate"].Value.ToString()).AddMonths(Convert.ToInt32(e.Row.Cells["Validity"].Value));
                }

                if (e.Row.Cells["ExpireDate"].Value != null && !string.IsNullOrEmpty(e.Row.Cells["ExpireDate"].Value.ToString()))
                {
                    e.Row.Cells["RenewDate"].Value = Convert.ToDateTime(e.Row.Cells["ExpireDate"].Value.ToString()).AddDays(1);
                }
            }


        }


    }
}
