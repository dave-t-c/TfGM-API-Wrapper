using System.Collections.Generic;
using TfGM_API_Wrapper.Models.Resources;
using TfGM_API_Wrapper.Models.Stops;

namespace TfGM_API_Wrapper_Tests.TestControllers;

public class MockStopsDataModel: IStopsDataModel
{
    private readonly ImportedResources _importedResources;
    
    public MockStopsDataModel(ImportedResources importedResources)
    {
        _importedResources = importedResources;
    }
    public List<Stop> GetStops()
    {
        return _importedResources.ImportedStops;
    }
}