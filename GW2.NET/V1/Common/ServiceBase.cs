// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceBase.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for Guild Wars 2 services.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Utilities;

    /// <summary>Provides the base class for Guild Wars 2 services.</summary>
    public abstract class ServiceBase
    {
        /// <summary>The default language.</summary>
        public static readonly CultureInfo DefaultLanguage;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes static members of the <see cref="ServiceBase"/> class.</summary>
        static ServiceBase()
        {
            DefaultLanguage = new CultureInfo("en");
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        protected ServiceBase(IServiceClient serviceClient)
        {
            Preconditions.EnsureNotNull(paramName: "serviceClient", value: serviceClient);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets the service client.</summary>
        private IServiceClient ServiceClient
        {
            get
            {
                return this.serviceClient;
            }
        }

        /// <summary>Infrastructure. Sends a serviceRequest and gets the response.</summary>
        /// <param name="serviceRequest">The service serviceRequest.</param>
        /// <typeparam name="TResult">The type of the response content</typeparam>
        /// <returns>The response content.</returns>
        protected TResult Request<TResult>(IServiceRequest serviceRequest) where TResult : class
        {
            IServiceResponse<TResult> serviceResponse = null;
            try
            {
                serviceResponse = serviceRequest.GetResponse<TResult>(this.ServiceClient);
                return serviceResponse.EnsureSuccessStatusCode().Deserialize();
            }
            finally
            {
                // clean up if necessary
                var disposable = serviceResponse as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        /// <summary>Infrastructure. Sends a request and gets the response.</summary>
        /// <param name="serviceRequest">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>The response content.</returns>
        protected Task<TResult> RequestAsync<TResult>(IServiceRequest serviceRequest, CancellationToken cancellationToken) where TResult : class
        {
            return serviceRequest.GetResponseAsync<TResult>(this.ServiceClient, cancellationToken).ContinueWith(
                task =>
                    {
                        IServiceResponse<TResult> serviceResponse = null;
                        try
                        {
                            serviceResponse = task.Result;
                            return serviceResponse.EnsureSuccessStatusCode().Deserialize();
                        }
                        finally
                        {
                            // clean up if necessary
                            var disposable = serviceResponse as IDisposable;
                            if (disposable != null)
                            {
                                disposable.Dispose();
                            }
                        }
                    }, 
                cancellationToken);
        }
    }
}