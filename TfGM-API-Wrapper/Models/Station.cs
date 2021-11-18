using System.Collections;

namespace TfGM_API_Wrapper.Models
{
    /// <summary>
    /// Stores information about a single station.
    /// </summary>
    public class Station
    {
            public string StationName { get; set; }
            public string Tlaref { get; set; }
            public ArrayList Ids { get; set; }
            public string NaptanId { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Street { get; set; }
            public string RoadCrossing { get; set; }
            public ArrayList Lines { get; set; }
    }
}