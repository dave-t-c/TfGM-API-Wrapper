namespace TfGM_API_Wrapper.Models.Services
{
    /// <summary>
    /// Stores service information about a single tram.
    /// </summary>
    public class Tram
    {
        public string Destination { get; set; }
        public string Carriages { get; set; }
        public string Status { get; set; }
        public string Wait { get; set; }

        //TODO Add Equals Method
    }
}