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
        public Build GetBuild()
        {
            var request = new BuildRequest();
            var response = this.serviceClient.Send<BuildDTO>(request);
            var dataContract = response.Content;

            if (dataContract == null)
            {
                return null;
            }

            return this.buildConverter.Convert(dataContract, response);
        }

        /// <inheritdoc />
        public Task<Build> GetBuildAsync()
        {
            BuildService self = this;
            return self.GetBuildAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        public Task<Build> GetBuildAsync(CancellationToken cancellationToken)
        {
            var request = new BuildRequest();
            var responseTask = this.serviceClient.SendAsync<BuildDTO>(request, cancellationToken);
            return responseTask.ContinueWith<Build>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <summary>Converts an asynchronous response for for further processing.</summary>
        /// <param name="task">The task to convert.</param>
        /// <returns>The <see cref="Build"/>.</returns>
        private Build ConvertAsyncResponse(Task<IResponse<BuildDTO>> task)
        {
            var response = task.Result;
            var buildDTO = response.Content;
            if (buildDTO == null)
            {
                return null;
            }

            return this.buildConverter.Convert(buildDTO, response);
        }
    }
}
