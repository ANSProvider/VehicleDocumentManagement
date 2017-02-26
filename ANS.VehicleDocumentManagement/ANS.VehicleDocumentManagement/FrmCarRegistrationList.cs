using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using ANS.VehicleDocumentManagement.BL;

namespace ANS.VehicleDocumentManagement
{
    public partial class FrmCarRegistrationList : Form
    {
        SqlConnectionStringBuilder cSqlConnectionString = new SqlConnectionStringBuilder();
        List<CarRegistration> cAllCarRegistration = null;
        public FrmCarRegistrationList()
        {
            InitializeComponent();
            cSqlConnectionString.ConnectionString = ANSSetting.Current.GetConnectionString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CarRegistration cCarRegistration = new CarRegistration(cSqlConnectionString);
            cCarRegistration.FilterCarRegistrationNo = txtCarRegistrationNo.Text;
            cCarRegistration.FilterCustomerName =txtCustomerName.Text;
            cAllCarRegistration = cCarRegistration.Load();
            radGridView1.DataSource = cAllCarRegistration;


            radGridView1.Columns["FilterCarRegistrationID"].IsVisible = false;
            radGridView1.Columns["CarRegistrationID"].IsVisible = false;
            radGridView1.Columns["FilterCarRegistrationNo"].IsVisible = false;
            radGridView1.Columns["FilterCustomerID"].IsVisible = false;
            radGridView1.Columns["CustomerID"].IsVisible = false;
            radGridView1.Columns["FilterCustomerName"].IsVisible = false;

            radGridView1.Columns["CarCustomerDetails"].IsVisible = false;

            radGridView1.Columns["connectionString"].IsVisible = false;
            radGridView1.Columns["CreatedOn"].IsVisible = false;
            radGridView1.Columns["UpdateOn"].IsVisible = false;

            radGridView1.Columns["CarCustomerName"].HeaderText = "Customer Name";
            radGridView1.Columns["CarRegistrationNo"].HeaderText = "Registration No";
            radGridView1.Columns["DateOfRegistration"].HeaderText = "Date Of Reg.";
            radGridView1.Columns["DateOfRegistration"].DataType = typeof(DateTime);
            radGridView1.Columns["DateOfRegistration"].FormatString = "{0:dd/MMM/yyyy}";
            radGridView1.Columns["DateOfRegistration"].DataSourceNullValue = DateTime.Now.Date;



            radGridView1.Columns["ChasissNo"].HeaderText = "Chasiss No";
            radGridView1.Columns["EngineNo"].HeaderText = "Engine No";
            radGridView1.Columns["MakerName"].HeaderText = "Maker Name";

            radGridView1.Columns["Model"].HeaderText = "Model";
            radGridView1.Columns["MfgMonYear"].HeaderText = "Mfg Month Year";
            radGridView1.Columns["Type"].HeaderText = "Type";
            radGridView1.Columns["RTOName"].HeaderText = "RTO Name";

        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmCarRegistrationDetails frmCarRegistrationDetails = new FrmCarRegistrationDetails();
            if (radGridView1.SelectedRows.Count > 0)
            {
                frmCarRegistrationDetails.customerDetails = cAllCarRegistration.Where(e1 => e1.CarRegistrationID == Convert.ToInt64(radGridView1.SelectedRows[0].Cells["CarRegistrationID"].Value)).FirstOrDefault().CarCustomerDetails;
                frmCarRegistrationDetails.ShowDialog();
                btnSearch_Click(null, null);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmCarRegistrationDetails frmCarRegistrationDetails = new FrmCarRegistrationDetails();
            frmCarRegistrationDetails.Mode = "Edit";
            if (radGridView1.SelectedRows.Count > 0)
            {
                frmCarRegistrationDetails.customerDetails= cAllCarRegistration.Where(e1 => e1.CarRegistrationID == Convert.ToInt64(radGridView1.SelectedRows[0].Cells["CarRegistrationID"].Value)).FirstOrDefault().CarCustomerDetails;
                frmCarRegistrationDetails.CarRegistrationID = Convert.ToInt64(radGridView1.SelectedRows[0].Cells["CarRegistrationID"].Value);
                frmCarRegistrationDetails.ShowDialog();
                btnSearch_Click(null, null);
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (radGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this record", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    Int32 CarRegistrationID = Convert.ToInt16(radGridView1.SelectedRows[0].Cells["CarRegistrationID"].Value.ToString());
                    PetaPoco.Database cdata = new PetaPoco.Database(cSqlConnectionString.ConnectionString, "System.Data.SqlClient");
                    cdata.Execute("DELETE FROM tblCarDocumentDetails where CarRegistrationID=" + CarRegistrationID + " ; DELETE FROM tblCarRegistration where CarRegistrationID=" + CarRegistrationID + " ;");
                    btnSearch_Click(sender, e);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddDocuments_Click(object sender, EventArgs e)
        {
            FrmCarDocumentDetails frmCarDocumentDetails = new FrmCarDocumentDetails();
            frmCarDocumentDetails.Mode = "Edit";
            if (radGridView1.SelectedRows.Count > 0)
            {
                frmCarDocumentDetails.carRegistration = cAllCarRegistration.Where(e1 => e1.CarRegistrationID == Convert.ToInt64(radGridView1.SelectedRows[0].Cells["CarRegistrationID"].Value)).FirstOrDefault();
                frmCarDocumentDetails.ShowDialog();
            }
        }

    }
}