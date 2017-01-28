using ANS.VehicleDocumentManagement.Server;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace ANS.VehicleDocumentManagement.BL
{
    [PetaPoco.TableName("tblCustomerDetails")]
    [PetaPoco.PrimaryKey("CustomerID", autoIncrement = true)]
    public class CustomerDetails : BaseClass
    {
        [PetaPoco.Column]
        public Int64 CustomerID { get; set; }
        [PetaPoco.Column]
        public string CustomerName { get; set; }
        [PetaPoco.Column]
        public string CurrentAddress { get; set; }
        [PetaPoco.Column]
        public string PermantAddress { get; set; }
        [PetaPoco.Column]
        public string MobileNo { get; set; }
        [PetaPoco.Column]
        public string OfficeNo { get; set; }
        [PetaPoco.Column]
        public string EmailId { get; set; }
        [PetaPoco.Column]
        public string ContactPerson { get; set; }

        [PetaPoco.Column]
        public DateTime? CreatedOn { get; set; }
        [PetaPoco.Column]
        public DateTime? UpdatedOn { get; set; }

        [PetaPoco.Ignore]
        public Int64? FilterCustomerID { get; set; }
        [PetaPoco.Ignore]
        public String FilterCustomerName { get; set; }

        [PetaPoco.Ignore]
        public string this[string columnName]
        {
            get
            {

                string ValidationMsg = "";
                Errors.Remove(columnName);

                var prop = GetType().GetProperty(columnName);
                var validationMap = prop.GetCustomAttributes(typeof(ValidationAttribute), true).Cast<ValidationAttribute>();

                foreach (var v in validationMap)
                {
                    try
                    {
                        v.Validate(prop.GetValue(this, null), columnName);
                    }
                    catch (Exception)
                    {
                        ValidationMsg = v.ErrorMessage;
                    }
                }

                if (string.IsNullOrEmpty(ValidationMsg))
                {
                }
                if (!string.IsNullOrEmpty(ValidationMsg))
                    Errors.Add(columnName, ValidationMsg);

                return ValidationMsg;
            }
        }

        public CustomerDetails() : base() { }
        public CustomerDetails(Database cDbConn) : base(cDbConn) { }
        public CustomerDetails(SqlConnectionStringBuilder pConnectionString) : base(pConnectionString) { }

        public List<CustomerDetails> Load()
        {
            string mQuery = "";
            mQuery = "Select * From tblCustomerDetails Where 1=1 ";
            if (FilterCustomerID.HasValue)
                mQuery += " And CustomerID = '" + FilterCustomerID + "'";
            if (!String.IsNullOrEmpty(FilterCustomerName))
                mQuery += " And CustomerName like '" + FilterCustomerName + "%'";

            Debug.WriteLine(mQuery);
            return cDbConnection.Fetch<CustomerDetails>(mQuery).ToList();
        }
        public CustomerDetails EditValue(Int64 CustomerID)
        {
            FilterCustomerID = CustomerID;

            List<CustomerDetails> mList = Load();
            if (mList == null) { return null; }
            if (mList.Count > 0)
            {
                mList[0].cDbConnection = cDbConnection;
                return mList[0];
            }
            return null;
        }

    }
}
