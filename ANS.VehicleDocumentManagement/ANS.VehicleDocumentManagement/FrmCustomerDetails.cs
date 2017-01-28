using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ANS.VehicleDocumentManagement.BL;

namespace ANS.VehicleDocumentManagement
{
    public partial class FrmCustomerDetails : Form
    {
        public Int64 CustomerID { get; set; }
        public string Mode { get; set; }
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
                txtBillNo.Text = cCustomerDetails.CustomerName.ToString();
                txtBillNo.Enabled = false;
                           //  if (cCustomerDetails.Discount > 0)
                    txtDiscount.Text = cCustomerDetails.CurrentAddress.ToString();

               // if (cCustomerDetails.DiscountAmount > 0)
                    txtDiscountAmt.Text = cCustomerDetails.ContactPerson.ToString();

                txtCustomerName.Text = cCustomerDetails.CustomerName;
                txtContactNo.Text = cCustomerDetails.PermantAddress;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerDetails cCustomerDetails = new CustomerDetails(cSqlConnectionString);
            SaveData(cCustomerDetails);
            MessageBox.Show("Data Saved Successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveData(CustomerDetails cCustomerDetails)
        {
            if (Mode == "Edit")
            {
                cCustomerDetails.CustomerID = Convert.ToInt16(CustomerID);
            }

            cCustomerDetails.ContactPerson = txtBillNo.Text;
            
            cCustomerDetails.CustomerName = txtCustomerName.Text;
          
            cCustomerDetails.Save();
            Database cDbConnection = new Database(cSqlConnectionString.ConnectionString, "System.Data.SqlClient");

        }



    }
}
