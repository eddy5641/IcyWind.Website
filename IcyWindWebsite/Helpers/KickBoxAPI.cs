using Newtonsoft.Json;
using System.Net.Http;

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
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("role")]
        public bool Role { get; set; }

        [JsonProperty("free")]
        public bool Free { get; set; }

        [JsonProperty("disposable")]
        public bool Disposable { get; set; }

        [JsonProperty("accept_all")]
        public bool AcceptAll { get; set; }

        [JsonProperty("did_you_mean")]
        public string DidYouMean { get; set; }

        [JsonProperty("sendex")]
        public int Sendex { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
