// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiscoverableCodeContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The code contract class for <see cref="IDiscoverable{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>The code contract class for <see cref="IDiscoverable{T}"/>.</summary>
    /// <typeparam name="T">The type of the identifiers.</typeparam>
    [ContractClassFor(typeof(IDiscoverable<>))]
    internal abstract class DiscoverableCodeContract<T> : IDiscoverable<T>
    {
        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public ICollection<T> Discover()
        {
            Contract.Ensures(Contract.Result<ICollection<T>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<T>> DiscoverAsync()
        {
            Contract.Ensures(Contract.Result<Task<ICollection<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollection<T>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<T>> DiscoverAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<ICollection<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollection<T>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}