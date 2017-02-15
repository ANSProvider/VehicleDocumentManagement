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
    [PetaPoco.TableName("tblCarDocumentDetails")]
    [PetaPoco.PrimaryKey("CarDocumentDetailID", autoIncrement = true)]
    public class CarDocumentDetails : BaseClass
    {
        [PetaPoco.Column]
        public Int64 CarDocumentDetailID { get; set; }
        [PetaPoco.Column]
        public Int64 CarRegistrationID { get; set; }
        [PetaPoco.Column]
        public Int64 DocumentId { get; set; }

        [PetaPoco.Column]
        public DateTime IssueDate { get; set; }

        [PetaPoco.Column]
        public Int64 Validity { get; set; }


        [PetaPoco.Column]
        public DateTime ExpireDate { get; set; }


        [PetaPoco.Column]
        public DateTime RenewDate { get; set; }

        [PetaPoco.Column]
        public DateTime CreatedOn { get; set; }

        [PetaPoco.Column]
        public DateTime UpdateOn { get; set; }


        [PetaPoco.Ignore]
        public Int64? FilterCarDocumentDetailID { get; set; }

        [PetaPoco.Ignore]
        public Int64? FilterCarRegistrationID { get; set; }


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

        public CarDocumentDetails() : base() { }
        public CarDocumentDetails(Database cDbConn) : base(cDbConn) { }
        public CarDocumentDetails(SqlConnectionStringBuilder pConnectionString) : base(pConnectionString) { }

        public List<CarDocumentDetails> Load()
        {
            string mQuery = "";
            mQuery = "Select * From tblCarDocumentDetails Where 1=1 ";
            if (FilterCarRegistrationID.HasValue)
                mQuery += " And CarRegistrationID = '" + FilterCarRegistrationID + "'";
            if (FilterCarDocumentDetailID.HasValue)
                mQuery += " And CarDocumentDetailID = '" + FilterCarDocumentDetailID + "'";

            return cDbConnection.Fetch<CarDocumentDetails>(mQuery).ToList();

        }
        public CarDocumentDetails EditValue(long CarDocumentDetailID)
        {
            FilterCarDocumentDetailID = CarDocumentDetailID;

            List<CarDocumentDetails> mList = Load();
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
