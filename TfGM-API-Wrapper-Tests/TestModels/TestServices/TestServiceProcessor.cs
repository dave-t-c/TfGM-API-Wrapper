using System.Diagnostics;
using NUnit.Framework;
using TfGM_API_Wrapper.Models.Resources;
using TfGM_API_Wrapper.Models.Services;

namespace TfGM_API_Wrapper_Tests.TestModels.TestServices
{
    /// <summary>
    /// Test class for the ServiceProcessor.
    /// </summary>
    public class TestServiceProcessor
    {
        private MockServiceRequester? _mockServiceRequester;
        private ServiceProcessor? _serviceProcessor;
        private ResourcesConfig? _validResourcesConfig;
        private ImportedResources? _importedResources;
        
        private ResourceLoader? _resourceLoader;
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

            _resourceLoader = new ResourceLoader(_validResourcesConfig);
            _importedResources = _resourceLoader.ImportResources();

            _mockServiceRequester = new MockServiceRequester();
            _serviceProcessor = new ServiceProcessor(_mockServiceRequester, _importedResources);

        }

        [TearDown]
        public void TearDown()
        {
            _mockServiceRequester = null;
        }


        /// <summary>
        /// This should take a stop name, and then return the expected formatted services.
        /// This will use tge MockServiceRequester so we can test an expected value as the data
        /// will be static.
        /// This should return FormattedServices.
        /// </summary>
        [Test]
        public void TestProcessServicesStopName()
        {
            Debug.Assert(_serviceProcessor != null, nameof(_serviceProcessor) + " != null");
            FormattedServices result = _serviceProcessor.RequestServices("BMR");
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Destinations.Count);
        }
    }
}