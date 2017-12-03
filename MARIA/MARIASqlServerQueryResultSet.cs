using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIA
{
    public class MARIASqlServerQueryResultSet
    {
        private List<Dictionary<string, MARIASqlServerQueryData>> Rows { get; set; }
        public MARIASqlServerQueryResultSet()
        {
            this.Rows = new List<Dictionary<string, MARIASqlServerQueryData>>();
        }
        public StatusObject AddRow(string ColumnName, object Value)
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
    }
}
