using System.IO;
using Newtonsoft.Json;
using TfGM_API_Wrapper.Models.Services;

namespace TfGM_API_Wrapper_Tests.TestModels.TestServices;

/// <summary>
///     Imports the services from the stored json test files into an UnformattedServices Object.
/// </summary>
public class ImportServicesResponse
{
    /// <summary>
    ///     Reads a json file and returns an UnformattedServices object created using the api response.
    /// </summary>
    /// <param name="path">Path to services api response</param>
    /// <returns>Created UnformattedServices from given api response path.</returns>
    public UnformattedServices? ImportUnformattedServices(string path)
    {
        using var reader = new StreamReader(path);
        var jsonString = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<UnformattedServices>(jsonString);
    }
}