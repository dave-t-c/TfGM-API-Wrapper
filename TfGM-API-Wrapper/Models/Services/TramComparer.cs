using System.Collections.Generic;

namespace TfGM_API_Wrapper.Models.Services;

public class TramComparer : IComparer<Tram>
{
    public int Compare(Tram aTram, Tram bTram)
    {
        var aTramWait = int.Parse(aTram?.Wait ?? "-1");
        var bTramWait = int.Parse(bTram?.Wait ?? "-1");
        return aTramWait.CompareTo(bTramWait);
    }
}