using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using TfGM_API_Wrapper.Controllers;
using TfGM_API_Wrapper.Models;
using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper_Tests.TestControllers
{
    /// <summary>
    /// Test class for the StopsController class
    /// </summary>
    public class TestStopsController
    {
        private const string ValidStopLoaderPath = "../../../Resources/ValidStopLoader.json";
        private ResourcesConfig? _resourcesConfig;
        private StopsController? _testStopController;
        private IOptions<ResourcesConfig>? _resourceOptions;

        [SetUp]
        public void Setup()
        {
            _resourcesConfig = new ResourcesConfig
            {
                StopResourcePath = "../../../Resources/ValidStopLoader.json"
            };
            _resourceOptions = Options.Create<ResourcesConfig>(_resourcesConfig);
            _testStopController = new StopsController(_resourceOptions);
        }

        /// <summary>
        /// Reset the test Stop Controller to clear any changes made
        /// during the tests.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            _testStopController = null;
            _resourceOptions = null;
        }

        /// <summary>
        /// Test to try and get the expected 200 result code
        /// from the GetAllStops method.
        /// </summary>
        [Test]
        public void TestGetAllStopsExpectedResultCode()
        {
            IActionResult result = _testStopController!.GetAllStops();
            Assert.IsNotNull(result);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult!.StatusCode);
        }

        /// <summary>
        /// Test the length of the returned Stops list.
        /// This should be 1, as there is only a single Stop in the
        /// StopLoader file.
        /// </summary>
        [Test]
        public void TestGetExpectedStopsCount()
        {
            IActionResult result = _testStopController!.GetAllStops();
            Assert.IsNotNull(result);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            List<Stop> retrievedStops = okResult!.Value as List<Stop> ?? new List<Stop>();
            Assert.AreEqual(1, retrievedStops.Count);
        }
    }
}