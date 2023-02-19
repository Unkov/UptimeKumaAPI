using System;
using System.IO;
using System.Net;
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

        /// <summary>
        /// Get status page incident
        /// </summary>
        /// <param name="statusPage">Name of status page. Default is "default"</param>
        /// <returns></returns>
        /// <exception cref="IncidentCheckException"></exception>
        public string GetStatusPageIncident(string statusPage = "default")
        {
            var result = Request($"/api/status-page/{statusPage}");
            string answer = new StreamReader(result.GetResponseStream()).ReadToEnd();
            string status = JObject.Parse(answer).SelectToken("incident").ToString();

            if (status == "null")
                throw new IncidentCheckException();

            return status;
        }

        /// <summary>
        /// Get status page public group list
        /// </summary>
        /// <param name="statusPage">Name of status page. Default is "default"</param>
        /// <returns></returns>
        /// <exception cref="PublicGroupListCheckException"></exception>
        public string GetStatusPagePublicGroupList(string statusPage = "default")
        {
            var result = Request($"/api/status-page/{statusPage}");
            string answer = new StreamReader(result.GetResponseStream()).ReadToEnd();
            string status = JObject.Parse(answer).SelectToken("publicGroupList").ToString();

            if (status == "null")
                throw new PublicGroupListCheckException();

            return status;
        }

        /// <summary>
        /// Get monitors hearbeat list
        /// </summary>
        /// <param name="statusPage">Name of status page. Default is "default"</param>
        /// <returns></returns>
        public string GetMonitorsHearbeatList(string statusPage = "default")
        {
            var result = Request($"/api/status-page/heartbeat/{statusPage}");
            string answer = new StreamReader(result.GetResponseStream()).ReadToEnd();
            string status = JObject.Parse(answer).SelectToken("heartbeatList").ToString();

            return status;
        }

        /// <summary>
        /// Get monitors uptime list
        /// </summary>
        /// <param name="statusPage">Name of status page. Default is "default"</param>
        /// <returns></returns>
        public string GetMonitorsUptimeList(string statusPage = "default")
        {
            var result = Request($"/api/status-page/heartbeat/{statusPage}");
            string answer = new StreamReader(result.GetResponseStream()).ReadToEnd();
            string status = JObject.Parse(answer).SelectToken("uptimeList").ToString();

            return status;
        }
        
        /// <summary>
        /// Push the service
        /// </summary>
        /// <param name="code"></param>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        /// <param name="ping"></param>
        /// <returns></returns>
        /// <exception cref="PushException"></exception>
        public bool Push(string code, string status = "up", string msg = "OK", string ping = "")
        {
            var result = Request($"/api/push/{code}", $"status={status}&msg={msg}&ping={ping}");
            string answer = new StreamReader(result.GetResponseStream()).ReadToEnd();
            string pushStatus = JObject.Parse(answer).SelectToken("ok").ToString();

            if (pushStatus == "false")
                throw new PushException();

            return true;
        }

        protected static HttpWebResponse Request(string suburl, string parametrs = "")
        {
            return (HttpWebResponse)WebRequest.Create($"{_baseURL}{suburl}?{parametrs}").GetResponse();
        }
    }
}