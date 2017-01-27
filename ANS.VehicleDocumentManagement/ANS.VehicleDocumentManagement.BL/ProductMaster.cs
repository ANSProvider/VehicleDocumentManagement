using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

using ANS.VehicleDocumentManagement.Server;

namespace ANS.VehicleDocumentManagement.BL
{
    [PetaPoco.TableName("ProductMaster")]
    [PetaPoco.PrimaryKey("ProductID", autoIncrement = true)]
    public class ProductMaster :BaseClass
    {
        [PetaPoco.Column]
        public Int64 ProductID { get; set; }
        [PetaPoco.Column]
        public string ProductCode { get; set; }
        [PetaPoco.Column]
        public string ProductName { get; set; }

        [PetaPoco.Column]
        public string Descriptions { get; set; }

        

        [PetaPoco.Column]
        public String Size { get; set; }
        [PetaPoco.Column]
        public int StockQuantity { get; set; }
        [PetaPoco.Column]
        public decimal CostPrice { get; set; }
        [PetaPoco.Column]
        public decimal  SalePrice { get; set; }
        [PetaPoco.Column]
        public DateTime CreatedDate { get; set; }
        [PetaPoco.Column]
        public DateTime LastUpdated { get; set; }

        [PetaPoco.Ignore]
        public string ProductDesc { get { return ProductName + " - " + Descriptions + " - " + ProductCode + " - " + Size + " - " + StockQuantity + " : Rs." + SalePrice; } }
        
        public ProductMaster() : base() { }
        public ProductMaster(Database cDbConn) : base(cDbConn) { }
        public ProductMaster(SqlConnectionStringBuilder pConnectionString) : base(pConnectionString) { }
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

        public List<ProductMaster> Load()
        {
            string mQuery = "";
            mQuery = "Select * From ProductMaster Where 1=1 ";
            if(FilterProductId.HasValue)
                mQuery += " And ProductID = '" + FilterProductId + "'";
            if (!String.IsNullOrEmpty(FilterProductName))
                mQuery += " And ProductName like '" + FilterProductName  + "%'";
            if (!String.IsNullOrEmpty(FilterProductCode))
                mQuery += " And ProductCode like '" + FilterProductCode + "%'";

            Debug.WriteLine(mQuery);
            return cDbConnection.Fetch<ProductMaster>(mQuery).ToList();
        }
        [PetaPoco.Ignore]
        public Int64? FilterProductId{ get; set; }
        public ProductMaster EditValue(int ProductId)
        {
            FilterProductId = ProductID;

            List<ProductMaster> mList = Load();
            if (mList == null) { return null; }
            if (mList.Count > 0)
            {
                mList[0].cDbConnection = cDbConnection;
                return mList[0];
            }
            return null;
        }
        [PetaPoco.Ignore]
        public String FilterProductName { get; set; }
        [PetaPoco.Ignore]
        public String  FilterProductCode { get; set; }
    }
}