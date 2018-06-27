using System.Collections.Generic;
using Newtonsoft.Json;

namespace PushSharp.Firebase.NotificationConfigs
{
    public class FirebaseApnsPayloadAlert
    {
        /// <summary>
        /// A short string describing the purpose of the notification. Apple Watch displays this string as part of the notification interface. 
        /// This string is displayed only briefly and should be crafted so that it can be understood quickly. This key was added in iOS 8.2.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// The text of the alert message.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
        /// <summary>
        /// The key to a title string in the Localizable.strings file for the current localization. The key string can be formatted 
        /// with %@ and %n$@ specifiers to take the variables specified in the title-loc-args array. See Localizing the Content of Your 
        /// Remote Notifications for more information. This key was added in iOS 8.2. 
        /// </summary>
        [JsonProperty("title-loc-key")]
        public string Title_Loc_Key { get; set; }
        /// <summary>
        /// Variable string values to appear in place of the format specifiers in title-loc-key. See Localizing the Content of Your 
        /// Remote Notifications for more information. This key was added in iOS 8.2.
        /// </summary>
        [JsonProperty("title-loc-args")]
        public string Title_Loc_Args { get; set; }
        /// <summary>
        /// If a string is specified, the system displays an alert that includes the Close and View buttons. The string is used as a 
        /// key to get a localized string in the current localization to use for the right button’s title instead of “View”. See Localizing the 
        /// Content of Your Remote Notifications for more information.
        /// </summary>
        [JsonProperty("action-loc-key")]
        public string Action_Loc_Key { get; set; }
        /// <summary>
        /// A key to an alert-message string in a Localizable.strings file for the current localization (which is set by the user’s language preference). 
        /// The key string can be formatted with %@ and %n$@ specifiers to take the variables specified in the loc-args array.See Localizing the Content 
        /// of Your Remote Notifications for more information.
        /// </summary>
        [JsonProperty("loc-key")]
        public string Loc_Key { get; set; }
        /// <summary>
        /// Variable string values to appear in place of the format specifiers in loc-key.See Localizing the Content of Your Remote 
        /// Notifications for more information.
        /// </summary>
        [JsonProperty("loc-args")]
        public IList<string> Loc_Args { get; set; }
        /// <summary>
        /// The filename of an image file in the app bundle, with or without the filename extension. The image is used as the launch image when users 
        /// tap the action button or move the action slider. If this property is not specified, the system either uses the previous snapshot, uses the image 
        /// identified by the UILaunchImageFile key in the app’s Info.plist file, or falls back to Default.png.
        /// </summary>
        [JsonProperty("launch-image")]
        public string Launch_Image { get; set; }
    }
}
