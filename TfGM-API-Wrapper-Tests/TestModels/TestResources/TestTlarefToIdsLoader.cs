using System;
using System.IO;
using NUnit.Framework;
using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper_Tests.TestModels.TestResources
{
    public class TestTlarefToIdsLoader
    {
        private ResourcesConfig? _validResourcesConfig;
        private ResourcesConfig? _nullTlarefsToIdsPath;
        private ResourcesConfig? _invalidTlarefsToIdsPath;

        private TlarefToIdsLoader? _tlarefToIdsLoader;

        private const string StopResourcePathConst = "../../../Resources/ValidStopLoader.json";
        private const string StationNamesToTlarefsPath = "../../../Resources/Station_Names_to_TLAREFs.json";
        private const string TlarefsToIdsPath = "../../../Resources/TLAREFs_to_IDs.json";
        private const string InvalidFilePath = "../../../Resources/NonExistentFile.json";

        [SetUp]
        public void SetUp()
        {
            _validResourcesConfig = new ResourcesConfig
            {
                StopResourcePath = StopResourcePathConst,
                StationNamesToTlarefsPath = StationNamesToTlarefsPath,
                TlarefsToIdsPath = TlarefsToIdsPath
            };
            
            _nullTlarefsToIdsPath = _validResourcesConfig.DeepCopy();
            _nullTlarefsToIdsPath.TlarefsToIdsPath = null;

            _invalidTlarefsToIdsPath = _validResourcesConfig.DeepCopy();
            _invalidTlarefsToIdsPath.TlarefsToIdsPath = InvalidFilePath;
        }

        [TearDown]
        public void TearDown()
        {
            _validResourcesConfig = null;
            _nullTlarefsToIdsPath = null;
            _invalidTlarefsToIdsPath = null;
            _tlarefToIdsLoader = null;
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
                    _tlarefToIdsLoader = new TlarefToIdsLoader(_nullTlarefsToIdsPath);
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
                    _tlarefToIdsLoader = new TlarefToIdsLoader(_invalidTlarefsToIdsPath);
                });
        }
    }
}