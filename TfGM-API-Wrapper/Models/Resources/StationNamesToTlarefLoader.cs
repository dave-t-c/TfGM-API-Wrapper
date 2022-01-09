using System;

namespace TfGM_API_Wrapper.Models.Resources
{
    /// <summary>
    /// Loads the StationNamesToTlarefs map using the ResourcesConfig.
    /// </summary>
    public class StationNamesToTlarefLoader
    {
        private readonly ResourcesConfig _resourcesConfig;
        
        /// <summary>
        /// Creates a new loader. Checks the ResourceConfig values provided are valid using
        /// the LoaderHelper.
        /// </summary>
        /// <param name="resourcesConfig">ResourceConfig created at startup. Injected as a service.</param>
        /// <exception cref="ArgumentNullException">Thrown if the ResourceConfig is null.</exception>
        public StationNamesToTlarefLoader(ResourcesConfig resourcesConfig)
        {
            LoaderHelper loaderHelper = new LoaderHelper();

            _resourcesConfig = resourcesConfig ?? throw new ArgumentNullException(nameof(resourcesConfig));
            
            _resourcesConfig.StationNamesToTlarefsPath = loaderHelper.CheckFileRequirements(resourcesConfig.StationNamesToTlarefsPath,
                nameof(resourcesConfig.StationNamesToTlarefsPath));
        }
    }
}