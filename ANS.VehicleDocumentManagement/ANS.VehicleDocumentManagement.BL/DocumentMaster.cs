using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ANS.VehicleDocumentManagement.Server;

namespace ANS.VehicleDocumentManagement.BL

{
    [PetaPoco.TableName("tblDocumentMaster")]
    [PetaPoco.PrimaryKey("DocumentId", autoIncrement = true)]
    public class DocumentMaster : BaseClass
    {
        [PetaPoco.Column]
        public int DocumentId { get; set; }
        [PetaPoco.Column]
        [Required]
        [Display(Name = "Document name")]
        public string DocumentName { get; set; }
        [PetaPoco.Column]
        [Required]

        [Display(Name = "Validitiy In Month")]
        public int ValiditiyMonth { get; set; }

        public DocumentMaster() : base() { }
        public DocumentMaster(Database cDbConn) : base(cDbConn) { }
        public DocumentMaster(SqlConnectionStringBuilder pConnectionString) : base(pConnectionString) { }

        public List<DocumentMaster> Load()
        {
            var mQuery = PetaPoco.Sql.Builder.Append("select * from tblDocumentMaster");
            return cDbConnection.Fetch<DocumentMaster>(mQuery).ToList();
        }
    }
}