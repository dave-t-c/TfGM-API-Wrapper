using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TfGM_API_Wrapper.Models;

namespace TfGM_API_Wrapper.Controllers
{
    [Route("/api/stops")]
    [ApiController]
    public class StopsController : Controller
    {
        private readonly List<Stop> _stops;
        private const string DefaultStopsPath = "Resources/Stops.json";

        /// <summary>
        /// Constructor used service started, called when configuring service.
        /// </summary>
        public StopsController()
        {
            StopLoader stopLoader = new StopLoader(DefaultStopsPath);
            _stops = stopLoader.ImportStops();
        }

        /// <summary>
        /// Allows for custom stops path file location.
        /// This can be used for testing the controller.
        /// </summary>
        /// <param name="stopsPath">Path for Stop data, relative the the base directory.</param>
        public StopsController(string stopsPath)
        {
            StopLoader stopLoader = new StopLoader(stopsPath);
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