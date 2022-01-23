using System;
using System.Collections.Generic;

namespace TfGM_API_Wrapper.Models.Services
{
    public class FormattedServices
    {

        public Dictionary<String, SortedSet<Tram>> Destinations { get; }

        public FormattedServices()
        {
            Destinations = new Dictionary<string, SortedSet<Tram>>();
        }

        public void AddService(Tram tram)
        {
            Destinations[tram.Destination] = new SortedSet<Tram>(new TramComparer());
            Destinations[tram.Destination].Add(tram);
        }
    }
}