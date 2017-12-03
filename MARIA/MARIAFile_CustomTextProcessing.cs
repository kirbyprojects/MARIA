using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIA
{
    public partial class MARIAFile
    {
        public struct RequestAuditRecord
        {
            int ID;
            string RequestDate;
            string RequestTime;
            string RequestingCompany;
            int Something;
            string UserName;
            string QueryString;
            string RequestIP;
        }
        public static StatusObject AnalyzeRequest(string Input)
        {
            StatusObject SO = new StatusObject();
            try
            {
                List<string> RequestAuditRecordParameters = Input.Split('\t').ToList();
                Console.WriteLine(RequestAuditRecordParameters.ElementAtOrDefault(0));
                Console.WriteLine(RequestAuditRecordParameters.ElementAtOrDefault(1));
                Console.WriteLine(RequestAuditRecordParameters.ElementAtOrDefault(2));
                Console.WriteLine(RequestAuditRecordParameters.ElementAtOrDefault(3));
                Console.WriteLine(RequestAuditRecordParameters.ElementAtOrDefault(4));
                Console.WriteLine(RequestAuditRecordParameters.ElementAtOrDefault(5));
                Console.WriteLine(RequestAuditRecordParameters.ElementAtOrDefault(6));

            }
            catch(Exception e)
            {

            }
            return SO;
        }
    }
}
