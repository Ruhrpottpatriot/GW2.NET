// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a service that retrieves data from the /v1/build.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.V1.Builds.Json;

namespace GW2NET.V1.Builds
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Builds;
    using GW2NET.Common;

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
            var buildDTO = response.Content;
            if (buildDTO == null)
            {
                return null;
            }

            return this.buildConverter.Convert(buildDTO, response);
        }

        /// <inheritdoc />
        Task<Build> IBuildService.GetBuildAsync()
        {
            IBuildService self = this;
            return self.GetBuildAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Build> IBuildService.GetBuildAsync(CancellationToken cancellationToken)
        {
            var request = new BuildRequest();
            var responseTask = this.serviceClient.SendAsync<BuildDTO>(request, cancellationToken);
            return responseTask.ContinueWith<Build>(this.ConvertAsyncResponse, cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
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