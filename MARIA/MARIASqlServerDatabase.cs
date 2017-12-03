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
        public bool HasValidParameters { get; private set; }
        public MARIASqlServerDatabase()
        {

        }
        public MARIASqlServerDatabase(string Server, string Database)
        {
            try
            {
                this.Server = Server;
                this.Database = Database;
                this.AuthenticationMode = "winauth";
                this.HasValidParameters = true;
                this.ActiveResultSets = new Dictionary<string, List<Dictionary<string, MARIASqlServerQueryData>>>();
            }
            catch(Exception e)
            {
                this.HasValidParameters = false;
            }
            
        }
        public MARIASqlServerDatabase(string Server, string Database, string UserID, string Password)
        {
            try
            {
                this.Server = Server;
                this.Database = Database;
                this.UserID = UserID;
                this.Password = Password;
                this.AuthenticationMode = "sqlauth";
                this.ActiveResultSets = new Dictionary<string, List<Dictionary<string, MARIASqlServerQueryData>>>();
                this.HasValidParameters = true;
            }
            catch(Exception e)
            {
                this.HasValidParameters = false;
            }
        }
        public MARIASqlServerDatabase(string Credentials)
        {
            try
            {
                List<string> CredentialsList = Credentials.Split(';').ToList();
                if (CredentialsList.Count == 2)
                {
                    this.Server = CredentialsList[0];
                    this.Database = CredentialsList[1];
                    this.AuthenticationMode = "winauth";
                }
                else if (CredentialsList.Count == 4)
                {
                    this.Server = CredentialsList[0];
                    this.Database = CredentialsList[1];
                    this.UserID = CredentialsList[2];
                    this.Password = CredentialsList[3];
                    this.AuthenticationMode = "sqlauth";
                }
                this.ActiveResultSets = new Dictionary<string, List<Dictionary<string, MARIASqlServerQueryData>>>();
                this.HasValidParameters = true;
            }
            catch(Exception e)
            {
                this.HasValidParameters = false;
            }
        }
        public string GetConnectionString()
        {
            string ConnectionString = "";
            if (HasValidParameters)
            {
                if (this.AuthenticationMode == "winauth")
                {
                    ConnectionString = String.Format("server={0};database={1};trusted_connection=true", Server, Database);
                }
                else if (this.AuthenticationMode == "sqlauth")
                {
                    ConnectionString = String.Format("server={0};database={1};user id={2};password={3}", Server, Database, UserID, Password);
                }
            }
            else
            {
                ConnectionString = null;
            }
            return ConnectionString;
        }
        public SqlConnection GetSqlConnection()
        {
            SqlConnection NewSqlConnection = new SqlConnection();
            try
            {
                if (HasValidParameters)
                {
                    NewSqlConnection = new SqlConnection(GetConnectionString());
                    NewSqlConnection.Open();
                    NewSqlConnection.Close();
                }
                else
                {
                    NewSqlConnection = null;
                }
            }
            catch(Exception e)
            {
                NewSqlConnection = null;
            }
            return NewSqlConnection;
        }
    }
}
