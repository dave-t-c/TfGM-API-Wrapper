using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static System.AppDomain;

namespace TfGM_API_Wrapper.Models
{
    /// <summary>
    /// Loads in the Stop data from the resources folder.
    /// </summary>
    public class StopLoader
    {
        private readonly string _stopsPath;
    
        /// <summary>
        /// Create a new StopLoader Object, which can import the required Stops.
        /// </summary>
        /// <param name="stopsPath">Path from current base directory to Stops resources file.</param>
        public StopLoader(string stopsPath)
        {
            _stopsPath = stopsPath ?? throw new ArgumentNullException(nameof(stopsPath));
            _stopsPath = CurrentDomain.BaseDirectory + _stopsPath;
            if (!File.Exists(_stopsPath))
            {
                throw new FileNotFoundException("Could not find file " + stopsPath);
            }
        }
        
        /// <summary>
        /// Imports the Stops from the Stops resources file.
        /// The results from this are then returned with a GET to '/api/stops'.
        /// </summary>
         
        public List<Stop> ImportStops()
        {
            using var reader = new StreamReader(_stopsPath);
            var jsonString = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Stop>>(jsonString);
        }
    }
}