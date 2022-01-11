using System.Collections.Generic;

namespace TfGM_API_Wrapper.Models.Resources
{
    public class ResourceLoader
    {
        private readonly ResourcesConfig _resourcesConfig;
        private StopLoader _stopLoader;

        public ResourceLoader(ResourcesConfig resourcesConfig)
        {
            _resourcesConfig = resourcesConfig;
            _stopLoader = new StopLoader(resourcesConfig);
        }

        public ImportedResources ImportResources()
        {
            ImportedResources importedResources = new ImportedResources();
            importedResources.ImportedStops = _stopLoader.ImportStops();
            return importedResources;
        }
    }
}