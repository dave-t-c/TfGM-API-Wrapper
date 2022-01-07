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
        private ResourcesConfig? _invalidStopResources;
        private ResourcesConfig? _nullStopResource;
        private ResourcesConfig? _nullStationNamesToTlarefs;
        private ResourcesConfig? _invalidStationNamesToTlarefs;
        private ResourcesConfig? _nullTlarefsToIdsPath;
        private ResourcesConfig? _invalidTlarefsToIdsPath;

        [SetUp]
        public void Setup()
        {
            //The links for the resources folder is three directories up due to where
            //the tests are run from.
            _validResourcesConfig = new ResourcesConfig
            {
                StopResourcePath = "../../../Resources/ValidStopLoader.json",
                StationNamesToTlarefsPath = "../../../Resources/Station_Names_to_TLAREFs.json",
                TlarefsToIdsPath = "../../../Resources/TLAREFs_to_IDs.json"
            };
            
            _invalidStopResources = new ResourcesConfig
            {
                StopResourcePath = "../../../Resources/NonExistentFile.json",
                StationNamesToTlarefsPath = "../../../Resources/Station_Names_to_TLAREFs.json",
                TlarefsToIdsPath = "../../../Resources/TLAREFs_to_IDs.json"
            };
            
            _nullStopResource = new ResourcesConfig
            {
                StopResourcePath = null,
                StationNamesToTlarefsPath = "../../../Resources/Station_Names_to_TLAREFs.json",
                TlarefsToIdsPath = "../../../Resources/TLAREFs_to_IDs.json"
            };

            _nullStationNamesToTlarefs = new ResourcesConfig
            {
                StopResourcePath = "../../../Resources/ValidStopLoader.json",
                StationNamesToTlarefsPath = null,
                TlarefsToIdsPath = "../../../Resources/TLAREFs_to_IDs.json"
            };

            _invalidStationNamesToTlarefs = new ResourcesConfig()
            {
                StopResourcePath = "../../../Resources/ValidStopLoader.json",
                StationNamesToTlarefsPath = "../../../Resources/NonExistentFile.json",
                TlarefsToIdsPath = "../../../Resources/TLAREFs_to_IDs.json"
            };
            
            _nullTlarefsToIdsPath = new ResourcesConfig
            {
                StopResourcePath = "../../../Resources/ValidStopLoader.json",
                StationNamesToTlarefsPath = "../../../Resources/Station_Names_to_TLAREFs.json",
                TlarefsToIdsPath = null
            };
            
            _invalidTlarefsToIdsPath = new ResourcesConfig
            {
                StopResourcePath = "../../../Resources/ValidStopLoader.json",
                StationNamesToTlarefsPath = "../../../Resources/Station_Names_to_TLAREFs.json",
                TlarefsToIdsPath = "../../../Resources/NonExistentFile.json"
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
                StopLoader stopLoader = new StopLoader(_invalidStopResources);
                stopLoader.ImportStops();
            });
        }

        /// <summary>
        /// Create a config with stops resource path as null.
        /// This should throw a InvalidOperationException.
        /// </summary>
        [Test]
        public void TestNullStopsResource()
        {
            Assert.Throws(Is.TypeOf<InvalidOperationException>().And
                    .Message.EqualTo("StopResourcePath cannot be null"),
                delegate
                {
                    StopLoader stopLoader = new StopLoader(_nullStopResource);
                });
        }

        /// <summary>
        /// Test to try and create a StopLoader with a null
        /// StationNamesToTlarefs path.
        /// This should throw an Invalid Operation Exception similar to with a null
        /// StopResourcePath.
        /// </summary>
        [Test]
        public void TestNullStationNamesToTlarefs()
        {
            Assert.Throws(Is.TypeOf<InvalidOperationException>().And
                    .Message.EqualTo("StationNamesToTlarefsPath cannot be null"),
                delegate
                {
                    StopLoader stopLoader = new StopLoader(_nullStationNamesToTlarefs);
                });
        }
        
        /// <summary>
        /// Test to try and create a file with a non-existent StationNamesToTlarefs
        /// path. This should throw a FileNotFoundException.
        /// </summary>
        [Test]
        public void TestNonExistentStationNamesToTlarefs()
        {
            Assert.Throws(Is.TypeOf<FileNotFoundException>().And
                    .Message.Contains("Could not find file")
                    .And.Message.Contains("../../../Resources/NonExistentFile.json"),
                delegate
                {
                    StopLoader stopLoader = new StopLoader(_invalidStationNamesToTlarefs);
                    stopLoader.ImportStops();
                });
        }

        /// <summary>
        /// Test to try and create a StopLoader with a null
        /// TlarefsToIdsPath. This should throw a InvalidOperationException.
        /// </summary>
        [Test]
        public void TestNullTlarefsToIdsPath()
        {
            Assert.Throws(Is.TypeOf<InvalidOperationException>().And
                    .Message.EqualTo("TlarefsToIdsPath cannot be null"),
                delegate
                {
                    StopLoader stopLoader = new StopLoader(_nullTlarefsToIdsPath);
                });
        }
        
        [Test]
        public void TestNonExistentTlarefsToIdsPath()
        {
            Assert.Throws(Is.TypeOf<FileNotFoundException>().And
                    .Message.Contains("Could not find file")
                    .And.Message.Contains("../../../Resources/NonExistentFile.json"),
                delegate
                {
                    StopLoader stopLoader = new StopLoader(_invalidTlarefsToIdsPath);
                    stopLoader.ImportStops();
                });
        }
    }
}