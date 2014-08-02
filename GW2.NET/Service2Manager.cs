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
    using System.Diagnostics.Contracts;
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
        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IBuildService buildService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IQuagganService quagganService;

        /// <summary>Initializes a new instance of the <see cref="Service2Manager"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public Service2Manager(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.quagganService = new QuagganService(serviceClient);
            this.buildService = new BuildService(serviceClient);
        }

        /// <summary>Initializes a new instance of the <see cref="Service2Manager"/> class.</summary>
        /// <param name="buildService">The build service.</param>
        /// <param name="quagganService">The quaggan service.</param>
        public Service2Manager(IBuildService buildService, IQuagganService quagganService)
        {
            Contract.Requires(buildService != null);
            Contract.Requires(quagganService != null);
            this.buildService = buildService;
            this.quagganService = quagganService;
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
            return this.buildService.GetBuild();
        }

        /// <summary>Gets the current build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync()
        {
            return this.buildService.GetBuildAsync(CancellationToken.None);
        }

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync(CancellationToken cancellationToken)
        {
            return this.buildService.GetBuildAsync(cancellationToken);
        }

        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A Quaggan</returns>
        public Quaggan GetQuaggan(string identifier)
        {
            return this.quagganService.GetQuaggan(identifier);
        }

        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A Quaggan</returns>
        public Task<Quaggan> GetQuagganAsync(string identifier)
        {
            return this.quagganService.GetQuagganAsync(identifier, CancellationToken.None);
        }

        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A Quaggan</returns>
        public Task<Quaggan> GetQuagganAsync(string identifier, CancellationToken cancellationToken)
        {
            return this.quagganService.GetQuagganAsync(identifier, cancellationToken);
        }

        /// <summary>Gets a collection of Quaggan identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public ICollection<string> GetQuagganIdentifiers()
        {
            return this.quagganService.GetQuagganIdentifiers();
        }

        /// <summary>Gets a collection of Quaggan identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<string>> GetQuagganIdentifiersAsync()
        {
            return this.quagganService.GetQuagganIdentifiersAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of Quaggan identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<string>> GetQuagganIdentifiersAsync(CancellationToken cancellationToken)
        {
            return this.quagganService.GetQuagganIdentifiersAsync(cancellationToken);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <returns>A collection of Quaggans.</returns>
        public Subdictionary<string, Quaggan> GetQuaggans()
        {
            return this.quagganService.GetQuaggans();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Subdictionary<string, Quaggan> GetQuaggans(IEnumerable<string> identifiers)
        {
            return this.quagganService.GetQuaggans(identifiers);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of Quaggans.</returns>
        public PaginatedCollection<Quaggan> GetQuaggans(int page)
        {
            return this.quagganService.GetQuaggans(page);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of Quaggans.</returns>
        public PaginatedCollection<Quaggan> GetQuaggans(int page, int size)
        {
            return this.quagganService.GetQuaggans(page, size);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <returns>A collection of Quaggans.</returns>
        public Task<Subdictionary<string, Quaggan>> GetQuaggansAsync()
        {
            return this.quagganService.GetQuaggansAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<Subdictionary<string, Quaggan>> GetQuaggansAsync(CancellationToken cancellationToken)
        {
            return this.quagganService.GetQuaggansAsync(cancellationToken);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<Subdictionary<string, Quaggan>> GetQuaggansAsync(IEnumerable<string> identifiers)
        {
            return this.quagganService.GetQuaggansAsync(identifiers, CancellationToken.None);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<Subdictionary<string, Quaggan>> GetQuaggansAsync(IEnumerable<string> identifiers, CancellationToken cancellationToken)
        {
            return this.quagganService.GetQuaggansAsync(identifiers, cancellationToken);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page)
        {
            return this.quagganService.GetQuaggansAsync(page, CancellationToken.None);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page, CancellationToken cancellationToken)
        {
            return this.quagganService.GetQuaggansAsync(page, cancellationToken);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page, int size)
        {
            return this.quagganService.GetQuaggansAsync(page, size, CancellationToken.None);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page, int size, CancellationToken cancellationToken)
        {
            return this.quagganService.GetQuaggansAsync(page, size, cancellationToken);
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.buildService != null);
            Contract.Invariant(this.quagganService != null);
        }
    }
}