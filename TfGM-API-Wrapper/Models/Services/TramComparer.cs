using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TfGM_API_Wrapper.Models.Services
{
    public class TramComparer : IComparer<Tram>
    {
        public int Compare(Tram aTram, Tram bTram)
        {
            int aTramWait = Int32.Parse(aTram?.Wait ?? "-1");
            int bTramWait = Int32.Parse(bTram?.Wait ?? "-1");
            return aTramWait.CompareTo(bTramWait);
        }
    }
}