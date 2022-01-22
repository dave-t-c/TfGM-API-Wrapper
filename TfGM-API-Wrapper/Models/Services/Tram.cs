namespace TfGM_API_Wrapper.Models.Services
{
    /// <summary>
    /// Stores service information about a single tram.
    /// </summary>
    public class Tram
    {
        public string Destination { get;}
        public string Carriages { get; }
        public string Status { get; }
        public string Wait { get; }


        public Tram(string destination, string carriages, string status, string wait)
        {
            this.Destination = "Example Destination";
            this.Carriages = "Single";
            this.Status = "Due";
            this.Wait = "9";
        }
            
        //TODO Add Equals Method
    }
}