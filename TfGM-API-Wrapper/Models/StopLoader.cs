using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TfGM_API_Wrapper.Models.Resources;
using static System.AppDomain;

namespace TfGM_API_Wrapper.Models
{
    /// <summary>
    /// Loads in the Stop data from the resources folder.
    /// </summary>
    public class StopLoader
    {
        private readonly ResourcesConfig _resourcesConfig;

        /// <summary>
        /// Create a new StopLoader Object, which can import the required Stops.
        /// </summary>
        /// <param name="resourcesConfig"></param>
        public StopLoader(ResourcesConfig resourcesConfig)
        {
            _resourcesConfig = resourcesConfig ?? throw new ArgumentNullException(nameof(resourcesConfig));
            //_stopsPath = resourcesConfig.StopResourcePath ?? throw new ArgumentNullException(nameof(stopsPath));
            _resourcesConfig.StopResourcePath = CurrentDomain.BaseDirectory + resourcesConfig.StopResourcePath;
            if (!File.Exists(_resourcesConfig.StopResourcePath))
            {
                throw new FileNotFoundException("Could not find file " + _resourcesConfig.StopResourcePath);
            }
        }
        
        /// <summary>
        /// Imports the Stops from the Stops resources file.
        /// The results from this are then returned with a GET to '/api/stops'.
        /// </summary>
         
        public List<Stop> ImportStops()
        {
            using var reader = new StreamReader(_resourcesConfig.StopResourcePath);
            var jsonString = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Stop>>(jsonString);
        }
        
        
    }
}