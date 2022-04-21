using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TfGM_API_Wrapper.Models;
using TfGM_API_Wrapper.Models.Resources;
using TfGM_API_Wrapper.Models.Services;

namespace TfGM_API_Wrapper.Controllers;

/// <summary>
///     Controller for handling service requests.
/// </summary>
[Route("/api/services")]
[ApiController]
public class ServiceController : Controller
{
    private readonly IConfiguration _config;
    private readonly WrapperDataModel _dataModel;
    private readonly ResourcesConfig _resourcesConfig;

    /// <summary>
    ///     Secrets, such as access keys from the dotnet user-secrets storage
    ///     are loaded into the IConfiguration on start up.
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
        FormattedServices result;
        try
        {
            result = _dataModel.RequestServices(stop);
        }
        catch (ArgumentException)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { message = "Invalid Stop Name or TLAREF" });
        }
        catch (Exception)
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        return Ok(result);
    }
}