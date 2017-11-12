// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Builds
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Builds;
    using GW2NET.Common;
    using GW2NET.V2.Builds.Converters;
    using GW2NET.V2.Builds.Json;

    /// <summary>Represents a service that retrieves data from the /v1/build.json interface.</summary>
    /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:2/build">wiki</a> for more information.</remarks>
    public class BuildService : IBuildService
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IConverter<BuildDataContract, Build> converterForBuild;

        /// <summary> Initializes a new instance of the <see cref="BuildService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public BuildService(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForBuild())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="BuildService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForBuild">The converter for <see cref="Build"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="converterForBuild"/> is a null reference.</exception>
        internal BuildService(IServiceClient serviceClient, IConverter<BuildDataContract, Build> converterForBuild)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (converterForBuild == null)
            {
                throw new ArgumentNullException("converterForBuild", "Precondition: converterForBuild != null");
            }

            this.serviceClient = serviceClient;
            this.converterForBuild = converterForBuild;
        }

        /// <inheritdoc />
        public Build GetBuild()
        {
            var request = new BuildRequest();
            var response = this.serviceClient.Send<BuildDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var value = this.converterForBuild.Convert(response.Content);
            if (value == null)
            {
                return null;
            }

            value.Timestamp = response.Date;
            return value;
        }

        /// <inheritdoc />
        public Task<Build> GetBuildAsync()
        {
            BuildService self = this;
            return self.GetBuildAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task<Build> GetBuildAsync(CancellationToken cancellationToken)
        {
            var request = new BuildRequest();
            var response = await this.serviceClient.SendAsync<BuildDataContract>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return null;
            }

            var value = this.converterForBuild.Convert(response.Content);
            if (value == null)
            {
                return null;
            }

            value.Timestamp = response.Date;
            return value;
        }
    }
}
