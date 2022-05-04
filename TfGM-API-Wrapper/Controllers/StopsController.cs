using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using TfGM_API_Wrapper.Models;
using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper.Controllers;

/// <summary>
/// Controller for Stops related information
/// </summary>
[Route("/api/stops")]
[ApiController]
public class StopsController : Controller
{
    private readonly ImportedResources _importedResources;

    /// <summary>
    ///     Controller Constructor that allows for custom stops path file location.
    ///     This can be used for testing the controller.
    ///     Default = Default location for stop data file. This should ideally be
    ///     extracted to the properties file.
    /// </summary>
    /// <param name="config">ResourcesConfig - Configuration for resources location</param>
    public StopsController(IOptions<ResourcesConfig> config)
    {
        var resourceConfig = config.Value;
        var wrapperDataModel = new WrapperDataModel(resourceConfig);
        _importedResources = wrapperDataModel.ImportResources();
    }

    /// <summary>
    ///     Returns a JSON List of all Stops.
    /// </summary>
    /// <returns>JSON List -> Stop</returns>
    [Route("/api/stops")]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet]
    public IActionResult GetAllStops()
    {
        return Ok(_importedResources.ImportedStops);
    }
}