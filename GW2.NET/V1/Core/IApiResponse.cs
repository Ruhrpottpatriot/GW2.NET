using System;
namespace GW2DotNET.V1.Core
{
    public interface IApiResponse<TContent>
    {
        ApiException DeserializeError();
        TContent DeserializeObject();
        IApiResponse<TContent> EnsureSuccessStatusCode();
        bool IsSuccessStatusCode { get; }
    }
}
