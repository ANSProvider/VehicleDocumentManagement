using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace ANS.VehicleDocumentManagement
{
    public sealed class ANSSetting
    {
        private static volatile ANSSetting instance;
        private static object syncRoot = new Object();
        public ServerDetail ServerDetail;
        private ANSSetting() { }
        public static ANSSetting Current
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ANSSetting();
                        }
                    }
                }
                return instance;
            }
        }



        public string UserName { get; set; }
        public bool IsMasterUser { get; set; }
        public ServerDetail LoadServers()
        {
            string vServerPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\ANS_Options.xml";
            ServerDetail cServerDetails = new ServerDetail(vServerPath);

            return cServerDetails;
        }
        public void GetAllSetting()
        {
            ServerDetail = LoadServers();
        }
        public String GetConnectionString(String mFAYear)
        {
            return "Data Source=" + ServerDetail.ServerName + ";Initial Catalog=" + ServerDetail.PreFix + mFAYear + ";User Id=" + ServerDetail.UserName + ";Password=" + ServerDetail.Password + ";";
        }
        public string GetConnectionString()
        {
            return "Data Source=" + ServerDetail.ServerName + ";Initial Catalog=" + ServerDetail.DataBaseName + ";User Id=" + ServerDetail.UserName + ";Password=" + ServerDetail.Password + ";";
        }
        public DataTable GetDbNames(String ServerName, String UserName, String Password)
        {

            SqlConnection cSqlCon = new SqlConnection("Data Source=" + ServerName + ";Initial Catalog=Master;User Id=" + UserName + ";Password=" + Password + ";");
            cSqlCon.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Name from master..sysdatabases order by name", cSqlCon);
            DataTable cDataTable = new DataTable();
            da.Fill(cDataTable);
            cSqlCon.Close();
            return cDataTable;
        }
        public bool IsDbExists(String DbName)
        {

            SqlConnection cSqlCon = new SqlConnection("Data Source=" + ServerDetail.ServerName + ";Initial Catalog=Master;User Id=" + ServerDetail.UserName + ";Password=" + ServerDetail.Password + ";");
            cSqlCon.Open();
            String mQuery = "Select * from master..sysdatabases Where Name='" + DbName + "'";

            SqlDataAdapter da = new SqlDataAdapter(mQuery, cSqlCon);
            DataTable cDataTable = new DataTable();
            da.Fill(cDataTable);
            cSqlCon.Close();
            if (cDataTable.Rows.Count > 0) { return true; } else { return false; }
            //return cDataTable;
        }
        public DataTable GetTableName(String ServerName, String UserName, String Password, string DatabaseName)
        {
            SqlConnection cSqlCon = new SqlConnection("Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";User Id=" + UserName + ";Password=" + Password + ";");
            SqlDataAdapter da = new SqlDataAdapter("Select Name from sysobjects where xtype='U' order by name", cSqlCon);
            DataTable cDataTable = new DataTable();
            da.Fill(cDataTable);
            return cDataTable;
        }


    }
    public class ServerDetail
    {
        public String FileName { get; set; }
        public String ServerType { get; set; }
        public String ServerName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String DataBaseName { get; set; }
        public bool IsWinAuth { get; set; }
        public string PreFix { get; set; }
        public ServerDetail(string pFileName)
        {
            FileName = pFileName;
            Read();
        }
        public ServerDetail()
        {
        }
        public void Write()
        {
            if (!string.IsNullOrEmpty(FileName))
            {
                if (File.Exists(FileName))
                {
                    DataSet cDataSet = new DataSet();
                    cDataSet.ReadXml(FileName);
                    cDataSet.Tables["ServerDetail"].Rows[0]["ServerType"] = ServerType;
                    cDataSet.Tables["ServerDetail"].Rows[0]["ServerName"] = ServerName;
                    cDataSet.Tables["ServerDetail"].Rows[0]["UserName"] = UserName;
                    cDataSet.Tables["ServerDetail"].Rows[0]["Password"] = Password;
                    cDataSet.Tables["ServerDetail"].Rows[0]["DbName"] = DataBaseName;
                    try
                    {
                        cDataSet.Tables["ServerDetail"].Rows[0]["IsWinAuth"] = IsWinAuth;
                    }
                    catch { }
                    cDataSet.WriteXml(FileName);
                }
            }
        }
        public void Read()
        {
            if (!string.IsNullOrEmpty(FileName))
            {
                if (File.Exists(FileName))
                {
                    DataSet cDataSet = new DataSet();
                    cDataSet.ReadXml(FileName);
                    ServerType = cDataSet.Tables["ServerDetail"].Rows[0]["ServerType"].ToString();
                    ServerName = cDataSet.Tables["ServerDetail"].Rows[0]["ServerName"].ToString();
                    UserName = cDataSet.Tables["ServerDetail"].Rows[0]["UserName"].ToString();
                    Password = cDataSet.Tables["ServerDetail"].Rows[0]["Password"].ToString();
                    DataBaseName = cDataSet.Tables["ServerDetail"].Rows[0]["DbName"].ToString();

                    try
                    {
                        IsWinAuth = Convert.ToBoolean(cDataSet.Tables["ServerDetail"].Rows[0]["IsWinAuth"]);
                    }
                    catch { }
                    try
                    {
                        PreFix = Convert.ToString(cDataSet.Tables["ServerDetail"].Rows[0]["PreFix"]);
                    }
                    catch { PreFix = "ANS"; }
                }
                else
                {
                    throw new Exception("File " + FileName + " Does Not Exists");
                }
            }
            else
            {
                throw new Exception("Please File File Name Property");
            }
        }
    }

}
