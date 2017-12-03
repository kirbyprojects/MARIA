using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MARIA
{
    public partial class MARIASqlServerDatabase
    {
        private Dictionary<string, List<Dictionary<string, MARIASqlServerQueryData>>> ActiveResultSets { get; set; }
        public StatusObject ExecuteNonReaderQuery(string Query)
        {
            StatusObject SO = new StatusObject();
            try
            {
                SqlConnection TargetDatabase = GetSqlConnection();
                SqlCommand ExecutedCommand = new SqlCommand(Query, TargetDatabase);
                TargetDatabase.Open();
                ExecutedCommand.ExecuteNonQuery();
                TargetDatabase.Close();
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
                List<Dictionary<string, MARIASqlServerQueryData>> ResultSet = new List<Dictionary<string, MARIASqlServerQueryData>>();
                SqlConnection TargetDatabase = GetSqlConnection();
                SqlCommand ExecutedCommand = new SqlCommand(Query, TargetDatabase);
                TargetDatabase.Open();
                SqlDataReader Reader = ExecutedCommand.ExecuteReader();
                while (Reader.Read())
                {
                    Dictionary<string, MARIASqlServerQueryData> Row = new Dictionary<string, MARIASqlServerQueryData>();
                    for(int i = 0; i < Reader.FieldCount; i++)
                    {
                        Row.Add(Reader.GetName(i).ToUpper(), new MARIASqlServerQueryData(Reader[i]));
                    }
                    ResultSet.Add(Row);
                }
                SO.UDDynamic = ResultSet;
                TargetDatabase.Close();
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "SQLSERVERDATABASE_EXECUTEREADERQUERY");
            }
            return SO;
        }
    }
}
