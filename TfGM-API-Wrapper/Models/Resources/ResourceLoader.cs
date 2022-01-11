using System.Collections.Generic;

namespace TfGM_API_Wrapper.Models.Resources
{
    public class ResourceLoader
    {
        private readonly ResourcesConfig _resourcesConfig;
        private StopLoader _stopLoader;
        private StationNamesToTlarefLoader _stationNamesToTlarefLoader;

        public ResourceLoader(ResourcesConfig resourcesConfig)
        {
            _resourcesConfig = resourcesConfig;
            _stopLoader = new StopLoader(resourcesConfig);
            _stationNamesToTlarefLoader = new StationNamesToTlarefLoader(resourcesConfig);
        }

        public ImportedResources ImportResources()
        {
            ImportedResources importedResources = new ImportedResources();
            importedResources.ImportedStops = _stopLoader.ImportStops();
            importedResources.StationNamesToTlaref = _stationNamesToTlarefLoader.ImportStationNamesToTlarefs();
            return importedResources;
        }
    }
}