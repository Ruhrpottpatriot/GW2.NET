using System;
using System.Threading.Tasks;
namespace GW2DotNET.V1.Core
{
    public interface IApiClient
    {
        IApiResponse<TResponse> Send<TResponse>(IApiRequest request);
        Task<IApiResponse<TResponse>> SendAsync<TResponse>(IApiRequest request);
    }
}
