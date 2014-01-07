using System;
using System.Threading.Tasks;
namespace GW2DotNET.V1.Core
{
    public interface IApiRequest
    {
        IApiResponse<TResponse> GetResponse<TResponse>(IApiClient handler);
        Task<IApiResponse<TResponse>> GetResponseAsync<TResponse>(IApiClient handler);
    }
}
