using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ANS.VehicleDocumentManagement.Server
{
    public class DataUpdate
    {
        private SqlDataAdapter da;
        public DataTable cDataTable { get; set; }
        public string TableName { get; set; }
        public SqlConnection ServerConection { get; set; }
        public String QueryString { get; set; }
        public void Load()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(QueryString))
                {
                    QueryString = "Select * from " + TableName;
                }
                da = new SqlDataAdapter(QueryString, ServerConection.ConnectionString);
                SqlCommandBuilder cSldb = new SqlCommandBuilder(da);
                cDataTable = new DataTable();
                da.Fill(cDataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CancelChanges()
        {
            cDataTable.RejectChanges();
        }
        public void Update()
        {
            try
            {
                if (da == null)
                {
                    da = new SqlDataAdapter("Select * from " + TableName, ServerConection.ConnectionString);
                    SqlCommandBuilder cSldb = new SqlCommandBuilder(da);
                }
                da.Update(cDataTable);
                Load();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
