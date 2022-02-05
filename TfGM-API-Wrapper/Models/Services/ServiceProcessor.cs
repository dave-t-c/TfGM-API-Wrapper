using System.Collections.Generic;
using TfGM_API_Wrapper.Models.Resources;
using TfGM_API_Wrapper.Models.Stops;

namespace TfGM_API_Wrapper.Models.Services
{
    public class ServiceProcessor
    {
        private IRequester _requester;
        private ImportedResources _resources;
        private StopLookup _stopLookup;
        private ServiceFormatter _serviceFormatter;
        
        public ServiceProcessor(IRequester requester, ImportedResources resources)
        {
            _requester = requester;
            _resources = resources;
            _stopLookup = new StopLookup(resources);
            _serviceFormatter = new ServiceFormatter();
        }

        /// <summary>
        /// Returns services for a given stop name or Tlaref. 
        /// </summary>
        /// <param name="stop">Stop Id, either name or Tlaref. </param>
        /// <returns>Formatted Services for given stop</returns>
        public FormattedServices RequestServices(string stop)
        {
            List<int> stopIds = _stopLookup.LookupIDs(stop);
            List<UnformattedServices> unformattedServicesList = _requester.RequestServices(stopIds);
            return _serviceFormatter.FormatServices(unformattedServicesList);
        }
    }
}