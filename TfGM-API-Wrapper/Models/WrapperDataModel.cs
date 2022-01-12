using System;
using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper.Models
{
    /// <summary>
    /// Data model for the TfGM-API-Wrapper project.
    /// </summary>
    public class WrapperDataModel
    {
        public readonly ResourcesConfig _resourcesConfig;

        public WrapperDataModel(ResourcesConfig resourcesConfig)
        {
            _resourcesConfig = resourcesConfig;
        }
    }
}