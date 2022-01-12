using NUnit.Framework;
using TfGM_API_Wrapper.Models;
using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper_Tests.TestModels
{
    public class TestWrapperDataModel
    {
        private ResourcesConfig? _validResourcesConfig;
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
        }

        [TearDown]
        public void TearDown()
        {
            
        }
    }
}