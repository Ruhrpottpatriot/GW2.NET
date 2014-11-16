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
            var serviceClient = GetDefaultServiceClient();
            V1 = new FactoryForV1(serviceClient);
            V2 = new FactoryForV2(serviceClient);
            Local = new FactoryForLocal();
        }

        public static FactoryForV1 V1 { get; private set; }

        public static FactoryForV2 V2 { get; private set; }

        public static FactoryForLocal Local { get; private set; }

        /// <summary>Gets the base URI.</summary>
        /// <returns>A <see cref="Uri"/>.</returns>
        private static Uri GetBaseUri()
        {
            Contract.Ensures(Contract.Result<Uri>() != null);
            Contract.Ensures(Contract.Result<Uri>().IsAbsoluteUri);
            var baseUri = new Uri("https://api.guildwars2.com", UriKind.Absolute);
            Contract.Assume(baseUri.IsAbsoluteUri);
            return baseUri;
        }

        /// <summary>Infrastructure. Creates and configures an instance of the default service client.</summary>
        /// <returns>The <see cref="IServiceClient"/>.</returns>
        private static IServiceClient GetDefaultServiceClient()
        {
            Contract.Ensures(Contract.Result<IServiceClient>() != null);
            var baseUri = GetBaseUri();
            var serializerFactory = new JsonSerializerFactory();
            var gzipInflator = new GzipInflator();
            return new ServiceClient(baseUri, serializerFactory, serializerFactory, gzipInflator);
        }
    }
}
