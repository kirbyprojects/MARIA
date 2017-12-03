using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIA
{
    public partial class MARIASqlServerDatabase
    {
        public StatusObject ResultSetToFile(string OutputFilePath)
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject DisplayResultSet(List<Dictionary<string, MARIASqlServerQueryData>> ResultSet)
        {
            StatusObject SO = new StatusObject();
            try
            {
                foreach(Dictionary<string,MARIASqlServerQueryData> ResultRow in ResultSet)
                {
                    foreach (KeyValuePair<string, MARIASqlServerQueryData> ResultColumn in ResultRow)
                    {
                        Console.WriteLine("{0} {1}", ResultColumn.Key, ResultColumn.Value.DataValue);
                    }
                }
                
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "SQLSERVERDATABASE_DISPLAYRESULTSET");
            }
            return SO;
        }
    }
}
