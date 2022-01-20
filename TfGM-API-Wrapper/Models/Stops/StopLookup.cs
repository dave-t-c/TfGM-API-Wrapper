using System;
using System.Collections.Generic;
using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper.Models.Stops
{
    /// <summary>
    /// Looks up the Stop Information for a
    /// given stop.
    /// This will return the IDs from either a stop name, e.g. Victoria,
    /// or a TLARef, e.g. ALT.
    /// </summary>
    public class StopLookup
    {
        private readonly ImportedResources _importedResources;
        
        public StopLookup(ImportedResources importedResources)
        {
            _importedResources = importedResources;
        }

        /// <summary>
        /// Returns API IDs for a given Tlaref.
        /// </summary>
        /// <param name="tlaref">Stop Tlaref, e.g. 'ALT'.</param>
        /// <returns>Int list of IDs for the stop</returns>
        public List<int> TlarefLookup(string tlaref)
        {
            if (tlaref == null) throw new ArgumentNullException(nameof(tlaref));
            return _importedResources.TlarefsToIds[tlaref];
        }
        
    }
}