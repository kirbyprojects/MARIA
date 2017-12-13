using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.IO;
namespace MARIA
{
    public partial class MARIAWebRequest
    {
        public StatusObject Post()
        {
            StatusObject SO = new StatusObject();
            try
            {
                HttpResponseMessage Response = this.Client.PostAsync(this.URL, GetFormUrlEncodedContent()).Result;
                Console.WriteLine(Response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_POST");
            }
            return SO;
        }
    }
}
