// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the build service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Builds
{
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Builds;
    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.V1.Builds.Contracts;

    /// <summary>Provides the default implementation of the build service.</summary>
    public class BuildService : IBuildService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="BuildService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public BuildService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets the current game build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Build GetBuild()
        {
            var request = new BuildRequest();
            var response = this.serviceClient.Send(request, new JsonSerializer<BuildContract>());
            var value = MapBuildContract(response.Content);
            value.Timestamp = response.LastModified;
            return value;
        }

        /// <summary>Gets the current build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync()
        {
            return this.GetBuildAsync(CancellationToken.None);
        }

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync(CancellationToken cancellationToken)
        {
            var request = new BuildRequest();
            return this.serviceClient.SendAsync(request, new JsonSerializer<BuildContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        var value = MapBuildContract(response.Content);
                        value.Timestamp = response.LastModified;
                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Build MapBuildContract(BuildContract content)
        {
            return new Build { BuildId = content.BuildId };
        }
    }
}