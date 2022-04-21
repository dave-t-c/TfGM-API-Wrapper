using System;
using TfGM_API_Wrapper.Models.Resources;
using TfGM_API_Wrapper.Models.Stops;

namespace TfGM_API_Wrapper.Models.Services;

public class ServiceProcessor
{
    private readonly IRequester _requester;
    private readonly ServiceFormatter _serviceFormatter;
    private readonly StopLookup _stopLookup;

    public ServiceProcessor(IRequester requester, ImportedResources resources)
    {
        _requester = requester;
        _stopLookup = new StopLookup(resources);
        _serviceFormatter = new ServiceFormatter();
    }

    /// <summary>
    ///     Returns services for a given stop name or Tlaref.
    /// </summary>
    /// <param name="stop">Stop Id, either name or Tlaref. </param>
    /// <returns>Formatted Services for given stop</returns>
    public FormattedServices RequestServices(string stop)
    {
        if (stop == null) throw new ArgumentNullException(nameof(stop));
        var stopIds = _stopLookup.LookupIDs(stop);
        var unformattedServicesList = _requester.RequestServices(stopIds);
        return _serviceFormatter.FormatServices(unformattedServicesList);
    }
}