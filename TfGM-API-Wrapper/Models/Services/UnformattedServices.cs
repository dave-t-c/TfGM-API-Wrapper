namespace TfGM_API_Wrapper.Models.Services
{
    /// <summary>
    /// Stores unformatted service information, which is the result of a request to the TfGM API.
    /// This uses the result of a request to a single ID.
    /// </summary>
    public class UnformattedServices
    {
        public int Id { get; set; }
        public string Line { get; set; }
        public string Tlaref { get; set; }
        public string Pidref { get; set; }
        public string StationLocation { get; set; }
        public string AtcoCode { get; set; }
        public string Direction { get; set; }
        public string Dest0 { get; set; }
        public string Carriages0 { get; set; }
        public string Status0 { get; set; }
        public string Wait0 { get; set; }
        public string Dest1 { get; set; }
        public string Carriages1 { get; set; }
        public string Status1 { get; set; }
        public string Wait1 { get; set; }
        public string Dest2 { get; set; }
        public string Carriages2 { get; set; }
        public string Status2 { get; set; }
        public string Wait2 { get; set; }
        public string Dest3 { get; set; }
        public string Carriages3 { get; set; }
        public string Status3 { get; set; }
        public string Wait3 { get; set; }
        public string MessageBoard { get; set; }
        public string LastUpdated { get; set; }
    }
}
    