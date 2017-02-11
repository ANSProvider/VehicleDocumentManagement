using ANS.VehicleDocumentManagement.BL;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ANS.VehicleDocumentManagement
{
    public partial class FrmCustomerDetails : Form
    {
        public Int64 CustomerID { get; set; }
        public String Mode { get; set; }
        public List<CustomerDetails> cListCustomerDetails = null;
        public FrmCustomerDetails()
        {
            InitializeComponent();
            ANSSetting.Current.GetAllSetting();
            cSqlConnectionString.ConnectionString = ANSSetting.Current.GetConnectionString();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnectionStringBuilder cSqlConnectionString = new SqlConnectionStringBuilder();
        private void FrmCustomerDetails_Load(object sender, EventArgs e)
        {
            btnRegisterCar.Visible = false;
            btnRegisterCar.Enabled = false;
            EditRecord();
        }


        private void EditRecord(CustomerDetails cCustomerDetails = null)
        {
            if (Mode == "Edit")
            {
                if (cCustomerDetails == null)
                {
                    cCustomerDetails = new CustomerDetails(cSqlConnectionString);
                    cCustomerDetails = cCustomerDetails.EditValue(CustomerID);
                }
                CustomerID = cCustomerDetails.CustomerID;
                txtCustomerName.Text = cCustomerDetails.CustomerName;
                txtCurrentAddress.Text = cCustomerDetails.CurrentAddress;
                txtPermantAddress.Text = cCustomerDetails.PermantAddress;
                txtMobileNo.Text = cCustomerDetails.MobileNo;
                txtOfficeNo.Text = cCustomerDetails.OfficeNo;
                txtEmailId.Text = cCustomerDetails.EmailId;
                txtContactPerson.Text = cCustomerDetails.ContactPerson;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerDetails cCustomerDetails = new CustomerDetails(cSqlConnectionString);
            SaveData(cCustomerDetails);
            MessageBox.Show("Data Saved Successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRegisterCar.Visible = true;
            btnRegisterCar.Enabled = true;
        }

        private void SaveData(CustomerDetails cCustomerDetails)
        {
            if (Mode == "Edit")
            {
                cCustomerDetails.CustomerID = Convert.ToInt16(CustomerID);
            }
            else
            {

                cCustomerDetails.CreatedOn = DateTime.Now;

            }


            cCustomerDetails.CustomerName = txtCustomerName.Text;
            cCustomerDetails.CurrentAddress = txtCurrentAddress.Text;
            cCustomerDetails.PermantAddress = txtPermantAddress.Text;
            cCustomerDetails.MobileNo = txtMobileNo.Text;
            cCustomerDetails.OfficeNo = txtOfficeNo.Text;
            cCustomerDetails.EmailId = txtEmailId.Text;
            cCustomerDetails.ContactPerson = txtContactPerson.Text;
            cCustomerDetails.UpdatedOn = DateTime.Now;
            cCustomerDetails.Save();
            CustomerID = cCustomerDetails.CustomerID;
          
        }

        private void btnRegisterCar_Click(object sender, EventArgs e)
        {
            FrmCarRegistrationDetails frmCarRegistrationDetails = new FrmCarRegistrationDetails();
            frmCarRegistrationDetails.Mode = "Edit";
            if (CustomerID > 0)
            {
                frmCarRegistrationDetails.CustomerId = CustomerID.ToString();
                frmCarRegistrationDetails.ShowDialog();

            }

        }
    }
}
