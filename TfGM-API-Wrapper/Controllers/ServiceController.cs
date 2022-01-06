using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TfGM_API_Wrapper.Models;

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

        /// <summary>
        /// Secrets, such as access keys from the dotnet user-secrets storage
        /// are loaded into the IConfiguration on start up.
        /// </summary>
        /// <param name="config">Configuration loaded by </param>
        public ServiceController(IConfiguration config)
        {
            _config = config;
        }

        [Route("/api/services")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult GetService()
        {
            return Ok();
        }
    }
}