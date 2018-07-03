using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using PushSharp.Core;
using System.Linq;
using System.Runtime.Serialization;
using PushSharp.Firebase.Responses;
using Newtonsoft.Json;
using System.IO;
using Google.Apis.Auth.OAuth2;

namespace PushSharp.Firebase
{
    public class FirebaseServiceConnectionFactory : IServiceConnectionFactory<FirebaseNotification>
    {
        public FirebaseServiceConnectionFactory(FirebaseConfiguration configuration)
        {
            Configuration = configuration;
        }

        public FirebaseConfiguration Configuration { get; private set; }

        public IServiceConnection<FirebaseNotification> Create()
        {
            return new FirebaseServiceConnection(Configuration);
        }
    }

    public class FirebaseServiceBroker : ServiceBroker<FirebaseNotification>
    {
        public FirebaseServiceBroker(FirebaseConfiguration configuration) : base (new FirebaseServiceConnectionFactory(configuration))
        {
        }
    }

    public class FirebaseServiceConnection : IServiceConnection<FirebaseNotification>
    {

        public FirebaseServiceConnection(FirebaseConfiguration configuration)
        {
            Configuration = configuration;
            http = configuration.generateCleanHTTP();
            UnauthenticatedTries = 0;
        }

        public FirebaseConfiguration Configuration { get; private set; }
        private HttpClient http;
        private int UnauthenticatedTries;

        public async Task Send(FirebaseNotification notification)
        {
            var json = notification.GetJson();
            var content = new StringContent(json, null, "application/json");
            var response = await http.PostAsync(Configuration.FirebaseUrl, content);

            if (response.IsSuccessStatusCode)
            {
                await processResponseOk(response, notification).ConfigureAwait(false);
            }
            else
            {
                await processResponseError(response, notification).ConfigureAwait(false);
            }
        }

        async Task processResponseOk (HttpResponseMessage httpResponse, FirebaseNotification notification)
        {
            var multicastResult = new FirebaseMulticastResultException();

            var result = new FirebaseResponse() {
                ResponseCode = FirebaseResponseCode.Ok,
                OriginalNotification = notification,                
            };

            var str = await httpResponse.Content.ReadAsStringAsync ();
            result.Name = JObject.Parse (str).ToString(); 

            Log.Info($"FCM: Response ok: {result.Name} ID: {result.OriginalNotification.Message.Token}");

            return;
            
        }

        async Task processResponseError(HttpResponseMessage httpResponse, FirebaseNotification notification)
        {

            var responseBody = await httpResponse.Content.ReadAsStringAsync();

            FcmMessageErrorResponse response = JsonConvert.DeserializeObject<FcmMessageErrorResponse>(responseBody, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            //401 bad auth token
            if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                if(response.Error.status == "UNAUTHENTICATED")
                {
                    if (UnauthenticatedTries <= Configuration.AuthenticatedTries)
                    {
                        http = Configuration.generateCleanHTTP();
                        UnauthenticatedTries++;
                        await Send(notification).ConfigureAwait(false);
                    } else
                    {
                        Log.Error($"Firebase Authorization Failed");
                        throw new UnauthorizedAccessException("Firebase Authorization Failed");
                    }
                }                
            }

            UnauthenticatedTries = 0;

            if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                Log.Error($"HTTP 400 Bad Request {responseBody}");

                foreach (var r in response.Error.Details)
                {
                    switch (r.getType())
                    {
                        case ErrorType.BadRequest:
                            {
                                foreach (var f in r.FieldViolations)
                                {
                                    if (f.Description == "Invalid registration token")
                                    {

                                        throw new DeviceSubscriptionExpiredException(notification)
                                        {
                                            OldSubscriptionId = notification.Message.Token
                                        };
                                    }
                                }
                                break;
                            }
                    }
                }

                throw new FirebaseNotificationException(notification, "HTTP 400 Bad Request", response);
                
            }

            if (response.Error.Code == 404)
            {
                Log.Error($"HTTP 404 Not Found {responseBody}");

                foreach (var r in response.Error.Details)
                {
                    switch (r.getType())
                    {
                        case ErrorType.FcmError:
                            {
                                // They have more then likely removed the app so go down the same route to delete the token from the system
                                if (r.ErrorCode == "UNREGISTERED")
                                {
                                    throw new DeviceSubscriptionExpiredException(notification)
                                    {
                                        OldSubscriptionId = notification.Message.Token
                                    };
                                }
                                break;
                            }
                    }
                }
            }

            Log.Error($"Firebase-Send:{httpResponse.StatusCode} Error:{responseBody}");
            throw new FirebaseNotificationException(notification, "Firebase HTTP Error: " + responseBody, response);

        }
    }
}
