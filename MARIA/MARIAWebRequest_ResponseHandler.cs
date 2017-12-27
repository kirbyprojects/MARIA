using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
namespace MARIA
{
    public partial class MARIAWebRequest
    {
        public StatusObject ReadResponse(HttpWebResponse Response)
        {
            StatusObject SO = new StatusObject();
            try
            {
                Stream ResponseStream = Response.GetResponseStream();
                StreamReader ResponseStreamReader = new StreamReader(ResponseStream);
                Console.WriteLine(ResponseStreamReader.ReadToEnd());
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_READRESPONSE");
            }
            return SO;
        }
        public StatusObject WriteResponseToFile(HttpWebResponse Response)
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_WRITERESPONSETOFILE");
            }
            return SO;
        }
    }
}
