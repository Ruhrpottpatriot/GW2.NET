// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a service that retrieves data from the /v1/build.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.V1.Builds.Converters;
using GW2NET.V1.Builds.Json;

namespace GW2NET.V1.Builds
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Builds;
    using GW2NET.Common;

    /// <summary>Represents a service that retrieves data from the /v1/build.json interface.</summary>
    /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
    public class BuildService : IBuildService
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<BuildDataContract, Build> converterForBuild;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="BuildService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public BuildService(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForBuild())
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }
        }

        /// <summary>Initializes a new instance of the <see cref="BuildService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForBuild">The converter for <see cref="Build"/>.</param>
        internal BuildService(IServiceClient serviceClient, IConverter<BuildDataContract, Build> converterForBuild)
        {
            Debug.Assert(serviceClient != null, "serviceClient != null");
            Debug.Assert(converterForBuild != null, "converterForBuild != null");
            this.serviceClient = serviceClient;
            this.converterForBuild = converterForBuild;
        }

        /// <inheritdoc />
        Build IBuildService.GetBuild()
        {
            var request = new BuildRequest();
            var response = this.serviceClient.Send<BuildDataContract>(request);
            var buildDataContract = response.Content;
            if (buildDataContract == null)
            {
                return null;
            }

            return this.converterForBuild.Convert(buildDataContract, response);
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
            var responseTask = this.serviceClient.SendAsync<BuildDataContract>(request, cancellationToken);
            return responseTask.ContinueWith<Build>(this.ConvertAsyncResponse, cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Build ConvertAsyncResponse(Task<IResponse<BuildDataContract>> task)
        {
            var response = task.Result;
            var buildDataContract = response.Content;
            if (buildDataContract == null)
            {
                return null;
            }

            return this.converterForBuild.Convert(buildDataContract, response);
        }
    }
}