using System.Collections.Generic;

namespace TfGM_API_Wrapper.Models.Resources
{
    /// <summary>
    /// Class for storing the resources that have been imported into the program.
    /// </summary>
    public class ImportedResources
    {
        public List<Stop> ImportedStops { get; set; }

        public ImportedResources()
        {
            ImportedStops = new List<Stop>();
        }
    }
}