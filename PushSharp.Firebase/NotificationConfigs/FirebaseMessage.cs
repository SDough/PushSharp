using System.Collections.Generic;
using Newtonsoft.Json;

namespace PushSharp.Firebase.NotificationConfigs
{
    public class FirebaseMessage 
    {


        // Union field target can be only one of the following
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("topic")]
        public string Topic { get; set; }
        [JsonProperty("condition")]
        public string Condition { get; set; }
        // End of list of possible types for union field target

        /// <summary>
        /// string
        ///
        /// Output Only.The identifier of the message sent, in the format of projects/*/messages/{message_id}.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// map(key: string, value: string)
        ///
        /// Input only.Arbitrary key/value payload.
        /// An object containing a list of "key": value pairs. Example: { "name": "wrench", "mass": "1.3kg", "count": "3" }.
        /// </summary>
        [JsonProperty("data")]
        public IDictionary<string,string> Data { get; set; }

        /// <summary>
        /// object(Notification)
        ///
        /// Input only.Basic notification template to use across all platforms.
        /// </summary>
        [JsonProperty("notification")]
        public FirebaseNotificationGlobal Notification { get; set; }

        /// <summary>
        /// object(AndroidConfig)
        ///
        /// Input only.Android specific options for messages sent through FCM connection server.
        /// </summary>
        [JsonProperty("android")]
        public FirebaseAndroidConfig Android { get; set; }

        /// <summary>
        /// object (ApnsConfig)
        ///
        /// Input only.Apple Push Notification Service specific options.
        /// </summary>
        [JsonProperty("apns")]
        public FirebaseApnsConfig Apns { get; set; }
        
    }
}
