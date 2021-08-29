using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using TestAutomation.Framework.Utils;
using TestAutomation.Report;

namespace TestAutomation.ApiManager
{
    public class RestHandler
    {
        public string ApiUrl { get; set; }

        public RestHandler(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

        public IRestResponse<T> Execute<T>(RestRequest request)
        {
            var client =  new RestClient()
            {
                BaseUrl = new Uri(ApiUrl)
            };

            client.UseNewtonsoftJson();

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.";
                throw new AutomationException(message, response.ErrorException);
            }

            Logger.AddStep($"API Status: Status [{response.StatusCode}]");
            Logger.AddStep($"API Method: Method [{request.Method}]; ");
            Logger.AddStep($"API Resource: Resource [{request.Resource}];");
            Logger.AddStep($"API Header: Resource [{string.Join(", ", response.Headers)}];");

            return response;
        }

        //public string GetError(string response)
        //{
        //    return JsonHandler.Deserialize<ApiResponse>(response).Error;
        //}

        public IRestResponse<T> Get<T>(string endpoint)
        {
            var request = new RestRequest
            {
                Resource = endpoint,
            };

            return Execute<T>(request);
        }

        public IRestResponse<T> Post<T>(string endpoint, object objectRequest)
        {
            var request = new RestRequest
            {
                Resource = endpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json,

            };

            request.AddJsonBody(objectRequest);

            return Execute<T>(request);
        }
    }
}
