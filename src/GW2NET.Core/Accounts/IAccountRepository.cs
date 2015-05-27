// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAccountRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for repositories that provide player data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Accounts
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for repositories that provide player data.</summary>
    public interface IAccountRepository
    {
        /// <summary>Gets the information about an account.</summary>
        /// <returns>The <see cref="Account"/> for a given api key.</returns>
        Account GetInformation();

        /// <summary>Asynchronously gets the information about an account.</summary>
        /// <returns>The <see cref="Account"/> for a given api key.</returns>
        Task<Account> GetInformationAsync();

        /// <summary>Asynchronously gets the information about an account.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Account"/> for a given api key.</returns>
        Task<Account> GetInformationAsync(CancellationToken cancellationToken);
    }
}
