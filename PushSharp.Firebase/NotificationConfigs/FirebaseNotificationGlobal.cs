using Newtonsoft.Json;

namespace PushSharp.Firebase.NotificationConfigs
{
    public class FirebaseNotificationGlobal
    {

        /// <summary>
        /// string
        ///
        /// The notification's title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// string
        ///
        /// The notification's body text.
        /// </summary>
        [JsonProperty("body")]
        public string body { get; set; }

    }
}
