using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper.Models.Services;

public class ServicesDataModel: IServicesDataModel
{
    
    private readonly ServiceProcessor _serviceProcessor;

    public ServicesDataModel(ImportedResources importedResources, IRequester requester)
    {
        _serviceProcessor = new ServiceProcessor(requester, importedResources);
    }
    
    /// <summary>
    /// Requests services for a given stop name or tlaref.
    /// </summary>
    /// <param name="stop">Stop name or tlaref</param>
    /// <returns>Formatted Services at given stop</returns>
    public FormattedServices RequestServices(string stop)
    {
        return _serviceProcessor.RequestServices(stop);
    }
}