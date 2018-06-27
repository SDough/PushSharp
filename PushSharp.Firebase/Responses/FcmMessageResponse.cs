using Newtonsoft.Json;

namespace PushSharp.Firebase.Responses
{
    public class FcmMessageResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}