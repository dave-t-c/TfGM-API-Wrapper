using System;
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
            List<int> expectedResult = new List<int>() {728, 729};
            Debug.Assert(_stopLookup != null, nameof(_stopLookup) + " != null");
            List<int> result = _stopLookup.TlarefLookup(tlaref);
            Assert.NotNull(result);
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Test to get IDs for a different tlaref.
        /// This should return an array of length 4
        /// instead of length 2.
        /// </summary>
        [Test]
        public void TestStopLookupDifferentTlaref()
        {
            const string tlaref = "ASH";
            List<int> expectedResult = new List<int>() {783, 784, 785, 786};
            Debug.Assert(_stopLookup != null, nameof(_stopLookup) + " != null");
            List<int> result = _stopLookup.TlarefLookup(tlaref);
            Assert.NotNull(result);
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Test to try and get the tlaref for a null value.
        /// This should throw an illegal argument exception
        /// </summary>
        [Test]
        public void TestStopLookupNullTlaref()
        {
            Assert.Throws(Is.TypeOf<ArgumentNullException>()
                    .And.Message.EqualTo("Value cannot be null. (Parameter 'tlaref')"),
                delegate
                {
                    _stopLookup?.TlarefLookup(null);
                });
        }

        /// <summary>
        /// Test to try and get the stops IDs from a given stop name.
        /// This should return the expected IDs.
        /// </summary>
        [Test]
        public void TestStopLookupStopName()
        {
            const string stationName = "Altrincham";
            List<int> expectedResult = new List<int>() {728, 729};
            Debug.Assert(_stopLookup != null, nameof(_stopLookup) + " != null");
            List<int> result = _stopLookup.StationNameLookup(stationName);
            Assert.NotNull(result);
            Assert.AreEqual(expectedResult, result);
        }
        
    }
}