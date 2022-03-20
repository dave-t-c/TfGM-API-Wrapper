using System.Collections.Generic;
using TfGM_API_Wrapper.Models.Services;

namespace TfGM_API_Wrapper_Tests.TestModels.TestServices
{
    public class MockServiceRequester: IRequester
    {
        private readonly ImportServicesResponse _importServices;
        private const string ValidApiResponsePath = "../../../Resources/ExampleApiResponse.json";
        public MockServiceRequester()
        {
            _importServices = new ImportServicesResponse();
        }
        
        public List<UnformattedServices> RequestServices(List<int> ids)
        {
            if (ids.Contains(701))
            {
                return new List<UnformattedServices>(){
                    _importServices.ImportUnformattedServices(ValidApiResponsePath) ?? new UnformattedServices()
                    
                };
            }

            return new List<UnformattedServices>();
        }
    }
}