using System;
using System.Windows.Forms;
using ANS.VehicleDocumentManagement.Server;

namespace ANS.VehicleDocumentManagement
{
    public partial class FrmDocumentMaster : Telerik.WinControls.UI.RadForm
    {
        public FrmDocumentMaster()
        {
            InitializeComponent();
        }
        DataUpdate cDataUpdate = new DataUpdate();
        private void FrmUsersDetail_Load(object sender, EventArgs e)
        {
            cDataUpdate.ServerConection = new System.Data.SqlClient.SqlConnection(ANSSetting.Current.GetConnectionString());
            cDataUpdate.TableName = "tblDocumentMaster";
            cDataUpdate.Load();
            radGridView1.DataSource = cDataUpdate.cDataTable;
            radGridView1.Columns["DocumentId"].IsVisible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cDataUpdate.Update();
            MessageBox.Show("Data Saved");
            FrmUsersDetail_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
