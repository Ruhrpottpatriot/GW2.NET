// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The file service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Files
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Files;

    /// <summary>The file service contract.</summary>
    [ContractClassFor(typeof(IFileService))]
    internal abstract class FileServiceContract : IFileService
    {
        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public IDictionary<string, Asset> GetFiles()
        {
            Contract.Ensures(Contract.Result<IDictionary<string, Asset>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public Task<IDictionary<string, Asset>> GetFilesAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<string, Asset>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<string, Asset>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public Task<IDictionary<string, Asset>> GetFilesAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<string, Asset>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<string, Asset>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}