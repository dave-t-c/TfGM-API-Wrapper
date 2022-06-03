using System.Collections;

namespace TfGM_API_Wrapper.Models.Stops;

/// <summary>
///     Stores information about a single stop.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global
public class Stop
{
    /// <summary>
    /// Name of the stop, such as Piccadilly
    /// </summary>
    public string StopName { get; set; }
    
    /// <summary>
    /// 3 code ID for the stop, e.g. PIC for Piccadilly 
    /// </summary>
    public string Tlaref { get; set; }
    
    /// <summary>
    /// IDs associated with the stop. Larger stops will have more IDs.
    /// </summary>
    public ArrayList Ids { get; set; }
    
    /// <summary>
    /// Naptan ID for the stop. This can be used to look up more information
    /// in government transport data sets
    /// </summary>
    public string AtcoCode { get; set; }
    
    /// <summary>
    /// Stop Latitude. This may be different to that shown by apple or google maps.
    /// </summary>
    public double Latitude { get; set; }
    
    /// <summary>
    /// Stop Longitude. This may be different to that shown by apple or google maps.
    /// </summary>
    public double Longitude { get; set; }
    
    /// <summary>
    /// Street the stop is on. If it is not directly on a street, it will be prefixed
    /// with 'Off'.
    /// </summary>
    public string Street { get; set; }
    
    /// <summary>
    /// Closest road intersection to the stop. For stops where there is not a close intersection,
    /// this will be blank. 
    /// </summary>
    public string RoadCrossing { get; set; }
    
    /// <summary>
    /// Line the stop is on. This is a single value and does not contain all lines.
    /// This will be a destination, such as Bury, and does not include the line colour(s).
    /// </summary>
    public string Line { get; set; }
    
    /// <summary>
    /// Ticket fare zone for the stop. If a stop is in multiple zones, it will
    /// be shown as 'a/b', where a is the smaller of the two zones, e.g. '3/4'.
    /// </summary>
    public string StopZone { get; set; }
}