using PetaPoco;
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
    public partial class FrmCarRegistrationDetails : Form
    {
        public String Mode { get; set; }
        public CustomerDetails customerDetails { get; set; }
        public Int64 CarRegistrationID { get; set; }
        public FrmCarRegistrationDetails()
        {
            InitializeComponent();
            cSqlConnectionString.ConnectionString = ANSSetting.Current.GetConnectionString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<CarRegistration> mList = new List<CarRegistration>();
        SqlConnectionStringBuilder cSqlConnectionString = new SqlConnectionStringBuilder();
        private void FrmCarRegistrationDetails_Load(object sender, EventArgs e)
        {
            DispalyCustomerDeatils();
            EditRecord();
            radGridView1.AutoGenerateColumns = false;
            radGridView1.DataSource = mList;
        }

        private void DispalyCustomerDeatils()
        {
            if (customerDetails != null)
            {
                lblContactPersonVal.Text = customerDetails.ContactPerson;
                lblCustomerNameVal.Text = customerDetails.CustomerName;
                lblMobileNoVal.Text = customerDetails.MobileNo;
                lblEmailIdVal.Text = customerDetails.EmailId;
            }
        }


        private void EditRecord()
        {
            if (Mode == "Edit")
            {
                CarRegistration cCarRegistration = new CarRegistration(cSqlConnectionString);

                if (customerDetails != null)
                    cCarRegistration.FilterCustomerID = customerDetails.CustomerID;

                if (CarRegistrationID > 0)
                    cCarRegistration.FilterCarRegistrationID = CarRegistrationID;
                mList = cCarRegistration.Load();
                radGridView1.DataSource = mList;

            }
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
                item.CustomerID = customerDetails.CustomerID;
                item.UpdateOn = DateTime.Now;
                if (item.CarRegistrationID == 0)
                {
                    item.CreatedOn = DateTime.Now;
                }
                item.Save();
            }
        }

        private void btnAddDocuments_Click(object sender, EventArgs e)
        {
            FrmCarDocumentDetails frmCarDocumentDetails = new FrmCarDocumentDetails();
            frmCarDocumentDetails.Mode = "Edit";
            if (radGridView1.SelectedRows.Count > 0)
            {
                frmCarDocumentDetails.carRegistration = mList.Where(e1 => e1.CarRegistrationID == Convert.ToInt64(radGridView1.SelectedRows[0].Cells["CarRegistrationID"].Value)).FirstOrDefault();
                frmCarDocumentDetails.ShowDialog();
            }
        }


    }
}
