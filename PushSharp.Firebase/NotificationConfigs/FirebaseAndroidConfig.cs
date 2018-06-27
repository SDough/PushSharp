using System.Collections.Generic;
using Newtonsoft.Json;

namespace PushSharp.Firebase.NotificationConfigs
{
    public class FirebaseAndroidConfig
    {
        /// <summary>
        /// string
        ///
        /// An identifier of a group of messages that can be collapsed, so that only the last message gets sent when 
        /// delivery can be resumed.A maximum of 4 different collapse keys is allowed at any given time.
        /// </summary>
        [JsonProperty("collapse_key")]
        public string Collapse_Key { get; set; }

        /// <summary>
        /// enum(AndroidMessagePriority)
        ///
        /// Message priority.Can take "normal" and "high" values.For more information, see Setting the priority of a message.
        /// </summary>
        [JsonProperty("priority")]
        public string Priority { get; set; }

        /// <summary>
        /// string (Duration format)
        ///
        /// How long (in seconds) the message should be kept in FCM storage if the device is offline.The maximum time to live 
        /// supported is 4 weeks, and the default value is 4 weeks if not set.Set it to 0 if want to send the message immediately. 
        /// In JSON format, the Duration type is encoded as a string rather than an object, where the string ends in the suffix "s" 
        /// (indicating seconds) and is preceded by the number of seconds, with nanoseconds expressed as fractional seconds. 
        /// For example, 3 seconds with 0 nanoseconds should be encoded in JSON format as "3s", while 3 seconds and 1 nanosecond 
        /// should be expressed in JSON format as "3.000000001s". The ttl will be rounded down to the nearest second.
        ///
        /// A duration in seconds with up to nine fractional digits, terminated by 's'. Example: "3.5s".
        /// </summary>
        [JsonProperty("ttl")]
        public string TimeToLive { get; set; }

        /// <summary>
        /// string
        ///
        /// Package name of the application where the registration tokens must match in order to receive the message.
        /// </summary>
        [JsonProperty("restricted_package_name")]
        public string Restricted_Package_Name { get; set; }

        /// <summary>
        /// map (key: string, value: string)
        ///
        /// Arbitrary key/value payload.If present, it will override google.firebase.fcm.v1.Message.data.
        /// An object containing a list of "key": value pairs.Example: { "name": "wrench", "mass": "1.3kg", "count": "3" }.
        /// </summary>
        [JsonProperty("data")]
        public IDictionary<string,string> Data { get; set; }

        /// <summary>
        /// object(AndroidNotification)
        /// Notification to send to android devices.
        /// </summary>
        [JsonProperty("notification")]
        public FirebaseAndroidNotification Notification { get; set; }

    }
}
