using System.Collections.Generic;
using TfGM_API_Wrapper.Models.Stops;

namespace TfGM_API_Wrapper.Models.Resources;

/// <summary>
///     Class for storing the resources that have been imported into the program.
/// </summary>
public class ImportedResources
{
    /// <summary>
    /// Creates a new imported resources with empty objects.
    /// </summary>
    public ImportedResources()
    {
        ImportedStops = new List<Stop>();
        StationNamesToTlaref = new Dictionary<string, string>();
        TlarefsToIds = new Dictionary<string, List<int>>();
    }

    /// <summary>
    /// Stores the stops imported into the application
    /// </summary>
    public List<Stop> ImportedStops { get; init; }
    
    /// <summary>
    /// Stores a dict from the station name to it's associated tlaref
    /// </summary>
    public Dictionary<string, string> StationNamesToTlaref { get; init; }
    
    /// <summary>
    /// Stores a dict from a stops tlaref, to a list of it's IDs. A stop can have multiple IDs.
    /// An ID here is usually associated with a passenger information display.
    /// </summary>
    public Dictionary<string, List<int>> TlarefsToIds { get; init; }
}