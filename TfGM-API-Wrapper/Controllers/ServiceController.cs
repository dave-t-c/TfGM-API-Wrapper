using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TfGM_API_Wrapper.Models;
using TfGM_API_Wrapper.Models.Resources;
using TfGM_API_Wrapper.Models.Services;

namespace TfGM_API_Wrapper.Controllers
{
    /// <summary>
    /// Controller for handling service requests.
    /// </summary>
    [Route("/api/services")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ResourcesConfig _resourcesConfig;
        private readonly WrapperDataModel _dataModel;

        /// <summary>
        /// Secrets, such as access keys from the dotnet user-secrets storage
        /// are loaded into the IConfiguration on start up.
        /// </summary>
        /// <param name="config">Configuration loaded by </param>
        /// <param name="resources">Resource Config for loading stop related resources.</param>
        public ServiceController(IConfiguration config, IOptions<ResourcesConfig> resources)
        {
            _config = config;
            _resourcesConfig = resources.Value;
            _dataModel = new WrapperDataModel(_resourcesConfig, new ServiceRequester(_config));
        }

        [Route("/api/services/{stop}")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult GetService(string stop)
        {
            // TODO Add correct handling for invalid tlarefs / names
            return Ok(_dataModel.RequestServices(stop));
        }
    }
}