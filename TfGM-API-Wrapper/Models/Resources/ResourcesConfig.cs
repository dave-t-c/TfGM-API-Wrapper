namespace TfGM_API_Wrapper.Models.Resources;

/// <summary>
///     POCO for Resources Information.
///     This is injected into the StopsController.
/// </summary>
public class ResourcesConfig
{
    public string StopResourcePath { get; set; }
    public string StationNamesToTlarefsPath { get; set; }
    public string TlarefsToIdsPath { get; set; }

    /// <summary>
    ///     Creates a Deep Copy of this resource config object.
    /// </summary>
    /// <returns>A Deep Copy of the object.</returns>
    public ResourcesConfig DeepCopy()
    {
        return new ResourcesConfig
        {
            StopResourcePath = StopResourcePath,
            StationNamesToTlarefsPath = StationNamesToTlarefsPath,
            TlarefsToIdsPath = TlarefsToIdsPath
        };
    }
}