using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using TfGM_API_Wrapper.Models;
using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper_Tests.TestModels.TestResources
{
    public class TestResourceLoader
    {
        private  ResourcesConfig? _validResourcesConfig;
        private ResourceLoader? _resourceLoader;
        private const string StopResourcePathConst = "../../../Resources/ValidStopLoader.json";
        private const string StationNamesToTlarefsPath = "../../../Resources/Station_Names_to_TLAREFs.json";
        private const string TlarefsToIdsPath = "../../../Resources/TLAREFs_to_IDs.json";
        
        /// <summary>
        /// Set up the valid config and test variables.
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
        /// Reset the resources config and created resource loaders.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _validResourcesConfig = null;
            _resourceLoader = null;
        }

        /// <summary>
        /// Test to try and use the created valid stop loader, and
        /// import the stops list.
        /// This should return a list of length 1.
        /// </summary>
        [Test]
        public void TestCreateValidStopLoader()
        {
            List<Stop>? returnedList = _resourceLoader?.ImportedStops;
            Assert.NotNull(returnedList);
            Debug.Assert(returnedList != null, nameof(returnedList) + " != null");
            Assert.AreEqual(1, returnedList.Count);
        }
        
    }
}