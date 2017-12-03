using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace MARIA
{
    public partial class MARIASqlServerDatabase
    {
        private string Server { get; set; }
        private string Database { get; set; }
        private string UserID { get; set; }
        private string Password { get; set; }
        private string AuthenticationMode { get; set; }
        public MARIASqlServerDatabase()
        {

        }
        public MARIASqlServerDatabase(string Server, string Database)
        {
            this.Server = Server;
            this.Database = Database;
            this.AuthenticationMode = "winauth";
        }
        public MARIASqlServerDatabase(string Server, string Database, string UserID, string Password)
        {
            this.Server = Server;
            this.Database = Database;
            this.UserID = UserID;
            this.Password = Password;
            this.AuthenticationMode = "sqlauth";
        }
        public string GetConnectionString()
        {
            string ConnectionString = "";
            if(this.AuthenticationMode == "winauth")
            {
                ConnectionString = String.Format("server={0};database={1};trusted_connection=true");
            }
            else if(this.AuthenticationMode == "sqlauth")
            {
                ConnectionString = String.Format("server={0};database={1};user id={2};password={3}");
            }
            return ConnectionString;
        }
        public SqlConnection GetSqlConnection()
        {
            SqlConnection NewSqlConnection = new SqlConnection();
            try
            {
                NewSqlConnection = new SqlConnection(GetConnectionString());
                NewSqlConnection.Open();
                NewSqlConnection.Close();
            }
            catch(Exception e)
            {
                NewSqlConnection = null;
            }
            return NewSqlConnection;
        }
    }
}
