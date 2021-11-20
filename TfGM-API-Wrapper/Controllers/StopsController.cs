using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TfGM_API_Wrapper.Models;

using static System.AppDomain;

namespace TfGM_API_Wrapper.Controllers
{
    [Route("/api/stops")]
    [ApiController]
    public class StopsController : Controller
    {
        private List<Stop> _stops;
        
        /// <summary>
        /// Returns a JSON List of all Stops.
        /// </summary>
        /// <returns>JSON List -> Stop</returns>
        [Route("/api/stops")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult GetAllStops()
        {
            if (_stops == null)
            {
                ImportStops();
            }
            return Ok(_stops);
        }

        /// <summary>
        /// Imports the Stops from the Stops resources file.
        /// The results from this are then returned with a GET to '/api/stops'.
        /// </summary>
        private void ImportStops()
        {
            using var reader = new StreamReader(CurrentDomain.BaseDirectory + "Resources/Stops.json");
            var jsonString = reader.ReadToEnd();
            _stops = JsonConvert.DeserializeObject<List<Stop>>(jsonString);
        }
    }
}