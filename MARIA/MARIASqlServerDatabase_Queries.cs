using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
namespace MARIA
{
    public partial class MARIASqlServerDatabase
    {
        public StatusObject ExecuteNonReaderQuery(string Query)
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "SQLSERVERDATABASE_EXECUTENONREADERQUERY");
            }
            return SO;
        }
        public StatusObject ExecuteReaderQuery(string Query)
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "SQLSERVERDATABASE_EXECUTEREADERQUERY");
            }
            return SO;
        }
    }
}
