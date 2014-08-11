// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OfflineServiceManager.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to specialty services that do not require a connection to a remote service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Entities.DynamicEvents;
    using GW2DotNET.Entities.Worlds;
    using GW2DotNET.Local.DynamicEvents;
    using GW2DotNET.Local.Worlds;
    using GW2DotNET.V1.Worlds;

    /// <summary>Provides access to specialty services that do not require a connection to a remote service.</summary>
    public class OfflineServiceManager : IDynamicEventRotationService, IWorldNameService
    {
        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IDynamicEventRotationService dynamicEventRotationService;

        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IWorldNameService worldNameService;

        /// <summary>Initializes a new instance of the <see cref="OfflineServiceManager"/> class.</summary>
        public OfflineServiceManager()
        {
            this.dynamicEventRotationService = new DynamicEventRotationService();
            this.worldNameService = new OfflineWorldService(new JsonSerializerFactory());
        }

        /// <summary>Initializes a new instance of the <see cref="OfflineServiceManager"/> class.</summary>
        /// <param name="dynamicEventRotationService">The dynamic event rotation service.</param>
        /// <param name="worldNameService">The world name service.</param>
        public OfflineServiceManager(IDynamicEventRotationService dynamicEventRotationService, IWorldNameService worldNameService)
        {
            Contract.Requires(dynamicEventRotationService != null);
            Contract.Requires(worldNameService != null);
            this.dynamicEventRotationService = dynamicEventRotationService;
            this.worldNameService = worldNameService;
        }

        /// <summary>Gets a collection of dynamic events and their rotating shifts</summary>
        /// <returns>A collection of dynamic events and their rotating shifts.</returns>
        public IDictionary<Guid, DynamicEventRotation> GetDynamicEventRotations()
        {
            return this.dynamicEventRotationService.GetDynamicEventRotations();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IDictionary<int, World> GetWorldNames()
        {
            return this.worldNameService.GetWorldNames();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IDictionary<int, World> GetWorldNames(CultureInfo language)
        {
            return this.worldNameService.GetWorldNames(language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync()
        {
            return this.worldNameService.GetWorldNamesAsync();
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            return this.worldNameService.GetWorldNamesAsync(cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync(CultureInfo language)
        {
            return this.worldNameService.GetWorldNamesAsync(language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.worldNameService.GetWorldNamesAsync(language, cancellationToken);
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.dynamicEventRotationService != null);
            Contract.Invariant(this.worldNameService != null);
        }
    }
}