using System.Collections.Generic;
using Newtonsoft.Json;

namespace PushSharp.Firebase.NotificationConfigs
{
    public class FirebaseAndroidNotification
    {
        /// <summary>
        /// string
        /// The notification's title. If present, it will override google.firebase.fcm.v1.Notification.title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// string
        /// The notification's body text. If present, it will override google.firebase.fcm.v1.Notification.body.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
        /// <summary>
        /// string
        /// The notification's icon. Sets the notification icon to myicon for drawable resource myicon. If you don't 
        /// send this key in the request, FCM displays the launcher icon specified in your app manifest.
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }
        /// <summary>
        /// string
        /// The notification's icon color, expressed in #rrggbb format.
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }
        /// <summary>
        /// string
        /// The sound to play when the device receives the notification.Supports "default" or the filename of a sound resource bundled 
        /// in the app.Sound files must reside in /res/raw/.
        /// </summary>
        [JsonProperty("sound")]
        public string Sound { get; set; }
        /// <summary>
        /// string
        ///
        /// Identifier used to replace existing notifications in the notification drawer.If not specified, each request creates a new notification.
        /// If specified and a notification with the same tag is already being shown, the new notification replaces the existing one in the notification drawer.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }
        /// <summary>
        /// string
        ///
        /// The action associated with a user click on the notification.If specified, an activity with a matching intent filter is launched when a user clicks on the notification.
        /// </summary>
        [JsonProperty("click_action")]
        public string Click_Action { get; set; }
        /// <summary>
        /// string
        /// 
        /// The key to the body string in the app's string resources to use to localize the body text to the user's current localization.See String Resources for more information.
        /// </summary>
        [JsonProperty("body_loc_key")]
        public string Body_Loc_Key { get; set; }
        /// <summary>
        /// string
        /// 
        /// Variable string values to be used in place of the format specifiers in body_loc_key to use to localize the body text to the user's current localization. 
        /// See Formatting and Styling for more information.
        /// </summary>
        [JsonProperty("body_loc_args")]
        public IList<string> Body_Loc_Args { get; set; }
        /// <summary>
        /// string
        /// 
        /// The key to the title string in the app's string resources to use to localize the title text to the user's current localization.See String Resources for more information.
        /// </summary>
        [JsonProperty("title_loc_key")]
        public string Title_Loc_Key { get; set; }
        /// <summary>
        /// string
        ///
        /// Variable string values to be used in place of the format specifiers in title_loc_key to use to localize the title text to the user's current localization. 
        /// See Formatting and Styling for more information.
        /// </summary>
        [JsonProperty("title_loc_args")]
        public string Title_Loc_Args { get; set; }
    }
}
