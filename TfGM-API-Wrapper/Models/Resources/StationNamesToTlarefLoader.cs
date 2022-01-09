using System;

namespace TfGM_API_Wrapper.Models.Resources
{
    public class StationNamesToTlarefLoader
    {
        private readonly ResourcesConfig _resourcesConfig;
        
        public StationNamesToTlarefLoader(ResourcesConfig resourcesConfig)
        {
            LoaderHelper loaderHelper = new LoaderHelper();

            _resourcesConfig = resourcesConfig ?? throw new ArgumentNullException(nameof(resourcesConfig));
            
            _resourcesConfig.StationNamesToTlarefsPath = loaderHelper.CheckFileRequirements(resourcesConfig.StationNamesToTlarefsPath,
                nameof(resourcesConfig.StationNamesToTlarefsPath));
        }
    }
}