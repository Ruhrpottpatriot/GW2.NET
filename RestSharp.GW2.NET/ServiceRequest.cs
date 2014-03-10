// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a RestSharp-specific implementation of the <see cref="IServiceRequest" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.Utilities;

    using global::GW2DotNET.V1.Core;

    /// <summary>
    ///     Provides a RestSharp-specific implementation of the <see cref="IServiceRequest" /> interface.
    /// </summary>
    public abstract class ServiceRequest : RestRequest, IServiceRequest
    {
        /// <summary>TODO The preferred language parameter.</summary>
        private readonly Parameter preferredLanguageParameter;

        /// <summary>TODO The preferred language info.</summary>
        private CultureInfo preferredLanguageInfo;

        /// <summary>Initializes a new instance of the <see cref="ServiceRequest"/> class.</summary>
        /// <param name="resource">The service endpoint.</param>
        protected ServiceRequest(string resource)
            : this(new Uri(resource, UriKind.Relative))
        {
            this.AddParameter(this.preferredLanguageParameter = new Parameter { Name = "lang", Value = string.Empty, Type = ParameterType.GetOrPost });
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceRequest"/> class.</summary>
        /// <param name="resource">The service endpoint as a relative URI.</param>
        protected ServiceRequest(Uri resource)
            : base(Preconditions.EnsureNotNull(paramName: "resource", value: resource))
        {
            if (resource.IsAbsoluteUri)
            {
                throw new ArgumentException("'resource' should be a relative path.");
            }
        }

        /// <summary>
        ///     Gets or sets the preferred language info.
        /// </summary>
        public CultureInfo PreferredLanguageInfo
        {
            get
            {
                return this.preferredLanguageInfo;
            }

            set
            {
                this.preferredLanguageParameter.Value = ((this.preferredLanguageInfo = value) == null) ? string.Empty : value.TwoLetterISOLanguageName;
            }

            // don't worry about the weird syntax. All it does is synchronize values.
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public virtual IServiceResponse<TContent> GetResponse<TContent>(IServiceClient serviceClient) where TContent : global::GW2DotNET.V1.Core.JsonObject
        {
            return serviceClient.Send<TContent>(this);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public virtual Task<IServiceResponse<TContent>> GetResponseAsync<TContent>(IServiceClient serviceClient)
            where TContent : global::GW2DotNET.V1.Core.JsonObject
        {
            return serviceClient.SendAsync<TContent>(this);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public virtual Task<IServiceResponse<TContent>> GetResponseAsync<TContent>(IServiceClient serviceClient, CancellationToken cancellationToken)
            where TContent : global::GW2DotNET.V1.Core.JsonObject
        {
            return serviceClient.SendAsync<TContent>(this, cancellationToken);
        }
    }
}