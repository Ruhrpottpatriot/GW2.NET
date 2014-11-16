using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Serializers;
    using GW2NET.Compression;
    using GW2NET.Factories;

    public static class GW2
    {
        static GW2()
        {
            var repositoryProxy = GetRepositoryProxy();
            var renderingProxy = GetRenderingProxy();
            V1 = new FactoryForV1(repositoryProxy);
            V2 = new FactoryForV2(repositoryProxy);
            Rendering = new FactoryForRendering(renderingProxy);
            Local = new FactoryForLocal();
        }

        public static FactoryForV1 V1 { get; private set; }

        public static FactoryForV2 V2 { get; private set; }

        public static FactoryForLocal Local { get; private set; }

        public static FactoryForRendering Rendering { get; private set; }


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
    }
}
