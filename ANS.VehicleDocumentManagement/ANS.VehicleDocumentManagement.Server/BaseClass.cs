using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace ANS.VehicleDocumentManagement.Server
{
    public class BaseClass
    {
        [Browsable(false)]
        [PetaPoco.Ignore]
        public bool IsLogWrite { get; set; }
        [Browsable(false)]
        [PetaPoco.Ignore]
        public Database cDbConnection { get; set; }
        [Browsable(false)]
        [PetaPoco.Ignore]
        public Boolean IsAutoIncrement { get; set; }
        [Browsable(false)]
        [PetaPoco.Ignore]
        public Boolean HasErrors { get { return Errors.Count != 0; } }


        public delegate void Del_RisError(object sender, ErrorHandler e);
        public event Del_RisError Ev_RiseError;

        public readonly Dictionary<string, string> Errors;
        [PetaPoco.Ignore]
        public String ConnectionString { get; set; }
        public BaseClass()
        {
            DefaultConstructor();
            Errors = new Dictionary<string, string>();
        }
        public BaseClass(Database cDbConn)
        {
            cDbConnection = cDbConn;
            DefaultConstructor();
            Errors = new Dictionary<string, string>();
        }
        public BaseClass(SqlConnectionStringBuilder pConnectionString)
        {
            cDbConnection = new Database(pConnectionString.ConnectionString, "System.Data.SqlClient");
            DefaultConstructor();
            Errors = new Dictionary<string, string>();
        }
        public void DefaultConstructor()
        {
            IsAutoIncrement = false;
        }

        public virtual void RiseError(object Sender, ErrorHandler e)
        {
            UpdateLog("Errors_" + DateTime.Now.ToString("yyyyMMdd") + ".log", e.ErrorMessage);
            if (Ev_RiseError != null)
                Ev_RiseError(Sender, e);
        }

        /// <summary>
        /// Clear All Property In The Class
        /// </summary>
        public void Clear()
        {
            foreach (PropertyInfo pi in this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty))
            {

                if (!pi.CanWrite)
                { continue; }
                if (pi.PropertyType == typeof(string))
                {
                    pi.SetValue(this, string.Empty, null);
                }
                if (pi.PropertyType == typeof(DateTime?))
                {
                    pi.SetValue(this, null, null);
                }
                if (pi.PropertyType == typeof(decimal))
                {
                    pi.SetValue(this, Convert.ToDecimal(0), null);
                }
            }
        }
        /// <summary>
        /// Update The Log For Later Purpose
        /// </summary>
        /// <param name="FileName">File Name For Saving</param>
        /// <param name="Content">Log Content To Be Saved</param>
        public void UpdateLog(String FileName, String Content)
        {
            //"ImportLog_"+ DateTime.Now.ToString("yyyyMMdd") +".txt"
            using (FileStream fStream = new FileStream(FileName, FileMode.Append))
            {
                using (StreamWriter s = new StreamWriter(fStream))
                {
                    s.AutoFlush = true;
                    s.WriteLine("<" + this.ToString() + ">[" + DateTime.Now + "]::" + Content);
                    IsLogWrite = true;
                    //s.Close();
                }
                //fStream.Close();
            }
        }

        #region  PetaPoco
        public virtual void Insert(String TableName, String Key)
        {
            cDbConnection.Insert(TableName, Key, IsAutoIncrement, this);
        }
        public virtual void Insert()
        {
            cDbConnection.Insert(this);
        }
        public virtual void Update(String TableName, String Key)
        {
            cDbConnection.Update(TableName, Key, this);
        }
        public virtual void Update()
        {
            cDbConnection.Update(this);
        }
        public virtual void Save(String TableName, String Key)
        {
            cDbConnection.Save(TableName, Key, this);
        }
        public virtual void Save()
        {
            cDbConnection.Save(this);
        }
        public virtual void Delete(String TableName, String Key)
        {
            cDbConnection.Delete(TableName, Key, this);
        }
        public virtual void Delete()
        {
            cDbConnection.Delete(this);
        }
        #endregion

        #region Validation Error code
        public void AddError(string propertyName, string message)
        {
            if (!Errors.ContainsKey(propertyName))
            {
                Errors[propertyName] = message;
            }
        }

        public void RemoveErrors(string propertyName)
        {
            Errors.Remove(propertyName);
        }

        public string GetErrorMessageForProperty(string propertyName)
        {
            string message;
            Errors.TryGetValue(propertyName, out message);
            return message;
        }

        #endregion
    }
}