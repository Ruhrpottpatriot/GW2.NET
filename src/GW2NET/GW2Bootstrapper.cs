// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GW2Bootstrapper.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to Guild Wars 2 data sources and services.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using GW2NET.Common;
    using GW2NET.Common.Serializers;
    using GW2NET.Compression;
    using GW2NET.Factories;
    using GW2NET.Factories.V2;

    /// <summary>Provides access to Guild Wars 2 data sources and services.</summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Naming is intended.")]
    public class GW2Bootstrapper
    {
        /// <summary>Initializes a new instance of the <see cref="GW2Bootstrapper"/> class.</summary>
        public GW2Bootstrapper()
            : this(string.Empty)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="GW2Bootstrapper"/> class.</summary>
        /// <param name="apiKey">The api key.</param>
        public GW2Bootstrapper(string apiKey)
        {
            // Create instances of the ServiceClients used for the repositories.
            IServiceClient serviceClient = this.CreateServiceClient();
            IServiceClient renderingServiceClient = this.CreateRenderingServiceClient();

            // Pupulate the repository properties
            this.Services = new Services(serviceClient);
            this.Rendering = new FactoryForRendering(renderingServiceClient);
            this.Local = new FactoryForLocal();

            // Authorisation specific code.
            if (KeyUtilities.IsValid(apiKey))
            {
                IServiceClient authServiceClient = this.CreateAuthorizedServiceClient(apiKey);
                this.AuthorizedServices = new AuthorizedServices(authServiceClient);
            }
        }

        /// <summary>Gets access to specialty services that do not require a network connection.</summary>
        public FactoryForLocal Local { get; private set; }

        /// <summary>Gets access to the rendering service.</summary>
        public FactoryForRendering Rendering { get; private set; }

        /// <summary>Gets access to the public area of the version 2 of the Guild Wars 2 API.</summary>
        public Services Services { get; private set; }

        /// <summary> Gets access to the authorized area of the Guild Wars 2 API.</summary>
        public AuthorizedServices AuthorizedServices { get; private set; }

        /// <summary>Sets the api key for further use.</summary>
        /// <param name="apiKey">The api key.</param>
        public void SetApiKey(string apiKey)
        {
            if (KeyUtilities.IsValid(apiKey))
            {
                this.AuthorizedServices = new AuthorizedServices(this.CreateAuthorizedServiceClient(apiKey));
            }
            else
            {
                throw new ArgumentException("The api key didn't have the required format.", "apiKey");
            }
        }

        /// <summary>Creates and configures an instance of the default service client.</summary>
        /// <returns>The <see cref="IServiceClient"/>.</returns>
        private IServiceClient CreateRenderingServiceClient()
        {
            Uri baseUri = this.GetRenderingUri();
            BinarySerializerFactory imageSerializerFactory = new BinarySerializerFactory();
            JsonSerializerFactory jsonSerializerFactory = new JsonSerializerFactory();
            GzipInflator gzipInflator = new GzipInflator();
            return new ServiceClient(baseUri, imageSerializerFactory, jsonSerializerFactory, gzipInflator);
        }

        /// <summary>Creates and configures an instance of the default service client.</summary>
        /// <returns>The <see cref="IServiceClient"/>.</returns>
        private IServiceClient CreateServiceClient()
        {
            Uri baseUri = this.GetRepositoryUri();
            JsonSerializerFactory jsonSerializerFactory = new JsonSerializerFactory();
            GzipInflator gzipInflator = new GzipInflator();
            return new ServiceClient(baseUri, jsonSerializerFactory, jsonSerializerFactory, gzipInflator);
        }

        /// <summary>Creates and configures an instance of an authorized service client.</summary>
        /// <param name="apiKey">The api key grating access to the authorized area.</param>
        /// <returns>The <see cref="IServiceClient"/>.</returns>
        private IServiceClient CreateAuthorizedServiceClient(string apiKey)
        {
            Uri baseUri = this.GetRepositoryUri();
            JsonSerializerFactory jsonSerializerFactory = new JsonSerializerFactory();
            GzipInflator gzipInflator = new GzipInflator();
            return new ServiceClientAuthorized(baseUri, apiKey, jsonSerializerFactory, jsonSerializerFactory, gzipInflator);
        }

        /// <summary>Gets the base URI.</summary>
        /// <returns>A <see cref="Uri"/>.</returns>
        private Uri GetRenderingUri()
        {
            return new Uri("https://render.guildwars2.com", UriKind.Absolute);
        }

        /// <summary>Gets the base URI.</summary>
        /// <returns>A <see cref="Uri"/>.</returns>
        private Uri GetRepositoryUri()
        {
            return new Uri("https://api.guildwars2.com", UriKind.Absolute);
        }
    }
}