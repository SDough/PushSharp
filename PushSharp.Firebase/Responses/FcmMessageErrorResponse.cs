using System.Collections.Generic;
using Newtonsoft.Json;

namespace PushSharp.Firebase.Responses
{
    public enum ErrorType
    {
        FcmError,
        BadRequest
    }

    public class FcmMessageErrorResponse
    {
        [JsonProperty("error")]
        public FcmMessageErrorContents Error { get; set; }

    }

    public class FcmMessageErrorContents
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("details")]
        public IList<FcmMessageErrorDetails> Details { get; set; }
    }

    public class FcmMessageErrorDetails
    {
        private const string FCMERROR = "type.googleapis.com/google.firebase.fcm.v1.FcmError";
        private const string BADREQUEST = "type.googleapis.com/google.rpc.BadRequest";

        [JsonProperty("@type")]
        public string Type { get; set; }
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
        [JsonProperty("fieldViolations")]
        public IList<FcmMessageErrorFields> FieldViolations { get; set; }
                
        public ErrorType getType()
        {
            switch(Type)
            {
                case FCMERROR:
                    return ErrorType.FcmError;
                case BADREQUEST:
                    return ErrorType.BadRequest;
                default:
                    return ErrorType.FcmError;
            }
        }
    }

    public class FcmMessageErrorFields
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("field")]
        public string Field { get; set; }
    }
}