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
            // ShowFooter();
            //if (Mode != "Edit")
            //{
            //    Bill cBill = new Bill(cSqlConnectionString);
            //    string mStr = cBill.MaxBillNo();
            //    txtBillNo.Text = mStr;
            //}
        }

        private void DispalyCustomerDeatils()
        {
            lblContactPersonVal.Text = customerDetails.ContactPerson;
            lblCustomerNameVal.Text = customerDetails.CustomerName;
            lblMobileNoVal.Text = customerDetails.MobileNo;
            lblEmailIdVal.Text = customerDetails.EmailId;
        }
        
        //private void FillProduct()
        //{
        //    GridViewComboBoxColumn mGridViewComboBoxColumn = (GridViewComboBoxColumn)radGridView1.Columns["gvCboProductId"];
        //    ProductMaster cProductMaster = new ProductMaster(cSqlConnectionString);
        //    cListProductMaster = cProductMaster.Load();
        //    mGridViewComboBoxColumn.DataSource = cListProductMaster;
        //    mGridViewComboBoxColumn.DisplayMember = "ProductDesc";
        //    mGridViewComboBoxColumn.ValueMember = "ProductID";
        //}

        private void EditRecord()
        {
            if (Mode == "Edit")
            {
                CarRegistration cCarRegistration = new CarRegistration(cSqlConnectionString);
                cCarRegistration.FilterCustomerID = customerDetails.CustomerID;
                mList = cCarRegistration.Load();
                radGridView1.DataSource = mList;

            }
        }

        //private void FillData()
        //{
        //    foreach (var item in radGridView1.Rows)
        //    {
        //        ProductMaster cproductMaster = cListProductMaster.Where(e1 => e1.ProductID == Convert.ToInt64(item.Cells["gvCboProductId"].Value)).FirstOrDefault();
        //        Debug.WriteLine("ProductId" + cproductMaster.ProductID.ToString());
        //        item.Cells["PricePerUnit"].Value = cproductMaster.SalePrice;
        //        item.Cells["Amount"].Value = Convert.ToInt64(item.Cells["gvProductQuantity"].Value) * cproductMaster.SalePrice;
        //    }
        //}
        //public void ShowFooter()
        //{
        //    radGridView1.GroupDescriptors.Clear();
        //    radGridView1.SummaryRowsBottom.Clear();
        //    radGridView1.EnableCustomGrouping = false;

        //    dynamic cDebit = new GridViewSummaryItem();
        //    cDebit.Name = "gvProductQuantity";
        //    cDebit.FormatString = "{0:N2}";
        //    cDebit.Aggregate = GridAggregateFunction.Sum;

        //    dynamic cCredit = new GridViewSummaryItem();
        //    cCredit.Name = "Amount";
        //    cCredit.FormatString = "{0:N2}";
        //    cCredit.Aggregate = GridAggregateFunction.Sum;


        //    dynamic summaryRowItem = new GridViewSummaryRowItem();
        //    summaryRowItem.Add(cDebit);
        //    summaryRowItem.Add(cCredit);

        //    radGridView1.SummaryRowsBottom.Add(summaryRowItem);
        //}
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




        //private void btnSavePrint_Click(object sender, EventArgs e)
        //{
        //    Bill cBill = new Bill(cSqlConnectionString);
        //    SaveData(cBill);
        //    FrmReceipt frmReceipt = new FrmReceipt();
        //    frmReceipt.BillId = cBill.BillId.ToString();
        //    frmReceipt.ShowDialog();
        //}

        //private void txtBillNo_Leave(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtBillNo.Text))
        //    {
        //        Int64 s = 0;
        //        if (Int64.TryParse(txtBillNo.Text, out s))
        //        {
        //            Bill cBill = new Bill(cSqlConnectionString);
        //            cBill.FilterBillNo = Convert.ToInt16(txtBillNo.Text);
        //            List<Bill> cbills = cBill.Load();
        //            if (cbills != null && cbills.Count > 0)
        //            {
        //                if (MessageBox.Show("Bill No Is Already Exists Do you want to edit it", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        //                {
        //                    Mode = "Edit";
        //                    BillId = txtBillNo.Text;
        //                    EditRecord(cbills[0]);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please Enter Numeric value in Bill No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txtBillNo.Focus();
        //        }
        //    }
        //}

        //private void radGridView1_ValueChanged(object sender, EventArgs e)
        //{
        //    //Debug.WriteLine(e);
        //}

        //private void radGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 0)
        //    {
        //        ProductMaster cproductMaster = cListProductMaster.Where(e1 => e1.ProductID == Convert.ToInt64(e.Value)).FirstOrDefault();
        //        Debug.WriteLine("ProductId" + cproductMaster.ProductID.ToString());
        //        e.Row.Cells["PricePerUnit"].Value = cproductMaster.SalePrice;

        //    }
        //    else if (e.ColumnIndex == 1)
        //    {
        //        ProductMaster cproductMaster = cListProductMaster.Where(e1 => e1.ProductID == Convert.ToInt64(e.Row.Cells["gvCboProductId"].Value)).FirstOrDefault();
        //        e.Row.Cells["PricePerUnit"].Value = cproductMaster.SalePrice;
        //        if (Convert.ToInt64(e.Value) > cproductMaster.StockQuantity)
        //        {
        //            MessageBox.Show("Insufficient stock Quantity", "Information");
        //        }
        //        Debug.WriteLine("ProductId" + cproductMaster.ProductID.ToString());
        //        e.Row.Cells["Amount"].Value = Convert.ToInt64(e.Value) * cproductMaster.SalePrice;
        //        ShowWholeTotal();
        //    }
        //}
        //public void ShowWholeTotal()
        //{

        //    decimal billAmount = GetBillAmount();
        //    decimal discountedAmount = 0;
        //    decimal.TryParse(txtDiscountAmt.Text, out discountedAmount);

        //    lblGrandTotal.Text = " Grand Total " + Math.Round(billAmount - discountedAmount, 2).ToString();

        //}

        //private decimal GetBillAmount()
        //{
        //    decimal billAmount = 0;
        //    foreach (var item in radGridView1.Rows)
        //    {
        //        billAmount += Convert.ToDecimal(item.Cells["Amount"].Value);
        //    }
        //    return billAmount;
        //}

        //private void txtDiscount_TextChanged(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtDiscount.Text))
        //    {
        //        decimal s = 0;
        //        if (!decimal.TryParse(txtDiscount.Text, out s))
        //        {
        //            MessageBox.Show("Please Enter valid Discount (%)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //    }
        //    ShowWholeTotal();
        //}

        //private void radGridView1_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        //{
        //    ShowWholeTotal();
        //}

        //private void radGridView1_CreateRow(object sender, GridViewCreateRowEventArgs e)
        //{
        //    ShowWholeTotal();
        //}
        //private void txtDiscount_Leave(object sender, EventArgs e)
        //{
        //    decimal Discount = 0;
        //    decimal BillAmount = 0;
        //    if (!string.IsNullOrEmpty(txtDiscount.Text) && decimal.TryParse(txtDiscount.Text, out Discount))
        //    {
        //        BillAmount = GetBillAmount();
        //        if (BillAmount > 0 & Discount > 0)
        //        {
        //            txtDiscountAmt.Text =  Math.Ceiling(Math.Round(BillAmount * Convert.ToDecimal(Discount / 100), 2)).ToString();
        //        }
        //    }
        //    ShowWholeTotal();
        //}

        //private void btnRefresh_Click(object sender, EventArgs e)
        //{
        //    FillProduct();
        //}

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    FrmProductMaster cFrmMaster = new FrmProductMaster();
        //    cFrmMaster.Mode = "Help";
        //    if (cFrmMaster.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        if (radGridView1.SelectedRows.Count > 0)
        //        {
        //            if (MessageBox.Show("Selected Row Will Be Updated Are you sure you want to update it (Y\\N) \n else it will create new record", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
        //            {
        //                radGridView1.SelectedRows[0].Cells["gvCboProductId"].Value = cFrmMaster.ProductID;
        //                radGridView1.SelectedRows[0].Cells["PricePerUnit"].Value = cFrmMaster.SalePrice;
        //            }
        //            else { AddNewRow(cFrmMaster); }
        //        }
        //        else
        //        {
        //            AddNewRow(cFrmMaster);
        //        }
        //    }
        //}

        //private void AddNewRow(FrmProductMaster cFrmMaster)
        //{
        //    BillDetail mDetails = new BillDetail();
        //    mDetails.ProductId = Convert.ToInt64(cFrmMaster.ProductID);
        //    mDetails.UnitCost = cFrmMaster.SalePrice;
        //    mList.Add(mDetails);
        //    radGridView1.DataSource = null;
        //    radGridView1.DataSource = mList;
        //    radGridView1.Refresh();
        //}

        //private void txtDiscountAmt_Leave(object sender, EventArgs e)
        //{
        //    decimal DiscountAmt = 0;
        //    if (!string.IsNullOrEmpty(txtDiscountAmt.Text))
        //    {

        //        if (!decimal.TryParse(txtDiscountAmt.Text, out DiscountAmt))
        //        {
        //            MessageBox.Show("Please Enter valid Discount Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txtDiscountAmt.Focus();
        //            return;
        //        }
        //    }
        //    decimal billamount = GetBillAmount();
        //    if (billamount > 0 && DiscountAmt > 0)
        //    {
        //        txtDiscount.Text = Math.Round((DiscountAmt / billamount) * 100, 2).ToString();
        //    }
        //}

    }
}
