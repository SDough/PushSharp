using System.Collections.Generic;
using Newtonsoft.Json;

namespace PushSharp.Firebase.NotificationConfigs
{
    public class FirebaseApnsPayload
    {
        /// <summary>
        /// Provide this key with a string value that represents the app-specific identifier for grouping notifications. If you provide a Notification Content 
        /// app extension, you can use this value to group your notifications together. For local notifications, this key corresponds to the threadIdentifier 
        /// property of the UNNotificationContent object.
        /// </summary>
        [JsonProperty("aps")]
        public FirebaseApnsPayloadAPS aps { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> CustomData { get; set; }
    }
}
