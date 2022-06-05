using System.Collections.Generic;

namespace TfGM_API_Wrapper.Models.Stops;

public interface IStopsDataModel
{
    public List<Stop> GetStops();
}