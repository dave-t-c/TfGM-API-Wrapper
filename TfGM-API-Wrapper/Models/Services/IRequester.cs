using System.Collections.Generic;

namespace TfGM_API_Wrapper.Models.Services;

/// <summary>
///     Specifies the methods and outputs that must be implemented
///     for a class to act as a service requester.
/// </summary>
public interface IRequester
{
    public List<UnformattedServices> RequestServices(List<int> ids);
}