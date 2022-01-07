using System;
using System.IO;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using TfGM_API_Wrapper.Models;
using TfGM_API_Wrapper.Models.Resources;
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
        private ResourcesConfig? _validResourcesConfig;
        private ResourcesConfig? _invalidResourcesConfig;

        [SetUp]
        public void Setup()
        {
            //The links for the resources folder is three directories up due to where
            //the tests are run from.
            _validResourcesConfig = new ResourcesConfig
            {
                StopResourcePath = "../../../Resources/ValidStopLoader.json"
            };
            
            _invalidResourcesConfig = new ResourcesConfig
            {
                StopResourcePath = "../../../Resources/NonExistentFile.json"
            };

        }

        /// <summary>
        /// Create a valid stop loader.
        /// This should only contain a single stop.
        /// This uses the Resources/ValidStopLoader.json file.
        /// </summary>
        [Test]
        public void TestValidStopLoader()
        {
            StopLoader testStopLoader = new StopLoader(_validResourcesConfig);
            Assert.AreEqual(1, testStopLoader.ImportStops().Count);
        }

        /// <summary>
        /// Create a stop loader using null.
        /// This should throw an argument exception
        /// </summary>
        [Test]
        public void TestNullStopLoader()
        {
            Assert.Throws(Is.TypeOf<ArgumentNullException>().And
                    .Message.EqualTo("Value cannot be null. (Parameter 'resourcesConfig')"),
                delegate
                {
                    StopLoader stopLoader = new StopLoader(null);
                });
        }

        /// <summary>
        /// Create a StopLoader using a file path that does not exist.
        /// This should throw a FileNotFoundException
        /// </summary>
        [Test]
        public void TestNonExistentFileStopLoader()
        {
            Assert.Throws(Is.TypeOf<FileNotFoundException>().And
                .Message.Contains("Could not find file")
                .And.Message.Contains("../../../Resources/NonExistentFile.json"),
            delegate
            {
                StopLoader stopLoader = new StopLoader(_invalidResourcesConfig);
                stopLoader.ImportStops();
            });
        }
    }
}