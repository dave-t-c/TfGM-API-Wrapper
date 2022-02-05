using System.Diagnostics;
using NUnit.Framework;
using TfGM_API_Wrapper_Tests.TestModels.TestServices;
using TfGM_API_Wrapper.Models;
using TfGM_API_Wrapper.Models.Resources;
using TfGM_API_Wrapper.Models.Services;

namespace TfGM_API_Wrapper_Tests.TestModels
{
    public class TestWrapperDataModel
    {
        private ResourcesConfig? _validResourcesConfig;
        private MockServiceRequester? _mockServiceRequester;
        private WrapperDataModel? _wrapperDataModel;
        private const string StopResourcePathConst = "../../../Resources/ValidStopLoader.json";
        private const string StationNamesToTlarefsPath = "../../../Resources/Station_Names_to_TLAREFs.json";
        private const string TlarefsToIdsPath = "../../../Resources/TLAREFs_to_IDs.json";
        
        [SetUp]
        public void SetUp()
        {
            _validResourcesConfig = new ResourcesConfig
            {
                StopResourcePath = StopResourcePathConst,
                StationNamesToTlarefsPath = StationNamesToTlarefsPath,
                TlarefsToIdsPath = TlarefsToIdsPath
            };
            _mockServiceRequester = new MockServiceRequester();
            _wrapperDataModel = new WrapperDataModel(_validResourcesConfig, _mockServiceRequester);

        }

        [TearDown]
        public void TearDown()
        {
            _validResourcesConfig = null;
            _mockServiceRequester = null;
            _wrapperDataModel = null;
        }

        /// <summary>
        /// Test to create a new data model and get the imported resources.
        /// This should return an ImportedResources object with the expected length.
        /// </summary>
        [Test]
        public void TestCreateNewDataModelGetImportedResources()
        {
            ImportedResources? result = _wrapperDataModel?.ImportResources();
            Assert.NotNull(result);
            Debug.Assert(result != null, nameof(result) + " != null");
            Assert.AreEqual(1, result.ImportedStops.Count);
            Assert.AreEqual(12, result.StationNamesToTlaref.Count);
            Assert.AreEqual(14, result.TlarefsToIds.Count);
        }

        /// <summary>
        /// Test to try and process a service for BMR.
        /// This should return a single destination.
        /// </summary>
        [Test]
        public void TestProcessService()
        {
            Debug.Assert(_wrapperDataModel != null, nameof(_wrapperDataModel) + " != null");
            FormattedServices result = _wrapperDataModel.RequestService("BMR");
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Destinations.Count);
            Assert.AreEqual(1, result.Messages.Count);
        }
    }
}