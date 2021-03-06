using System.Diagnostics;
using NUnit.Framework;
using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper_Tests.TestModels.TestResources;

public class TestResourceLoader
{
    private const string StopResourcePathConst = "../../../Resources/ValidStopLoader.json";
    private const string StationNamesToTlarefsPath = "../../../Resources/Station_Names_to_TLAREFs.json";
    private const string TlarefsToIdsPath = "../../../Resources/TLAREFs_to_IDs.json";
    private ResourceLoader? _resourceLoader;
    private ResourcesConfig? _validResourcesConfig;

    /// <summary>
    ///     Set up the valid config and test variables.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _validResourcesConfig = new ResourcesConfig
        {
            StopResourcePath = StopResourcePathConst,
            StationNamesToTlarefsPath = StationNamesToTlarefsPath,
            TlarefsToIdsPath = TlarefsToIdsPath
        };

        _resourceLoader = new ResourceLoader(_validResourcesConfig);
    }

    /// <summary>
    ///     Reset the resources config and created resource loaders.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _validResourcesConfig = null;
        _resourceLoader = null;
    }

    /// <summary>
    ///     Test to import resources using the ResourceLoader.
    ///     This should return a ImportedResources instance with a Stops
    ///     list of length 1.
    /// </summary>
    [Test]
    public void TestImportResourcesImportedStops()
    {
        var importedResources = _resourceLoader?.ImportResources();
        Assert.NotNull(importedResources);
        Debug.Assert(importedResources != null, nameof(importedResources) + " != null");
        Assert.AreEqual(1, importedResources.ImportedStops.Count);
    }

    /// <summary>
    ///     Test to import the StationNamesToTlarefs using resource loaders
    ///     Import resources method.
    ///     This should return a dict of length 12.
    /// </summary>
    [Test]
    public void TestImportResourcesImportedNamesToTlarefs()
    {
        var importedResources = _resourceLoader?.ImportResources();
        Assert.NotNull(importedResources);
        Debug.Assert(importedResources != null, nameof(importedResources) + " != null");
        Assert.AreEqual(12, importedResources.StationNamesToTlaref.Count);
    }

    /// <summary>
    ///     Test to import the TlarefToIds dict.
    ///     This should include this in the ImportedResources, which should
    ///     contain a dict of length 14.
    /// </summary>
    [Test]
    public void TestImportResourcesImportTlarefToIds()
    {
        var importedResources = _resourceLoader?.ImportResources();
        Assert.NotNull(importedResources);
        Debug.Assert(importedResources != null, nameof(importedResources) + " != null");
        Assert.AreEqual(14, importedResources.TlarefsToIds.Count);
    }
}