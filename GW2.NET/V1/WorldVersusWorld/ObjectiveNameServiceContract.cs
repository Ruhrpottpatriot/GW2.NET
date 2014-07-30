// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveNameServiceContracts.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The objective name service contracts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.WorldVersusWorld;

    /// <summary>The objective name service contract.</summary>
    [ContractClassFor(typeof(IObjectiveNameService))]
    internal abstract class ObjectiveNameServiceContract : IObjectiveNameService
    {
        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IDictionary<int, ObjectiveName> GetObjectiveNames()
        {
            Contract.Ensures(Contract.Result<IDictionary<int, ObjectiveName>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IDictionary<int, ObjectiveName> GetObjectiveNames(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<IDictionary<int, ObjectiveName>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}