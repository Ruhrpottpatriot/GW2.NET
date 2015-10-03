// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a service that retrieves data from the /v1/build.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Builds
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using GW2NET.Builds;
    using GW2NET.Common;
    using GW2NET.V1.Builds.Json;

    /// <summary>Represents a service that retrieves data from the /v1/build.json interface.</summary>
    /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
    public class BuildService : IBuildService
    {
        private readonly IConverter<BuildDTO, Build> buildConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="BuildService"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="buildConverter">An object that can convert <see cref="BuildDTO"/> to <see cref="Build"/>.</param>
        /// <exception cref="ArgumentNullException">This constructor does not accept null as a valid argument.</exception>
        public BuildService(IServiceClient serviceClient, IConverter<BuildDTO, Build> buildConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (buildConverter == null)
            {
                throw new ArgumentNullException("buildConverter");
            }

            this.serviceClient = serviceClient;
            this.buildConverter = buildConverter;
        }

        /// <inheritdoc />
        Build IBuildService.GetBuild()
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
        Task<Build> IBuildService.GetBuildAsync()
        {
            IBuildService self = this;
            return self.GetBuildAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Build> IBuildService.GetBuildAsync(CancellationToken cancellationToken)
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