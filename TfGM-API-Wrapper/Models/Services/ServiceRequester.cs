using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace TfGM_API_Wrapper.Models.Services
{
    public class ServiceRequester : IRequester
    {
        private static IConfiguration _config;
        public ServiceRequester(IConfiguration config = null)
        {
            _config = config;
        }

        public List<UnformattedServices> RequestServices(List<int> ids)
        {
            List<UnformattedServices> unformattedServices = new List<UnformattedServices>();
            foreach (int id in ids)
            {
                unformattedServices.Add(RequestId(id).Result);
            }

            return unformattedServices;
        }

        private static async Task<UnformattedServices> RequestId(int id)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config["OcpApimSubscriptionKey"]);

            var uri = $"https://api.tfgm.com/odata/Metrolinks({id})";

            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UnformattedServices>(responseJson);
        }
    }
}