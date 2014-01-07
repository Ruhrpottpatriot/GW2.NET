using GW2DotNET.V1.Core;
using Newtonsoft.Json;
using System;
using System.Net;

namespace RestSharp.GW2DotNET.V1
{
    public class ApiResponse<TContent> : IApiResponse<TContent>
    {

        protected readonly IRestResponse InnerResponse;

        public ApiResponse(IRestResponse innerResponse)
        {
            this.InnerResponse = innerResponse;
        }

        public bool IsSuccessStatusCode
        {
            get
            {
                return InnerResponse.StatusCode == HttpStatusCode.OK;
            }
        }

        public ApiResponse<TContent> EnsureSuccessStatusCode()
        {
            if (IsSuccessStatusCode)
            {
                return this;
            }
            var apiException = DeserializeError();
            if (InnerResponse.StatusCode == HttpStatusCode.InternalServerError)
            { /* HTTP status 500 (typically) indicates missing or invalid arguments */
                throw new ArgumentException(apiException.Message, apiException);
            }
            else
            { /* Unknown error */
                throw apiException;
            }
        }

        public TContent DeserializeObject()
        {
            return JsonConvert.DeserializeObject<TContent>(InnerResponse.Content);
        }

        public ApiException DeserializeError()
        {
            if (IsSuccessStatusCode)
            {
                throw new InvalidOperationException();
            }
            var errorDetails = JsonConvert.DeserializeAnonymousType(InnerResponse.Content, new /* anonymous object */
            {
                /*int*/ error = 0,
                /*int*/ product = 0,
                /*int*/ module = 0,
                /*int*/ line = 0,
                /*string*/ text = string.Empty
            });
            return new ApiException
            (
                errorDetails.error,
                errorDetails.product,
                errorDetails.module,
                errorDetails.line,
                errorDetails.text,
                InnerResponse.ErrorException
            );
        }



        IApiResponse<TContent> IApiResponse<TContent>.EnsureSuccessStatusCode()
        {
            throw new NotImplementedException();
        }
    }
}
