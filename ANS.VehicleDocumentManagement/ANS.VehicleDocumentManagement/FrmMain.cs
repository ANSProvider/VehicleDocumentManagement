﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANS.VehicleDocumentManagement
{
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();
        }


        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmCustomerDetails frmCustomerDetails = new FrmCustomerDetails();
            frmCustomerDetails.MdiParent = this;
            frmCustomerDetails.Show();

        }

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomerList frmCustomerList = new FrmCustomerList();
            frmCustomerList.MdiParent = this;
            frmCustomerList.WindowState = FormWindowState.Maximized;
            frmCustomerList.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ANSSetting.Current.GetAllSetting();
        }
    }
}
