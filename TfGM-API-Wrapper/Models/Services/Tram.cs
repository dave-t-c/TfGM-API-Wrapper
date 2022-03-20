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
            
        /// <summary>
        /// Determines if this Tram object and an other object are equal.
        /// All fields are considered.
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>boolean: True if Equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Tram tram = (Tram) obj;
            return Destination == tram?.Destination &&
                   Carriages == tram?.Carriages &&
                   Status == tram?.Status &&
                   Wait == tram?.Wait;
        }

        /// <summary>
        /// Returns a Hash Code for this Tram that combines
        /// Hash Codes for all fields.
        /// </summary>
        /// <returns>int: Hash Code Generated using this Tram object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Destination, Carriages, Status, Wait);
        }

    }
}