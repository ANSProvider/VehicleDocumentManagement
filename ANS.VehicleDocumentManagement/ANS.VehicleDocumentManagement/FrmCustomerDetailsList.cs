using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ANS.VehicleDocumentManagement
{
    public partial class FrmCustomerDetailsList : Form
    {

        SqlConnectionStringBuilder cSqlConnectionString = new SqlConnectionStringBuilder();
        public FrmCustomerDetailsList()
        {
            InitializeComponent();
            cSqlConnectionString.ConnectionString = ANSSetting.Current.GetConnectionString();
            
        }       
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            CustomerDetails cAccounts = new CustomerDetails(cSqlConnectionString);
            if (!string.IsNullOrEmpty(txtCode.Text))
                cAccounts.FilterBillNo = Convert.ToInt16(txtCode.Text);
            cAccounts.FilterCustomerName= txtName.Text;

            if (!string.IsNullOrEmpty(txtStartDate.Text )) { cAccounts.StartDate = txtStartDate.Value; }
            if (!string.IsNullOrEmpty(txtEndDate.Text)) { cAccounts.EndDate= txtEndDate.Value; }
            List<Bill> cAllAccounts = cAccounts.Load();

            if (cAllAccounts != null && cAllAccounts.Any())
                cAllAccounts=cAllAccounts.OrderByDescending(o => o.BillDate).ToList();

            radGridView1 .DataSource = cAllAccounts;
            radGridView1.Columns["FilterBillId"].IsVisible = false;
            radGridView1.Columns["BillId"].IsVisible = false;
            radGridView1.Columns["FilterBillNo"].IsVisible = false;
            radGridView1.Columns["connectionString"].IsVisible = false;
            radGridView1.Columns["FilterCustomerName"].IsVisible = false;
            radGridView1.Columns["IsCancel"].IsVisible = false;
            radGridView1.Columns["WATAmount"].IsVisible = false;
            radGridView1.Columns["StartDate"].IsVisible = false;
            radGridView1.Columns["EndDate"].IsVisible = false;


            radGridView1.Columns["CustomerName"].HeaderText = "Customer Name";
            radGridView1.Columns["BillDate"].HeaderText = "Bill Date";
            radGridView1.Columns["BillAmount"].HeaderText = "Bill Amount";
            radGridView1.Columns["IsCancel"].HeaderText = "Cancel Records";
            radGridView1.Columns["BillNo"].HeaderText = "Bill No";
            radGridView1.Columns["Discount"].HeaderText = "Discount (%)";
            radGridView1.Columns["DiscountAmount"].HeaderText = "Discount Amount";
            radGridView1.Columns["FinalAmount"].HeaderText = "Final Amount";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmCustomerDetails FrmCustomerDetails = new FrmCustomerDetails();
            FrmCustomerDetails.ShowDialog();
            btnSearch_Click(null,null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmCustomerDetails frmBill = new FrmCustomerDetails();
            frmBill.Mode = "Edit";
            if (radGridView1.SelectedRows.Count>0)
            {
                frmBill.BillId = radGridView1.SelectedRows[0].Cells["BillId"].Value.ToString();
                frmBill.ShowDialog();
                btnSearch_Click(null,null);
            }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (radGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this record","Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int billid = Convert.ToInt16(radGridView1.SelectedRows[0].Cells["BillId"].Value.ToString());
                    PetaPoco.Database cdata = new PetaPoco.Database(cSqlConnectionString.ConnectionString, "System.Data.SqlClient");
                    cdata.Execute("DELETE FROM BillDetail where Billid=" + billid + " ; DELETE FROM Bill where Billid=" + billid + " ;");
                    btnSearch_Click(sender, e);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radGridView1.SelectedRows.Count > 0)
            {
                FrmReceipt frmReceipt = new FrmReceipt();
                frmReceipt.BillId = radGridView1.SelectedRows[0].Cells["BillId"].Value.ToString();
                frmReceipt.ShowDialog();
            }
        }
    }
}