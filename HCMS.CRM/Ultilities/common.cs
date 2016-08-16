using HCMS.CRM.Helpers;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HCMS.CRM.Ultilities
{
    class common
    {
        #region API Helpers
        public static async Task<IRestResponse> getApi(string contentType, string apiName, List<ApiParameter> parameters)
        {
            var client = new RestClient(App.baseWebAPIAddress);

            var request = new RestRequest(apiName, Method.GET);// apiName/{id}
            request.JsonSerializer.ContentType = contentType;
            request.AddHeader("Content-Type", contentType);
            foreach (var param in parameters)
            {
                request.AddParameter(param.Key, param.Value);
            }

            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();

            client.ExecuteAsync(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    const string message = "Error retrieving response.";
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });
            return await taskCompletionSource.Task;
        }

        /*
         * contentType = "application/json" || "application/x-www-form-urlencoded" ||
         *          
        */
        public static async Task<IRestResponse> postApi(string contentType, string apiName, List<ApiParameter> parameters)
        {
            var client = new RestClient(App.baseWebAPIAddress);            

            var request = new RestRequest(apiName, Method.POST);// apiName/{id}
            request.JsonSerializer.ContentType = contentType;
            request.AddHeader("Content-Type", contentType);
            foreach (var param in parameters)
            {
                request.AddParameter(param.Key, param.Value);
            }
            
            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();

            client.ExecuteAsync(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    const string message = "Error retrieving response.";
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });
            return await taskCompletionSource.Task;
        }

        #endregion

        #region JSON Helpers
        /*
         * [{"name":"e1","data":[{"a":""},{"b":""}]}]
        */
        public static JObject getJObject(string name, JArray lstObj)
        {
            foreach (JObject obj in lstObj)
            {
                if (obj["name"].ToString() == name)
                {
                    return obj;
                }
            }
            return null;
        }

        public static JArray sortJArray(string sortBy, JArray array) {
            return new JArray(array.OrderBy(obj => (string)obj[sortBy]));
        }
        #endregion
    }
}
