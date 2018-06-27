using Newtonsoft.Json;

namespace PushSharp.Firebase.NotificationConfigs
{
    public class FirebaseApnsPayloadAPS
    {
        /// <summary>
        /// Include this key when you want the system to display a standard alert or a banner. The notification settings for your app on the user’s 
        /// device determine whether an alert or banner is displayed. The preferred value for this key is a dictionary, the keys for which are listed 
        /// in Table 9-2. If you specify a string as the value of this key, that string is displayed as the message text of the alert or banner.
        /// 
        /// The JSON \U notation is not supported. Put the actual UTF-8 character in the alert text instead.
        /// </summary>
        [JsonProperty("alert")]
        public string Alert { get; set; }
        /// <summary>
        /// Include this key when you want the system to modify the badge of your app icon.
        /// If this key is not included in the dictionary, the badge is not changed. To remove the badge, set the value of this key to 0.
        /// </summary>
        [JsonProperty("badge")]
        public string Badge { get; set; }
        /// <summary>
        /// Include this key when you want the system to play a sound. The value of this key is the name of a sound file in your app’s main bundle 
        /// or in the Library/Sounds folder of your app’s data container. If the sound file cannot be found, or if you specify defaultfor the value, 
        /// the system plays the default alert sound. For details about providing sound files for notifications; see Preparing Custom Alert Sounds.
        /// </summary>
        [JsonProperty("sound")]
        public string Sound { get; set; }
        /// <summary>
        /// Include this key with a value of 1 to configure a background update notification. When this key is present, the system wakes up your app in 
        /// the background and delivers the notification to its app delegate. For information about configuring and handling background update notifications, 
        /// see Configuring a Background Update Notification.
        /// </summary>
        [JsonProperty("content-available")]
        public string Content_Available { get; set; }
        /// <summary>
        /// Provide this key with a string value that represents the notification’s type. This value corresponds to the value in the identifier property of one 
        /// of your app’s registered categories.To learn more about using custom actions, see Configuring Categories and Actionable Notifications.
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }
        /// <summary>
        /// Provide this key with a string value that represents the app-specific identifier for grouping notifications. If you provide a Notification Content 
        /// app extension, you can use this value to group your notifications together. For local notifications, this key corresponds to the threadIdentifier 
        /// property of the UNNotificationContent object.
        /// </summary>
        [JsonProperty("thread-id")]
        public string Thread_Id { get; set; }
    }
}
