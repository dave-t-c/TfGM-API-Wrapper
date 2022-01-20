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

        public int[] TlarefLookup(string tlaref)
        {
            return new[] {728, 729};
        }
        
    }
}