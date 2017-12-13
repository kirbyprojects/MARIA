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
using System.Threading;

namespace MARIA
{
    public enum WebRequestMethod
    {
        GET,
        POST
    }
    public enum WebRequestEnctype
    {
        APPLICATION_X_WWW_FORM_URLENCODED,
        MULTIPART_FORM_DATA,
        TEXT_PLAIN
    }
    public partial class MARIAWebRequest
    {
        private string URL { get; set; }
        private Dictionary<string,string> QueryStringParameters { get; set; }
        private Dictionary<string, string> RequestCookies { get; set; }
        private Dictionary<string,string> PostParameters { get; set; }
        private Dictionary<string,object> PostObjects { get; set; }
        private WebRequestMethod Method { get; set; }
        private HttpClient Client { get; set; }
        private int RequestDelay { get; set; }
        public MARIAWebRequest(string URL, WebRequestMethod Method, ref HttpClient Client)
        {
            this.URL = URL;
            this.QueryStringParameters = new Dictionary<string, string>();
            this.PostParameters = new Dictionary<string, string>();
            this.PostObjects = new Dictionary<string, object>();
            this.Client = Client;
        }
        public MARIAWebRequest(string URL, WebRequestMethod Method, ref HttpClient Client, int RequestDelay)
        {
            this.URL = URL;
            this.QueryStringParameters = new Dictionary<string, string>();
            this.PostParameters = new Dictionary<string, string>();
            this.PostObjects = new Dictionary<string, object>();
            this.Client = Client;
            this.RequestDelay = RequestDelay;
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
        public StatusObject Execute()
        {
            StatusObject SO = new StatusObject();
            try
            {
                Thread.Sleep(this.RequestDelay);
                if (this.Method == WebRequestMethod.GET)
                {
                    Get();
                }
                else
                {
                    Post();
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject();
            }
            return SO;
        }
    }
}
