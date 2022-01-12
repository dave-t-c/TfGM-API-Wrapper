using System;
using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper.Models
{
    /// <summary>
    /// Data model for the TfGM-API-Wrapper project.
    /// </summary>
    public class WrapperDataModel
    {
        private readonly ResourcesConfig _resourcesConfig;

        public WrapperDataModel(ResourcesConfig resourcesConfig)
        {
            _resourcesConfig = resourcesConfig;
        }

        /// <summary>
        /// Loads and imports the resources using the ResourceLoader
        /// </summary>
        /// <returns>Returns ImportedResources</returns>
        public ImportedResources ImportResources()
        {
            return new ResourceLoader(_resourcesConfig).ImportResources();
        }
    }
}