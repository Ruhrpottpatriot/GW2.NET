// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Builds
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Builds;
    using GW2NET.Common;
    using GW2NET.V2.Builds.Json;

    /// <summary>Represents a service that retrieves data from the /v1/build.json interface.</summary>
    /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:2/build">wiki</a> for more information.</remarks>
    public class BuildService : IBuildService
    {
        private readonly IServiceClient serviceClient;

        private readonly IConverter<BuildDTO, Build> buildConverter;

        /// <summary>Initializes a new instance of the <see cref="BuildService"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="buildConverter">The converter for <see cref="Build"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="buildConverter"/> is a null reference.</exception>
        public BuildService(IServiceClient serviceClient, IConverter<BuildDTO, Build> buildConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException(nameof(serviceClient));
            }

            if (buildConverter == null)
            {
                throw new ArgumentNullException(nameof(buildConverter));
            }

            this.serviceClient = serviceClient;
            this.buildConverter = buildConverter;
        }

        /// <inheritdoc />
        public Build GetBuild()
        {
            var request = new BuildRequest();
            var response = this.serviceClient.Send<BuildDTO>(request);
            if (response.Content == null)
            {
                return null;
            }

            return this.buildConverter.Convert(response.Content, response);
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
            var response = await this.serviceClient.SendAsync<BuildDTO>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return null;
            }

            return this.buildConverter.Convert(response.Content, response);
        }
    }
}
