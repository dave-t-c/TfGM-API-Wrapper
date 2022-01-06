using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TfGM_API_Wrapper.Models;

namespace TfGM_API_Wrapper.Controllers
{
    [Route("/api/stops")]
    [ApiController]
    public class StopsController : Controller
    {
        private readonly List<Stop> _stops;

        /// <summary>
        /// Controller Constructor that allows for custom stops path file location.
        /// This can be used for testing the controller.
        /// Default = Default location for stop data file. This should ideally be
        /// extracted to the properties file.
        /// </summary>
        /// <param name="stopsPath">Path for Stop data, relative to the the base directory.</param>
        /// <param name="config">ResourcesConfig - Configuration for resources location</param>
        public StopsController(IOptions<ResourcesConfig> config)
        {
            StopLoader stopLoader = new StopLoader(config.Value);
            _stops = stopLoader.ImportStops();
        }
        
        /// <summary>
        /// Returns a JSON List of all Stops.
        /// </summary>
        /// <returns>JSON List -> Stop</returns>
        [Route("/api/stops")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult GetAllStops()
        {
            return Ok(_stops);
        }

        
    }
}