// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GW2.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to Guild Wars 2 data sources and services.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Serializers;
    using GW2NET.Compression;
    using GW2NET.Factories;

    /// <summary>Provides access to Guild Wars 2 data sources and services.</summary>
    public static class GW2
    {
        /// <summary>Initializes static members of the <see cref="GW2"/> class.</summary>
        static GW2()
        {
            var repositoryProxy = GetRepositoryProxy();
            var renderingProxy = GetRenderingProxy();
            V1 = new FactoryForV1(repositoryProxy);
            V2 = new FactoryForV2(repositoryProxy);
            Rendering = new FactoryForRendering(renderingProxy);
            Local = new FactoryForLocal();
        }

        /// <summary>Provides access to specialty services that do not require a network connection.</summary>
        public static FactoryForLocal Local { get; private set; }

        /// <summary>Provides access to the rendering service.</summary>
        public static FactoryForRendering Rendering { get; private set; }

        /// <summary>Provides access to version 1 of the public API.</summary>
        public static FactoryForV1 V1 { get; private set; }

        /// <summary>Provides access to version 2 of the public API.</summary>
        public static FactoryForV2 V2 { get; private set; }

        /// <summary>Infrastructure. Creates and configures an instance of the default service client.</summary>
        /// <returns>The <see cref="IServiceClient"/>.</returns>
        private static IServiceClient GetRenderingProxy()
        {
            Contract.Ensures(Contract.Result<IServiceClient>() != null);
            var baseUri = GetRenderingUri();
            var imageSerializerFactory = new BinarySerializerFactory();
            var jsonSerializerFactory = new JsonSerializerFactory();
            var gzipInflator = new GzipInflator();
            return new ServiceClient(baseUri, imageSerializerFactory, jsonSerializerFactory, gzipInflator);
        }

        /// <summary>Gets the base URI.</summary>
        /// <returns>A <see cref="Uri"/>.</returns>
        private static Uri GetRenderingUri()
        {
            Contract.Ensures(Contract.Result<Uri>() != null);
            Contract.Ensures(Contract.Result<Uri>().IsAbsoluteUri);
            var baseUri = new Uri("https://render.guildwars2.com", UriKind.Absolute);
            Contract.Assume(baseUri.IsAbsoluteUri);
            return baseUri;
        }

        /// <summary>Infrastructure. Creates and configures an instance of the default service client.</summary>
        /// <returns>The <see cref="IServiceClient"/>.</returns>
        private static IServiceClient GetRepositoryProxy()
        {
            Contract.Ensures(Contract.Result<IServiceClient>() != null);
            var baseUri = GetRepositoryUri();
            var jsonSerializerFactory = new JsonSerializerFactory();
            var gzipInflator = new GzipInflator();
            return new ServiceClient(baseUri, jsonSerializerFactory, jsonSerializerFactory, gzipInflator);
        }

        /// <summary>Gets the base URI.</summary>
        /// <returns>A <see cref="Uri"/>.</returns>
        private static Uri GetRepositoryUri()
        {
            Contract.Ensures(Contract.Result<Uri>() != null);
            Contract.Ensures(Contract.Result<Uri>().IsAbsoluteUri);
            var baseUri = new Uri("https://api.guildwars2.com", UriKind.Absolute);
            Contract.Assume(baseUri.IsAbsoluteUri);
            return baseUri;
        }
    }
}