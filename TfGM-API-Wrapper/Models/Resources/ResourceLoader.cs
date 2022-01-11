using System.Collections.Generic;

namespace TfGM_API_Wrapper.Models.Resources
{
    public class ResourceLoader
    {
        private readonly ResourcesConfig _resourcesConfig;
        private readonly StopLoader _stopLoader;
        private readonly StationNamesToTlarefLoader _stationNamesToTlarefLoader;

        public ResourceLoader(ResourcesConfig resourcesConfig)
        {
            _resourcesConfig = resourcesConfig;
            _stopLoader = new StopLoader(resourcesConfig);
            _stationNamesToTlarefLoader = new StationNamesToTlarefLoader(resourcesConfig);
        }
        
        public ImportedResources ImportResources()
        {
            ImportedResources importedResources = new ImportedResources
            {
                ImportedStops = _stopLoader.ImportStops(),
                StationNamesToTlaref = _stationNamesToTlarefLoader.ImportStationNamesToTlarefs()
            };
            return importedResources;
        }
    }
}