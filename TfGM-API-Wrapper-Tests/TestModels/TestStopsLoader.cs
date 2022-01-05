using System;
using NUnit.Framework;
using TfGM_API_Wrapper.Models;
using static System.AppDomain;
namespace TfGM_API_Wrapper_Tests.TestModels
{
    /// <summary>
    /// Tests the StopsLoader class.
    /// The StopsLoader class is used for removing the importing of stops and stop data
    /// from the StopsController.
    /// </summary>
    public class TestStopsLoader
    {
        
        private string _validStopLoaderPath = "";
        
        [SetUp]
        public void Setup()
        {
            //The links for the resources folder is three directories up due to where
            //the tests are run from.
            _validStopLoaderPath = "../../../Resources/ValidStopLoader.json";
        }

        /// <summary>
        /// Create a valid stop loader.
        /// This should only contain a single stop.
        /// This uses the Resources/ValidStopLoader.json file.
        /// </summary>
        [Test]
        public void TestValidStopLoader()
        {
            StopLoader testStopLoader = new StopLoader(_validStopLoaderPath);
            Assert.AreEqual(1, testStopLoader.ImportStops().Count);
        }
    }
}