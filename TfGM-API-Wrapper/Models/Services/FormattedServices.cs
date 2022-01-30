using System;
using System.Collections.Generic;

namespace TfGM_API_Wrapper.Models.Services
{
    /// <summary>
    /// Stores services by destination, ordered by ascending wait time. 
    /// </summary>
    public class FormattedServices
    {

        public Dictionary<String, SortedSet<Tram>> Destinations { get; }
        public HashSet<string> Messages { get; }

        public FormattedServices()
        {
            Destinations = new Dictionary<string, SortedSet<Tram>>();
            Messages = new HashSet<string>();
        }

        /// <summary>
        /// Adds a tram to the formatted services.
        /// This will add it to a set for trams with the same destination. 
        /// </summary>
        /// <param name="tram">Tram service to add</param>
        public void AddService(Tram tram)
        {
            if (tram == null) return;
            if (!Destinations.ContainsKey(tram.Destination))
                Destinations[tram.Destination] = new SortedSet<Tram>(new TramComparer());
            
            Destinations[tram.Destination].Add(tram);
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}