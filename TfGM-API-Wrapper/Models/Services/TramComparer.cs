using System;
using System.Collections.Generic;

namespace TfGM_API_Wrapper.Models.Services
{
    public class TramComparer : IComparer<Tram>
    {
        public int Compare(Tram aTram, Tram bTram)
        {
            // This uses ordinal comparison so strings can be used for the wait time.
            // This is to keep consistency with the types output by the API.
            return string.Compare(aTram?.Wait, bTram?.Wait, StringComparison.Ordinal);
        }
    }
}