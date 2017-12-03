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
        public StatusObject Post(HttpClient Client)
        {
            StatusObject SO = new StatusObject();
            try
            {
                HttpResponseMessage Response = Client.PostAsync(this.URL, GetFormUrlEncodedContent()).Result;
                
                Console.WriteLine(Response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e)
            {

            }
            return SO;
        }
    }
}
