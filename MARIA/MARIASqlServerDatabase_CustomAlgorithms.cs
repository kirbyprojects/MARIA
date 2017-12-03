using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace MARIA
{
    public partial class MARIASqlServerDatabase
    {
        public StatusObject GetAllExecutedQueries()
        {
            StatusObject SO = new StatusObject();
            try
            {
                SO = ExecuteReaderQuery(
                    @"SELECT        SQLTEXT.text, STATS.last_execution_time
                    FROM          sys.dm_exec_query_stats STATS
                    CROSS APPLY   sys.dm_exec_sql_text(STATS.sql_handle) AS SQLTEXT
                    WHERE         STATS.last_execution_time > GETDATE()-1
                    ORDER BY      STATS.last_execution_time DESC");
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "SQLSERVERDATABASE_GETALLEXECUTEDQUERIES");
            }
            return SO;
        }
    }
}
