// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldNameService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the world names service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Worlds.Names
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Worlds.Names.Contracts;

    /// <summary>Provides the default implementation of the world names service.</summary>
    public class WorldNameService : ServiceBase, IWorldNameService
    {
        /// <summary>Initializes a new instance of the <see cref="WorldNameService" /> class.</summary>
        public WorldNameService()
            : this(new ServiceClient(new Uri(Services.DataServiceUrl)))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WorldNameService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public WorldNameService(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IEnumerable<WorldName> GetWorldNames()
        {
            return this.GetWorldNames(ServiceBase.DefaultLanguage);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IEnumerable<WorldName> GetWorldNames(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new WorldNameServiceRequest { Language = language };
            var result = this.Request<WorldNameCollection>(serviceRequest);

            foreach (var worldName in result)
            {
                // patch missing language information
                worldName.Language = language;
            }

            return result;
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<WorldName>> GetWorldNamesAsync()
        {
            return this.GetWorldNamesAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<WorldName>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            return this.GetWorldNamesAsync(ServiceBase.DefaultLanguage, cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<WorldName>> GetWorldNamesAsync(CultureInfo language)
        {
            return this.GetWorldNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<WorldName>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var worldNamesRequest = new WorldNameServiceRequest { Language = language };
            var t1 = this.RequestAsync<WorldNameCollection>(worldNamesRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        foreach (var worldName in task.Result)
                        {
                            // patch missing language information
                            worldName.Language = language;
                        }

                        return task.Result;
                    }, 
                cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<WorldName>>(task => task.Result, cancellationToken);

            return t2;
        }
    }
}