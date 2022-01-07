using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper.Models
{
    /// <summary>
    /// Looks up the Stop Information for a
    /// given stop.
    /// This will return the IDs from either a stop name, e.g. Victoria,
    /// or a TLARef, e.g. ALT.
    /// </summary>
    public class StopLookup
    {
        private readonly ResourcesConfig _resourcesConfig;
        
        public StopLookup(ResourcesConfig resourcesConfig)
        {
            _resourcesConfig = resourcesConfig;
        }
        
    }
}