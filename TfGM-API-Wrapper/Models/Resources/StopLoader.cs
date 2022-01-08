using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static System.AppDomain;

namespace TfGM_API_Wrapper.Models.Resources
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

            _resourcesConfig.StopResourcePath = CheckFileRequirements(resourcesConfig.StopResourcePath,
                nameof(resourcesConfig.StopResourcePath));
            
            _resourcesConfig.StationNamesToTlarefsPath = CheckFileRequirements(resourcesConfig.StationNamesToTlarefsPath,
                nameof(resourcesConfig.StationNamesToTlarefsPath));
            
            _resourcesConfig.TlarefsToIdsPath = CheckFileRequirements(resourcesConfig.TlarefsToIdsPath,
                nameof(resourcesConfig.TlarefsToIdsPath));
        }

        /// <summary>
        /// Checks the file requirements for a given file in a ResourceConfig
        /// </summary>
        /// <param name="filePath">File path to verify</param>
        /// <param name="argName">Name of the field associated with the file path</param>
        /// <returns>string - full file path for the resource.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when a null file path is given. StopLoaders cannot be created with null resource paths. 
        /// </exception>
        /// <exception cref="FileNotFoundException">
        /// Thrown when the file cannot be found from the base directory.
        /// </exception>
        private static string CheckFileRequirements(string filePath, string argName)
        {
            if(filePath is null) 
                throw new InvalidOperationException(argName + " cannot be null");
            filePath = CurrentDomain.BaseDirectory + filePath;
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Could not find file " + filePath);
            }
            return filePath;
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