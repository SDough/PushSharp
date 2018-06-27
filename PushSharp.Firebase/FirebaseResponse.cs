using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PushSharp.Firebase
{
    public class FirebaseResponse
    {
        public FirebaseResponse()
        {
            OriginalNotification = null;
            ResponseCode = FirebaseResponseCode.Ok;
        }

        [JsonIgnore]
        public FirebaseNotification OriginalNotification { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public FirebaseResponseCode ResponseCode { get; set; }
    }

    public enum FirebaseResponseCode
    {
        Ok,
        Error,
        BadRequest,
        ServiceUnavailable,
        InvalidAuthToken,
        InternalServiceError
    }

    public enum FirebaseResponseStatus
    {
        [EnumMember(Value = "Ok")]
        Ok,

        [EnumMember(Value = "UNSPECIFIED_ERROR")]
        Error,

        [EnumMember(Value = "INVALID_ARGUMENT")]
        Invalid_Argument,

        [EnumMember(Value = "UNREGISTERED")]
        Unregistered,

        [EnumMember(Value = "SENDER_ID_MISMATCH")]
        SenderIdMismatch,

        [EnumMember(Value = "QUOTA_EXCEEDED")]
        QuotaExceeded,

        [EnumMember(Value = "APNS_AUTH_ERROR")]
        ApnsAuthError,

        [EnumMember(Value = "UNAVAILABLE")]
        Unavailable,

        [EnumMember(Value = "INTERNAL")]
        Internal
    }
}

