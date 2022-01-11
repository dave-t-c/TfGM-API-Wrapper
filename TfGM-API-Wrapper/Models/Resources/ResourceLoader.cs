using System.Collections.Generic;

namespace TfGM_API_Wrapper.Models.Resources
{
    public class ResourceLoader
    {
        private readonly ResourcesConfig _resourcesConfig;

        public List<Stop> ImportedStops { get; }
        
        public ResourceLoader(ResourcesConfig resourcesConfig)
        {
            _resourcesConfig = resourcesConfig;
            ImportedStops = new StopLoader(_resourcesConfig).ImportStops();
        }
    }
}