using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using Google.Apis.Auth.OAuth2;
using System;
using System.Net.Http.Headers;

namespace PushSharp.Firebase
{
    public class FirebaseConfiguration
    {        
        public FirebaseConfiguration(string JSONKeyFileName, string projectID)
        {
            FirebaseUrl = $"https://fcm.googleapis.com/v1/projects/{projectID}/messages:send";
            FileName = JSONKeyFileName;
            ValidateServerCertificate = false;

            // Default to 10 tries
            AuthenticatedTries = 10;
        }

        public bool ValidateServerCertificate { get; set; }

        public string FirebaseUrl { get; set; }

        private string FileName { get; set; }

        public int AuthenticatedTries { get; set; }

        public HttpClient generateCleanHTTP()
        {
            var token = GetAccessTokenFromJSONKey(
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName),
                new string[] { "https://www.googleapis.com/auth/firebase.messaging", "https://www.googleapis.com/auth/cloud-platform" }).Result;

            HttpClient rValue = new HttpClient();

            rValue.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
            rValue.DefaultRequestHeaders.ConnectionClose = true;

            return rValue;
        }

        public static async Task<string> GetAccessTokenFromJSONKey(string jsonKeyFilePath, params string[] scopes)
        {
            using (var stream = new FileStream(jsonKeyFilePath, FileMode.Open, FileAccess.Read))
            {
                var credential = GoogleCredential.FromStream(stream).CreateScoped(scopes);
                return await credential.UnderlyingCredential.GetAccessTokenForRequestAsync().ConfigureAwait(false);

            }

        }
    }
}

