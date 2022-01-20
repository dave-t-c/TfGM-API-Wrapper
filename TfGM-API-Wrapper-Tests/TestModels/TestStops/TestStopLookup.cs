using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using TfGM_API_Wrapper.Models.Resources;
using TfGM_API_Wrapper.Models.Stops;

namespace TfGM_API_Wrapper_Tests.TestModels.TestStops
{
    /// <summary>
    /// Test class for the StopLookup class
    /// </summary>
    public class TestStopLookup
    {
        private ResourcesConfig? _resourcesConfig;
        private const string StopResourcePathConst = "../../../Resources/ValidStopLoader.json";
        private const string StationNamesToTlarefsPath = "../../../Resources/Station_Names_to_TLAREFs.json";
        private const string TlarefsToIdsPath = "../../../Resources/TLAREFs_to_IDs.json";

        private ImportedResources? _importedResources;

        private ResourceLoader? _resourceLoader;
        private StopLookup? _stopLookup;
        
        /// <summary>
        /// Set up the required resources for each test.
        /// This uses the resource loader to load the test resources.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _resourcesConfig = new ResourcesConfig
            {
                StopResourcePath = StopResourcePathConst,
                StationNamesToTlarefsPath = StationNamesToTlarefsPath,
                TlarefsToIdsPath = TlarefsToIdsPath
            };

            _resourceLoader = new ResourceLoader(_resourcesConfig);
            _importedResources = _resourceLoader.ImportResources();
            _stopLookup = new StopLookup(_importedResources);
        }

        /// <summary>
        /// Reset the created objects to avoid problems between test runs.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _stopLookup = null;
            _importedResources = null;
            _resourceLoader = null;
            _resourcesConfig = null;
        }

        /// <summary>
        /// Test to look up the Tlaref 'ALT'
        /// and check the IDs returned are an array of list of [728, 729]
        /// </summary>
        [Test]
        public void TestStopLookupTlarefIDs()
        {
            const string tlaref = "ALT";
            int[] expectedResult = new[] {728, 729};
            Debug.Assert(_stopLookup != null, nameof(_stopLookup) + " != null");
            int[] result = _stopLookup.TlarefLookup(tlaref);
            Assert.NotNull(result);
            Assert.AreEqual(expectedResult, result);
        }
    }
}