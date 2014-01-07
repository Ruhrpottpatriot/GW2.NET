using GW2DotNET.V1.Core;
using System;
using System.Threading.Tasks;

namespace RestSharp.GW2DotNET.V1
{
    public class ApiClient : IApiClient
    {

        protected readonly IRestClient InnerClient;

        internal ApiClient(IRestClient innerClient)
        {
            if (innerClient == null)
            {
                throw new ArgumentNullException("innerClient");
            }
            InnerClient = innerClient;
        }

        public ApiClient(Uri baseUrl)
        {
            if (baseUrl == null)
            {
                throw new ArgumentNullException("baseUrl");
            }
            if (!baseUrl.IsAbsoluteUri)
            {
                throw new ArgumentException("'baseUrl' cannot be a relative URI.");
            }
            InnerClient = new RestClient(baseUrl.ToString());
        }

        public static IApiClient Create(Version apiVersion)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException("apiVersion");
            }
            return new ApiClient(new Uri(string.Format("https://api.guildwars2.com/v{0}/", apiVersion.Major)));
        }

        public IApiResponse<TResponse> Send<TResponse>(IApiRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            return Send<TResponse>(request as ApiRequest);
        }

        private IApiResponse<TResponse> Send<TResponse>(ApiRequest request)
        {
            if (request == null)
            { /* The specified request is of an incompatible type */
                throw new NotSupportedException("Incompatible request type");
            }
            return SendImplementation<TResponse>(request.InnerRequest);
        }

        private IApiResponse<TResponse> SendImplementation<TResponse>(IRestRequest request)
        {
            IRestResponse response = InnerClient.Execute(request);
            return new ApiResponse<TResponse>(response);
        }

        public Task<IApiResponse<TResponse>> SendAsync<TResponse>(IApiRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            return SendAsync<TResponse>(request as ApiRequest);
        }

        private Task<IApiResponse<TResponse>> SendAsync<TResponse>(ApiRequest request)
        {
            if (request == null)
            { /* The specified request is of an incompatible type */
                throw new NotSupportedException("Incompatible request type");
            }
            return SendAsyncImplementation<TResponse>(request.InnerRequest);
        }

        private Task<IApiResponse<TResponse>> SendAsyncImplementation<TResponse>(IRestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            InnerClient.ExecuteAsync(request, (response) =>
                {
                    if (response.ErrorException != null)
                    {
                        tcs.SetException(response.ErrorException);
                    }
                    else
                    {
                        tcs.SetResult(response);
                    }
                });
            return tcs.Task.ContinueWith<IApiResponse<TResponse>>((response) =>
                {
                    return new ApiResponse<TResponse>(response.Result);
                });
        }

    }
}
