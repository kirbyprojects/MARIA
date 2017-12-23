﻿using System;
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
        public StatusObject Get()
        {
            StatusObject SO = new StatusObject();
            try
            {
                HttpWebRequest TargetSite = (HttpWebRequest)WebRequest.Create(this.URL);
                HttpWebResponse TargetSiteResponse = (HttpWebResponse)TargetSite.GetResponse();
                TargetSiteResponse.Close();
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_GET");
            }
            return SO;
        }
        public StatusObject Get(HttpClient Client)
        {
            StatusObject SO = new StatusObject();
            try
            {
                Directory.CreateDirectory("MARIA");
                HttpResponseMessage Response = Client.GetAsync(this.URL).Result;
                byte[] ResponseBytes = Response.Content.ReadAsByteArrayAsync().Result;
                File.WriteAllBytes(@"MARIA\hello.txt", ResponseBytes);
                Console.WriteLine(Response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_GET_HTTPCLIENT");
            }
            return SO;
        }
        public async Task<StatusObject> GetAsync(HttpClient Client)
        {
            StatusObject SO = new StatusObject();
            try
            {
                HttpResponseMessage TargetSiteResponse = await Client.GetAsync(this.URL);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_GETASYNC");
            }
            return SO;
        }
    }
}
