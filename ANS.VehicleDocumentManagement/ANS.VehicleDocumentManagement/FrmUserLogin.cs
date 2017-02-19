using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using ANS.VehicleDocumentManagement.BL;


namespace ANS.VehicleDocumentManagement
{

    public partial class FrmUserLogin : Form
    {
        public FrmUserLogin()
        {
            InitializeComponent();
        }
        SqlConnectionStringBuilder cSqlConnectionString = new SqlConnectionStringBuilder();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Users cUser = new Users(cSqlConnectionString);
            cUser.UserName = txtUserName.Text;
            cUser.Password = txtPassword.Text;
            cUser.ConnectionString = ANSSetting.Current.GetConnectionString();
            if (cUser.IsValid())
            {
                LoginUser.LoginName = txtUserName.Text;
                LoginUser.Role = cUser.Role;
                FrmMain cfrm = new FrmMain();
                cfrm.Show();
                this.Visible = false;
            }
            else { MessageBox.Show("Sorry! Username and Password does not mached"); }
        }

        private void FrmUserLogin_Load(object sender, EventArgs e)
        {
            ANSSetting.Current.GetAllSetting();
            cSqlConnectionString.ConnectionString = ANSSetting.Current.GetConnectionString();
        }
        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
    public static class LoginUser
    {
        public static string LoginName { get; set; }

        public static string Role { get; set; }
    }
}
