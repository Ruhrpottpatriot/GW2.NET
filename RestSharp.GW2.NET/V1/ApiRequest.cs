using GW2DotNET.V1.Core;
using System;
using System.Threading.Tasks;

namespace RestSharp.GW2DotNET.V1
{
    public abstract class ApiRequest : IApiRequest
    {

        internal readonly IRestRequest InnerRequest;

        #region Constructors

        internal ApiRequest(IRestRequest innerRequest)
        {
            this.InnerRequest = innerRequest;
        }

        protected ApiRequest() : this(new RestRequest()) { }

        protected ApiRequest(string resource) : this(new RestRequest(resource)) { }

        protected ApiRequest(Uri resource) : this(new RestRequest(resource)) { }

        #endregion

        public virtual IApiResponse<TResponse> GetResponse<TResponse>(IApiClient handler)
        {
            return handler.Send<TResponse>(this);
        }

        public virtual Task<IApiResponse<TResponse>> GetResponseAsync<TResponse>(IApiClient handler)
        {
            return handler.SendAsync<TResponse>(this);
        }
    }
}
