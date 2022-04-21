using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace TfGM_API_Wrapper.Models.Services;

public class ServiceRequester : IRequester
{
    private readonly IConfiguration _config;

    public ServiceRequester(IConfiguration config = null)
    {
        _config = config;
    }

    public List<UnformattedServices> RequestServices(List<int> ids)
    {
        var unformattedServices = new List<UnformattedServices>();
        foreach (var id in ids) unformattedServices.Add(RequestId(id).Result);

        return unformattedServices;
    }

    private async Task<UnformattedServices> RequestId(int id)
    {
        var client = new HttpClient();

        // Request headers
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config["OcpApimSubscriptionKey"]);

        var uri = $"https://api.tfgm.com/odata/Metrolinks({id})";

        var response = await client.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseJson = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UnformattedServices>(responseJson);
    }
}