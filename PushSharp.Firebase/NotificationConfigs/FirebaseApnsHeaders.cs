using Newtonsoft.Json;

namespace PushSharp.Firebase.NotificationConfigs
{
    public class FirebaseApnsHeaders
    {

        /// <summary>
        /// The provider token that authorizes APNs to send push notifications for the specified topics. The token is in Base64URL-encoded JWT format, 
        /// specified as bearer <provider token>.
        ///
        /// When the provider certificate is used to establish a connection, this request header is ignored.
        /// </summary>
        [JsonProperty("authorization")]
        public string Authorization { get; set; }

        /// <summary>
        /// A canonical UUID that identifies the notification. If there is an error sending the notification, APNs uses this value to identify the 
        /// notification to your server.
        ///
        /// The canonical form is 32 lowercase hexadecimal digits, displayed in five groups separated by hyphens in the form 8-4-4-4-12. 
        /// An example UUID is as follows: 123e4567-e89b-12d3-a456-42665544000
        ///
        /// If you omit this header, a new UUID is created by APNs and returned in the response.
        /// </summary>
        [JsonProperty("apns-id")]
        public string Apns_ID { get; set; }

        /// <summary>
        /// A UNIX epoch date expressed in seconds (UTC). This header identifies the date when the notification is no longer valid and can be discarded.
        ///
        /// If this value is nonzero, APNs stores the notification and tries to deliver it at least once, repeating the attempt as needed if it is unable 
        /// to deliver the notification the first time. If the value is 0, APNs treats the notification as if it expires immediately and does not store 
        /// the notification or attempt to redeliver it.
        /// 
        /// </summary>
        [JsonProperty("apns-expiration")]
        public string Apns_Expiration { get; set; }

        /// <summary>
        /// The priority of the notification. Specify one of the following values:
        /// 
        /// 10–Send the push message immediately.Notifications with this priority must trigger an alert, sound, or badge on the target device. It is an error 
        /// to use this priority for a push notification that contains only the content-available key.
        /// 
        /// 5—Send the push message at a time that takes into account power considerations for the device. Notifications with this priority might be grouped 
        /// and delivered in bursts.They are throttled, and in some cases are not delivered.
        /// 
        /// If you omit this header, the APNs server sets the priority to 10.
        /// </summary>
        [JsonProperty("apns-priority")]
        public string Apns_Priority { get; set; }

        /// <summary>
        /// The topic of the remote notification, which is typically the bundle ID for your app. The certificate you create in your developer account must 
        /// include the capability for this topic.
        ///
        /// If your certificate includes multiple topics, you must specify a value for this header.
        /// 
        /// If you omit this request header and your APNs certificate does not specify multiple topics, the APNs server uses the certificate’s Subject as 
        /// the default topic.
        /// 
        /// If you are using a provider token instead of a certificate, you must specify a value for this request header. The topic you provide should be 
        /// provisioned for the your team named in your developer account.
        /// </summary>
        [JsonProperty("apns-topic")]
        public string Apns_Topic { get; set; }

        /// <summary>
        /// Multiple notifications with the same collapse identifier are displayed to the user as a single notification. The value of this key must not 
        /// exceed 64 bytes. For more information, see Quality of Service, Store-and-Forward, and Coalesced Notifications.
        /// </summary>
        [JsonProperty("apns-collapse-id")]
        public string Apns_Collapse_ID { get; set; }

    }
}
