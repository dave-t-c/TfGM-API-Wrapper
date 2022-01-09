using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TfGM_API_Wrapper.Models.Resources
{
    /// <summary>
    /// Loads the TlarefToIds map.
    /// </summary>
    public class TlarefToIdsLoader
    {
        private readonly ResourcesConfig _resourcesConfig;
        
        /// <summary>
        /// Creates a new loader by verifying the path given using the LoaderHelper class.
        /// </summary>
        /// <param name="resourcesConfig">Config created at startup. Injected as a service.</param>
        /// <exception cref="ArgumentNullException">Thrown if the resources config is null.</exception>
        public TlarefToIdsLoader(ResourcesConfig resourcesConfig)
        {
            LoaderHelper loaderHelper = new LoaderHelper();
            
            _resourcesConfig = resourcesConfig ?? throw new ArgumentNullException(nameof(resourcesConfig));
            
            _resourcesConfig.TlarefsToIdsPath = loaderHelper.CheckFileRequirements(resourcesConfig.TlarefsToIdsPath,
                nameof(resourcesConfig.TlarefsToIdsPath));
        }

        public Dictionary<string, List<int>> ImportTlarefsToIds()
        {
            using var reader = new StreamReader(_resourcesConfig.TlarefsToIdsPath);
            var jsonString = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(jsonString);
        }
    }
}