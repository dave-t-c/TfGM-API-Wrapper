using System;
using System.IO;
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
        private string _invalidStopLoaderPath = "";
        
        [SetUp]
        public void Setup()
        {
            //The links for the resources folder is three directories up due to where
            //the tests are run from.
            _validStopLoaderPath = "../../../Resources/ValidStopLoader.json";
            _invalidStopLoaderPath = "../../../Resources/NonExistentFile.json";
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

        /// <summary>
        /// Create a stop loader using null.
        /// This should throw an argument exception
        /// </summary>
        [Test]
        public void TestNullStopLoader()
        {
            Assert.Throws(Is.TypeOf<ArgumentNullException>().And
                    .Message.EqualTo("Value cannot be null. (Parameter 'stopsPath')"),
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
                .Message.EqualTo("Could not find file ../../../Resources/NonExistentFile.json"),
            delegate
            {
                StopLoader stopLoader = new StopLoader(_invalidStopLoaderPath);
                stopLoader.ImportStops();
            });
        }
    }
}