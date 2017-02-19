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
    [PetaPoco.TableName("tblCarRegistration")]
    [PetaPoco.PrimaryKey("CarRegistrationID", autoIncrement = true)]
    public class CarRegistration : BaseClass
    {
        [PetaPoco.Column]
        public Int64 CarRegistrationID { get; set; }
        [PetaPoco.Column]
        public Int64 CustomerID { get; set; }
        [PetaPoco.Column]


        [PetaPoco.Ignore]
        public String CarCustomerName
        {
            get
            {
                if (CarCustomerDetails != null)
                    return CarCustomerDetails.CustomerName + " - " + CarCustomerDetails.ContactPerson;
                else
                    return string.Empty;

            }
        }


        public string CarRegistrationNo { get; set; }
        [PetaPoco.Column]
        public DateTime DateOfRegistration { get; set; }
        [PetaPoco.Column]
        public string ChasissNo { get; set; }
        [PetaPoco.Column]
        public string EngineNo { get; set; }
        [PetaPoco.Column]
        public string MakerName { get; set; }
        [PetaPoco.Column]
        public string Model { get; set; }
        [PetaPoco.Column]
        public string MfgMonYear { get; set; }
        [PetaPoco.Column]
        public string Type { get; set; }
        [PetaPoco.Column]
        public string RTOName { get; set; }
        [PetaPoco.Column]
        public DateTime CreatedOn { get; set; }
        [PetaPoco.Column]
        public DateTime UpdateOn { get; set; }


        [PetaPoco.Ignore]
        public Int64? FilterCarRegistrationID { get; set; }

        [PetaPoco.Ignore]
        public String FilterCarRegistrationNo { get; set; }

        [PetaPoco.Ignore]
        public Int64? FilterCustomerID { get; set; }

        [PetaPoco.Ignore]
        public String FilterCustomerName { get; set; }

      
        [PetaPoco.Ignore]
        public CustomerDetails CarCustomerDetails { get; set; }

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

        public CarRegistration() : base() { }
        public CarRegistration(Database cDbConn) : base(cDbConn) { }
        public CarRegistration(SqlConnectionStringBuilder pConnectionString) : base(pConnectionString) { }

        public List<CarRegistration> Load()
        {
            string mQuery = "";
            mQuery = "Select * From tblCarRegistration Join  tblCustomerDetails on tblCarRegistration.CustomerID=tblCustomerDetails.CustomerID Where 1=1 ";
            if (FilterCarRegistrationID.HasValue)
                mQuery += " And tblCarRegistration.CarRegistrationID = '" + FilterCarRegistrationID + "'";
            if (FilterCustomerID.HasValue)
                mQuery += " And tblCarRegistration.CustomerID = '" + FilterCustomerID + "'";
            if (!string.IsNullOrEmpty(FilterCarRegistrationNo))
                mQuery += " And tblCarRegistration.CarRegistrationNo like '%" + FilterCarRegistrationNo + "%'";

            if (!string.IsNullOrEmpty(FilterCustomerName))
                mQuery += " And  tblCustomerDetails.CustomerName like '%" + FilterCustomerName + "%';";

            return cDbConnection.Fetch<CarRegistration,CustomerDetails>(mQuery).ToList();

        }
        public CarRegistration EditValue(long CarRegistrationID)
        {
            FilterCarRegistrationID = CarRegistrationID;

            List<CarRegistration> mList = Load();
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
