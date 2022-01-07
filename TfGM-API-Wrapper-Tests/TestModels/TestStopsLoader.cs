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

        private const string StopResourcePath = "../../../Resources/ValidStopLoader.json";
        private const string StationNamesToTlarefsPath = "../../../Resources/Station_Names_to_TLAREFs.json";
        private const string TlarefsToIdsPath = "../../../Resources/TLAREFs_to_IDs.json";
        private const string InvalidFilePath = "../../../Resources/NonExistentFile.json";
        

        /// <summary>
        /// Create the required Configs for the StopLoaders.
        /// This uses a DeepCopy function created in the ResourceConfig class,
        /// that then utilises the valid config and changes the fields accordingly. 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            //The links for the resources folder is three directories up due to where
            //the tests are run from.
            _validResourcesConfig = new ResourcesConfig
            {
                StopResourcePath = StopResourcePath,
                StationNamesToTlarefsPath = StationNamesToTlarefsPath,
                TlarefsToIdsPath = TlarefsToIdsPath
            };

            _invalidStopResources = _validResourcesConfig.DeepCopy();
            _invalidStopResources.StopResourcePath = InvalidFilePath;

            _nullStopResource = _validResourcesConfig.DeepCopy();
            _nullStopResource.StopResourcePath = null;

            _nullStationNamesToTlarefs = _validResourcesConfig.DeepCopy();
            _nullStationNamesToTlarefs.StationNamesToTlarefsPath = null;

            _invalidStationNamesToTlarefs = _validResourcesConfig.DeepCopy();
            _invalidStationNamesToTlarefs.StationNamesToTlarefsPath = InvalidFilePath;

            _nullTlarefsToIdsPath = _invalidStopResources.DeepCopy();
            _nullTlarefsToIdsPath.TlarefsToIdsPath = null;

            _invalidTlarefsToIdsPath = _validResourcesConfig.DeepCopy();
            _invalidTlarefsToIdsPath.TlarefsToIdsPath = InvalidFilePath;
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
            Assert.Throws(Is.TypeOf<ArgumentNullException>()
                    .And.Message.EqualTo("Value cannot be null. (Parameter 'resourcesConfig')"),
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
            Assert.Throws(Is.TypeOf<FileNotFoundException>()
                    .And.Message.Contains("Could not find file")
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
            Assert.Throws(Is.TypeOf<InvalidOperationException>()
                    .And.Message.EqualTo("StopResourcePath cannot be null"),
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
            Assert.Throws(Is.TypeOf<InvalidOperationException>()
                    .And.Message.EqualTo("StationNamesToTlarefsPath cannot be null"),
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
            Assert.Throws(Is.TypeOf<FileNotFoundException>()
                    .And.Message.Contains("Could not find file")
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
            Assert.Throws(Is.TypeOf<InvalidOperationException>()
                    .And.Message.EqualTo("TlarefsToIdsPath cannot be null"),
                delegate
                {
                    StopLoader stopLoader = new StopLoader(_nullTlarefsToIdsPath);
                });
        }
        
        /// <summary>
        /// Test creating a StopLoader with a non-existent TlarefsToIds file.
        /// This should throw a file not found exception. 
        /// </summary>
        [Test]
        public void TestNonExistentTlarefsToIdsPath()
        {
            Assert.Throws(Is.TypeOf<FileNotFoundException>()
                    .And.Message.Contains("Could not find file")
                    .And.Message.Contains("../../../Resources/NonExistentFile.json"),
                delegate
                {
                    StopLoader stopLoader = new StopLoader(_invalidTlarefsToIdsPath);
                    stopLoader.ImportStops();
                });
        }
    }
}