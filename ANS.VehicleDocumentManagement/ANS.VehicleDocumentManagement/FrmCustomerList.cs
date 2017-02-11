using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using ANS.VehicleDocumentManagement.BL;

namespace ANS.VehicleDocumentManagement
{
    public partial class FrmCustomerList : Form
    {

        SqlConnectionStringBuilder cSqlConnectionString = new SqlConnectionStringBuilder();
        public FrmCustomerList()
        {
            InitializeComponent();
            ANSSetting.Current.GetAllSetting();
            cSqlConnectionString.ConnectionString = ANSSetting.Current.GetConnectionString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CustomerDetails cCustomers = new CustomerDetails(cSqlConnectionString);
            cCustomers.FilterCustomerName = txtCustomerName.Text;
            List<CustomerDetails> cAllCustomers = cCustomers.Load();

            radGridView1.DataSource = cAllCustomers;
            radGridView1.Columns["FilterCustomerID"].IsVisible = false;
            radGridView1.Columns["CustomerID"].IsVisible = false;
            radGridView1.Columns["FilterCustomerName"].IsVisible = false;
            radGridView1.Columns["connectionString"].IsVisible = false;
            radGridView1.Columns["CreatedOn"].IsVisible = false;
            radGridView1.Columns["UpdatedOn"].IsVisible = false;
            radGridView1.Columns["CustomerName"].HeaderText = "Customer Name";
            radGridView1.Columns["ContactPerson"].HeaderText = "Contact Person";
            radGridView1.Columns["EmailId"].HeaderText = "Email Id";
            radGridView1.Columns["MobileNo"].HeaderText = "Mobile No";
            radGridView1.Columns["OfficeNo"].HeaderText = "Office No";
            radGridView1.Columns["CurrentAddress"].HeaderText = "Current Address";
            radGridView1.Columns["PermantAddress"].HeaderText = "Permant Address";
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmCustomerDetails frmCustomerDetails = new FrmCustomerDetails();
            frmCustomerDetails.ShowDialog();
            btnSearch_Click(null, null);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmCustomerDetails frmCustomerDetails = new FrmCustomerDetails();
            frmCustomerDetails.Mode = "Edit";
            if (radGridView1.SelectedRows.Count > 0)
            {
                frmCustomerDetails.CustomerID = Convert.ToInt64(radGridView1.SelectedRows[0].Cells["CustomerID"].Value);
                frmCustomerDetails.ShowDialog();
                btnSearch_Click(null, null);
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (radGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this record", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    Int32 CustomerID = Convert.ToInt16(radGridView1.SelectedRows[0].Cells["CustomerID"].Value.ToString());
                    PetaPoco.Database cdata = new PetaPoco.Database(cSqlConnectionString.ConnectionString, "System.Data.SqlClient");
                    cdata.Execute("DELETE FROM tblCustomerDetails where CustomerID=" + CustomerID + " ;");
                    btnSearch_Click(sender, e);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegisterCar_Click(object sender, EventArgs e)
        {
            FrmCarRegistrationDetails frmCarRegistrationDetails = new FrmCarRegistrationDetails();
            frmCarRegistrationDetails.Mode = "Edit";
            if (radGridView1.SelectedRows.Count > 0)
            {
                frmCarRegistrationDetails.CustomerId = radGridView1.SelectedRows[0].Cells["CustomerID"].Value.ToString();
                frmCarRegistrationDetails.ShowDialog();

            }
        }

       
    }
}