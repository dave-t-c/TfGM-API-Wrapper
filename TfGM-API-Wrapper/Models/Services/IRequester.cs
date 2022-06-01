using System.Collections.Generic;

namespace TfGM_API_Wrapper.Models.Services;

/// <summary>
///     Specifies the methods and outputs that must be implemented
///     for a class to act as a service requester.
/// </summary>
public interface IRequester
{
    /// <summary>
    /// Requests the services for a given list of IDs.
    /// These IDs should be retrieved from an associated tlaref.
    /// </summary>
    /// <param name="ids">IDs to request services for</param>
    /// <returns></returns>
    public List<UnformattedServices> RequestServices(List<int> ids);
}