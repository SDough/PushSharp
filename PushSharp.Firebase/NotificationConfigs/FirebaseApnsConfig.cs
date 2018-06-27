using Newtonsoft.Json;

namespace PushSharp.Firebase.NotificationConfigs
{
    public class FirebaseApnsConfig
    {
        /// <summary>
        /// map (key: string, value: string)
        ///
        /// HTTP request headers defined in Apple Push Notification Service.Refer to APNs 
        /// request headers for supported headers, e.g. "apns-priority": "10".
        ///
        /// An object containing a list of "key": value pairs. Example: { "name": "wrench", "mass": "1.3kg", "count": "3" }.
        /// </summary>
        [JsonProperty("headers")]
        public FirebaseApnsHeaders Headers { get; set; }

        /// <summary>
        /// object (Struct format)
        ///
        /// APNs payload as a JSON object, including both aps dictionary and custom payload.See Payload Key Reference.
        /// If present, it overrides google.firebase.fcm.v1.Notification.title and google.firebase.fcm.v1.Notification.body.
        /// </summary>
        [JsonProperty("payload")]
        public FirebaseApnsPayload Payload { get; set; }

    }
}
