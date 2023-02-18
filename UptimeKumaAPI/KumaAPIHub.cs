using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace UptimeKumaAPI
{
    public class KumaAPIHub
    {
        protected static string _baseURL = null;

        /// <summary>
        /// Main constructor of class
        /// </summary>
        /// <param name="url">URL of site with Uptime Kuma</param>
        public KumaAPIHub(string url)
        {
            _baseURL = url;
        }

        /// <summary>
        /// Get status page config
        /// </summary>
        /// <param name="statusPage">Name of status page. Default is "default"</param>
        /// <returns></returns>
        public string GetStatusPageConfig(string statusPage = "default")
        {
            var result = Request($"/api/status-page/{statusPage}");
            string answer = new StreamReader(result.GetResponseStream()).ReadToEnd();
            return JObject.Parse(answer).SelectToken("config").ToString();
        }

        protected static HttpWebResponse Request(string suburl, string parametrs = "")
        {
            return (HttpWebResponse)WebRequest.Create($"{_baseURL}{suburl}?{parametrs}").GetResponse();
        }
    }
}