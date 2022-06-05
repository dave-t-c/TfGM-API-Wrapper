using System;
using System.Collections.Generic;
using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper.Models.Stops;

/// <summary>
/// Data model for processing stops related
/// requests.
/// </summary>
public class StopsDataModel: IStopsDataModel
{
    private readonly ImportedResources _importedResources;

    public StopsDataModel(ImportedResources importedResources)
    {
        _importedResources = importedResources;
        Console.WriteLine(_importedResources.ImportedStops.Count);
    }
    
    /// <summary>
    /// Returns the stops from the imported resources injected
    /// into the stops model.
    /// </summary>
    /// <returns></returns>
    public List<Stop> GetStops()
    {
        return _importedResources.ImportedStops;
    }
}