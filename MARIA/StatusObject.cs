using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIA
{
    public enum StatusCode
    {
        SUCCESS,
        FAILURE
    }
    public class StatusObject
    {
        public StatusCode Status { get; private set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorStackTrace { get; set; }
        public dynamic UDDynamic { get; set; }
        public StatusObject()
        {
            this.Status = StatusCode.SUCCESS;
        }
        public StatusObject(Exception e, string ErrorCode)
        {
            this.Status = StatusCode.FAILURE;
            this.ErrorCode = ErrorCode;
            this.ErrorMessage = e.Message;
            this.ErrorStackTrace = e.ToString();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("ErrorCode {0}", this.ErrorCode);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(this.ErrorStackTrace);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("ErrorCode {0}", this.ErrorCode);
            Console.WriteLine("---------------------------------------------------------");
        }
    }
}
