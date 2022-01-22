using System;

namespace TfGM_API_Wrapper.Models.Services
{
    /// <summary>
    /// Stores service information about a single tram.
    /// </summary>
    public class Tram
    {
        public string Destination { get;}
        
        // The carriages could be a good candidate for an enum, but given there are only
        // two possible values, this may be unnecessary. 
        public string Carriages { get; }
        public string Status { get; }
        public string Wait { get; }


        public Tram(string destination, string carriages, string status, string wait)
        {
            Destination = destination ?? throw new ArgumentNullException(nameof(destination)); 
            Carriages = carriages ?? throw new ArgumentNullException(nameof(carriages));
            Status = status ?? throw new ArgumentNullException(nameof(status));
            Wait = wait ?? throw new ArgumentNullException(nameof(wait));
        }
            
        //TODO Add Equals Method
        public override bool Equals(object obj)
        {
            Tram tram = (Tram) obj;
            return Destination == tram?.Destination &&
                   Carriages == tram?.Carriages &&
                   Status == tram?.Status;
        }
        
        //TODO Add HashCode Implementation
    }
}