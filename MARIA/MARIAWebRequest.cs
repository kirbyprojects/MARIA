using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mime;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
namespace MARIA
{
    public partial class MARIAWebRequest
    {
        private string URL { get; set; }
        private Dictionary<string,string> QueryStringParameters { get; set; }
        private Dictionary<string, string> RequestCookies { get; set; }
        private Dictionary<string,string> PostParameters { get; set; }
        private Dictionary<string,object> PostObjects { get; set; }
        public MARIAWebRequest(string URL)
        {
            this.URL = URL;
            this.QueryStringParameters = new Dictionary<string, string>();
            this.PostParameters = new Dictionary<string, string>();
            this.PostObjects = new Dictionary<string, object>();
        }
        public string GetQueryString()
        {
            return new FormUrlEncodedContent(this.QueryStringParameters).ReadAsStringAsync().Result;
        }
        public string GetUrlEncodedPostParameters()
        {
            return new FormUrlEncodedContent(this.PostParameters).ReadAsStringAsync().Result;
        }
        public FormUrlEncodedContent GetFormUrlEncodedContent()
        {
            return new FormUrlEncodedContent(this.PostParameters);
        }
        public StatusObject AddQueryStringParameter(string Key, string Value)
        {
            StatusObject SO = new StatusObject();
            try
            {
                if (!this.QueryStringParameters.ContainsKey(Key.Trim().ToUpper()))
                {
                    this.QueryStringParameters.Add(Key.Trim().ToUpper(), Value.Trim());
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_ADDQUERYSTRINGPARAMETER");
            }
            return SO;
        }
        public StatusObject AddPostParameter(string Key,string Value)
        {
            StatusObject SO = new StatusObject();
            try
            {
                if (!this.PostParameters.ContainsKey(Key.Trim().ToUpper()))
                {
                    this.PostParameters.Add(Key.Trim().ToUpper(), Value.Trim());
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_ADDPOSTPARAMETER");
            }
            return SO;
        }
        public StatusObject AddPostObject(string Key, object Value)
        {
            StatusObject SO = new StatusObject();
            try
            {
                if (!this.PostObjects.ContainsKey(Key.Trim().ToUpper()))
                {
                    this.PostObjects.Add(Key.Trim().ToUpper(), Value);
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_ADDPOSTOBJECT");
            }
            return SO;
        }
        public StatusObject AddRequestCookie(string Key, string Value)
        {
            StatusObject SO = new StatusObject();
            try
            {
                if (!this.RequestCookies.ContainsKey(Key.Trim().ToUpper()))
                {
                    this.RequestCookies.Add(Key.Trim().ToUpper(), Value);
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_ADDREQUESTCOOKIE");
            }
            return SO;
        }
    }
}
