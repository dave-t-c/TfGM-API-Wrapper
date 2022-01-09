using System;

namespace TfGM_API_Wrapper.Models.Resources
{
    public class TlarefToIdsLoader
    {
        private readonly ResourcesConfig _resourcesConfig;
        
        public TlarefToIdsLoader(ResourcesConfig resourcesConfig)
        {
            LoaderHelper loaderHelper = new LoaderHelper();
            
            _resourcesConfig = resourcesConfig ?? throw new ArgumentNullException(nameof(resourcesConfig));
            
            _resourcesConfig.TlarefsToIdsPath = loaderHelper.CheckFileRequirements(resourcesConfig.TlarefsToIdsPath,
                nameof(resourcesConfig.TlarefsToIdsPath));
        }
    }
}