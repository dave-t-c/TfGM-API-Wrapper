using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using TfGM_API_Wrapper.Controllers;
using TfGM_API_Wrapper.Models.Resources;
using TfGM_API_Wrapper.Models.Stops;

namespace TfGM_API_Wrapper_Tests.TestControllers;

/// <summary>
///     Test class for the StopsController class
/// </summary>
public class TestStopsController
{
    private ResourcesConfig? _resourcesConfig;
    private ImportedResources? _importedResources;
    private IStopsDataModel? _stopsDataModel;
    private StopsController? _testStopController;

    [SetUp]
    public void Setup()
    {
        _resourcesConfig = new ResourcesConfig
        {
            StopResourcePath = "../../../Resources/ValidStopLoader.json",
            StationNamesToTlarefsPath = "../../../Resources/Station_Names_to_TLAREFs.json",
            TlarefsToIdsPath = "../../../Resources/TLAREFs_to_IDs.json"
        };
        _importedResources = new ResourceLoader(_resourcesConfig).ImportResources();
        _stopsDataModel = new StopsDataModel(_importedResources);
        _testStopController = new StopsController(_stopsDataModel);
    }

    /// <summary>
    ///     Reset the test Stop Controller to clear any changes made
    ///     during the tests.
    /// </summary>
    [TearDown]
    public void Teardown()
    {
        _testStopController = null;
        _resourcesConfig = null;
        _importedResources = null;
        _stopsDataModel = null;
        _testStopController = null;
    }

    /// <summary>
    ///     Test to try and get the expected 200 result code
    ///     from the GetAllStops method.
    /// </summary>
    [Test]
    public void TestGetAllStopsExpectedResultCode()
    {
        var result = _testStopController!.GetAllStops();
        Assert.IsNotNull(result);

        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual(200, okResult!.StatusCode);
    }

    /// <summary>
    ///     Test the length of the returned Stops list.
    ///     This should be 1, as there is only a single Stop in the
    ///     StopLoader file.
    /// </summary>
    [Test]
    public void TestGetExpectedStopsCount()
    {
        var result = _testStopController!.GetAllStops();
        Assert.IsNotNull(result);

        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        var retrievedStops = okResult!.Value as List<Stop> ?? new List<Stop>();
        Assert.AreEqual(1, retrievedStops.Count);
    }
}