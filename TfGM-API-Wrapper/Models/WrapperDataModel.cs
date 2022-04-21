using TfGM_API_Wrapper.Models.Resources;
using TfGM_API_Wrapper.Models.Services;

namespace TfGM_API_Wrapper.Models;

/// <summary>
///     Data model for the TfGM-API-Wrapper project.
/// </summary>
public class WrapperDataModel
{
    private readonly ImportedResources _importedResources;
    private readonly ServiceProcessor _serviceProcessor;

    public WrapperDataModel(ResourcesConfig resourcesConfig, IRequester requester = null)
    {
        _importedResources = new ResourceLoader(resourcesConfig).ImportResources();
        _serviceProcessor = new ServiceProcessor(requester, _importedResources);
    }

    /// <summary>
    ///     Loads and imports the resources using the ResourceLoader
    /// </summary>
    /// <returns>Returns ImportedResources</returns>
    public ImportedResources ImportResources()
    {
        return _importedResources;
    }

    public FormattedServices RequestServices(string stop)
    {
        return _serviceProcessor.RequestServices(stop);
    }
}