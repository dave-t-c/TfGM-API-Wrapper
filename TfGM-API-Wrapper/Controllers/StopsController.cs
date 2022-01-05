using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TfGM_API_Wrapper.Models;

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
            if (_stops != null) return Ok(_stops);
            
            var stopLoader = new StopLoader("Resources/Stops.json");
            _stops = stopLoader.ImportStops();
            return Ok(_stops);
        }

        
    }
}