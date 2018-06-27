using Newtonsoft.Json;

namespace PushSharp.Firebase
{
    public class FirebaseMessageResult
    {
        [JsonProperty("message_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MessageId { get; set; }

        [JsonProperty("registration_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CanonicalRegistrationId { get; set; }

        [JsonIgnore]
        public FirebaseResponseStatus ResponseStatus { get; set; }

        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error
        {
            get 
            {
                switch (ResponseStatus)
                {
                case FirebaseResponseStatus.Ok:
                    return null;
                case FirebaseResponseStatus.Unavailable:
                    return "Unavailable";
                case FirebaseResponseStatus.QuotaExceeded:
                    return "QuotaExceeded";
                case FirebaseResponseStatus.ApnsAuthError:
                    return "ApnsAuthError";
                case FirebaseResponseStatus.Internal:
                    return "Internal";
                case FirebaseResponseStatus.Invalid_Argument:
                    return "Invalid_Argument";
                case FirebaseResponseStatus.SenderIdMismatch:
                    return "SenderIdMismatch";
                case FirebaseResponseStatus.Unregistered:
                    return "Unregistered";
                case FirebaseResponseStatus.Error:
                    return "Error";
                default:
                    return null;
                }
            }
        }
    }
}
