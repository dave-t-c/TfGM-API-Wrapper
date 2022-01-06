namespace TfGM_API_Wrapper.Models
{
    /// <summary>
    /// POCO for Resources Information.
    /// This is injected into the StopsController.
    /// </summary>
    public class ResourcesConfig
    {
        public string StopResourcePath { get; set; }
        public string StationNamesToTlarefsPath { get; set; }
        public string TlarefsToIdsPath { get; set; }
    }
}