using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.IO;
namespace MARIA
{
    public partial class MARIASqlServerDatabase
    {
        public StatusObject ExportStoredProcedures(params string[] StoredProcedureNames)
        {
            StatusObject SO = new StatusObject();
            try
            {
                string StorageDirectory = String.Format(@"Databases\{0}\{1}\StoredProcedures", this.Server, this.Database);
                Directory.CreateDirectory(StorageDirectory);
                if(StoredProcedureNames.Length > 0)
                {

                }
                else
                {

                }
            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject TrackStoredProcedureChanges(params string[] StoredProcedureNames)
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
