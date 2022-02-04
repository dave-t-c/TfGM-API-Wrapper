using System.Collections.Generic;
using TfGM_API_Wrapper.Models.Services;

namespace TfGM_API_Wrapper_Tests.TestModels.TestServices
{
    public class MockServiceRequester: IRequester
    {
        public List<UnformattedServices> RequestServices(List<int> ids)
        {
            throw new System.NotImplementedException();
        }
    }
}