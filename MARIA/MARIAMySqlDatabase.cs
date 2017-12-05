using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MARIA
{
    public partial class MARIAMySqlDatabase
    {
        public string Server { get; private set; }
        public string Database { get; private set; }
        private string UserID { get; set; }
        private string Password { get; set; }
        public MARIAMySqlDatabase()
        {

        }
    }
}
