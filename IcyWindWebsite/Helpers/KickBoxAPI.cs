using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IcyWindWebsite.Helpers
{
    public class KickBoxAPI
    {
        public const string APIKey = "";

        public static KickBoxEmailResult CheckEmail(string address)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync($"https://api.kickbox.io/v2/verify?email={address}&apikey={APIKey}").Result;
                return JsonConvert.DeserializeObject<KickBoxEmailResult>(result);
            }
        }
    }

    public class KickBoxEmailResult
    {
        public string result { get; set; }
        public string reason { get; set; }
        public bool role { get; set; }
        public bool free { get; set; }
        public bool disposable { get; set; }
        public bool accept_all { get; set; }
        public string did_you_mean { get; set; }
        public int sendex { get; set; }
        public string email { get; set; }
        public string user { get; set; }
        public string domain { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}
