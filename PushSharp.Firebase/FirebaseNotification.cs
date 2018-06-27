using PushSharp.Core;
using Newtonsoft.Json;
using PushSharp.Firebase.NotificationConfigs;

namespace PushSharp.Firebase
{
    public class FirebaseNotification : INotification
    {
        public static FirebaseNotification ForSingleResult(FirebaseResponse response, int resultIndex)
        {
            return response.OriginalNotification;
        }

        public static FirebaseNotification ForSingleRegistrationId(FirebaseNotification msg, string registrationId)
        {
            var result = new FirebaseNotification();
            //result.Tag = msg.Tag;
            //result.MessageId = msg.MessageId;
            //result.RegistrationIds.Add(registrationId);
            //result.To = null;
            //result.CollapseKey = msg.CollapseKey;
            //result.Data = msg.Data;
            //result.DelayWhileIdle = msg.DelayWhileIdle;
            //result.ContentAvailable = msg.ContentAvailable;
            //result.DryRun = msg.DryRun;
            //result.Priority = msg.Priority;
            //result.NotificationKey = msg.NotificationKey;

            return result;
        }

        public FirebaseNotification()
        {
            Message = new FirebaseMessage();
        }

        [JsonProperty("message_id")]
        public string MessageId { get; internal set; }

        public bool IsDeviceRegistrationIdValid()
        {
            if (Message.Token != null) return true;
            if (Message.Topic != null) return true;
            if (Message.Condition != null) return true;
            return false;
        }

        [JsonIgnore]
        public object Tag { get; set; }

        [JsonProperty("message")]
        public FirebaseMessage Message { get; set; }


        [JsonProperty("validate_only")]
        public bool ValidateOnly { get; set; }

        internal string GetJson()
        {
            return JsonConvert.SerializeObject(this,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        public override string ToString()
        {
            return GetJson();
        }
    }

}

