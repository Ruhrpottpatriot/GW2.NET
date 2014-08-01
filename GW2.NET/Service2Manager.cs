// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Service2Manager.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the Guild Wars 2 service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Builds;
    using GW2DotNET.Common;
    using GW2DotNET.Quaggans;
    using GW2DotNET.V2.Builds;
    using GW2DotNET.V2.Common;
    using GW2DotNET.V2.Quaggans;

    /// <summary>Provides access to the Guild Wars 2 service.</summary>
    public class Service2Manager : IBuildService, IQuagganService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="Service2Manager"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public Service2Manager(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Initializes a new instance of the <see cref="Service2Manager"/> class.</summary>
        public Service2Manager()
            : this(new ServiceClient(new Uri("https://api.guildwars2.com")))
        {
        }

        /// <summary>Gets the current game build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Build GetBuild()
        {
            return new BuildService(this.serviceClient).GetBuild();
        }

        /// <summary>Gets the current build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync()
        {
            return new BuildService(this.serviceClient).GetBuildAsync(CancellationToken.None);
        }

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync(CancellationToken cancellationToken)
        {
            return new BuildService(this.serviceClient).GetBuildAsync(cancellationToken);
        }

        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A Quaggan</returns>
        public Quaggan GetQuaggan(string identifier)
        {
            return new QuagganService(this.serviceClient).GetQuaggan(identifier);
        }

        /// <summary>Gets a collection of Quaggan identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public ICollection<string> GetQuagganIdentifiers()
        {
            return new QuagganService(this.serviceClient).GetQuagganIdentifiers();
        }

        /// <summary>Gets a collection of Quaggans</summary>
        /// <returns>A collection of Quaggans.</returns>
        public Subdictionary<string, Quaggan> GetQuaggans()
        {
            return new QuagganService(this.serviceClient).GetQuaggans();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Subdictionary<string, Quaggan> GetQuaggans(IEnumerable<string> identifiers)
        {
            return new QuagganService(this.serviceClient).GetQuaggans(identifiers);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of Quaggans.</returns>
        public PaginatedCollection<Quaggan> GetQuaggans(int page)
        {
            return new QuagganService(this.serviceClient).GetQuaggans(page);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of Quaggans.</returns>
        public PaginatedCollection<Quaggan> GetQuaggans(int page, int size)
        {
            return new QuagganService(this.serviceClient).GetQuaggans(page, size);
        }
    }
}