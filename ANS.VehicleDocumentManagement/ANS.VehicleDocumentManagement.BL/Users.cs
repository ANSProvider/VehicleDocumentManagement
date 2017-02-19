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
    [PetaPoco.TableName("Users")]
    [PetaPoco.PrimaryKey("UniqueId", autoIncrement = true)]
    public class Users : BaseClass
    {
        [PetaPoco.Ignore]
        public int UniqueId { get; set; }
        [PetaPoco.Column]
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [PetaPoco.Column]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [PetaPoco.Column]
        [Display(Name = "Role")]
        public String Role { get; set; }

        public Users() : base() { }
        public Users(Database cDbConn) : base(cDbConn) { }
        public Users(SqlConnectionStringBuilder pConnectionString) : base(pConnectionString) { }

        public List<Users> Load()
        {
            var mQuery = PetaPoco.Sql.Builder.Append("select * from Users");
            return cDbConnection.Fetch<Users>(mQuery).ToList();
        }


        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>        
        /// <returns>True if user exist and password is correct</returns>
        public bool IsValid()
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                string _sql = @"SELECT [Role] FROM [Users] " +
                       @"WHERE [Username] = @username AND [Password] = @password";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@username", SqlDbType.NVarChar))
                    .Value =UserName;
                cmd.Parameters
                    .Add(new SqlParameter("@password", SqlDbType.NVarChar))
                    .Value = Password;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Role = reader["ROle"].ToString();
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        }
    }
}