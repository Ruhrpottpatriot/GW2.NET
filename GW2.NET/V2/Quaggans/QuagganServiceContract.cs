// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The quaggan service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V2.Quaggans
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using GW2DotNET.Quaggans;
    using GW2DotNET.V2.Common;

    /// <summary>The quaggan service contract.</summary>
    [ContractClassFor(typeof(IQuagganService))]
    internal abstract class QuagganServiceContract : IQuagganService
    {
        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A Quaggan</returns>
        public Quaggan GetQuaggan(string identifier)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(identifier));
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggan identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public ICollection<string> GetQuagganIdentifiers()
        {
            Contract.Ensures(Contract.Result<ICollection<string>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans</summary>
        /// <returns>A collection of Quaggans.</returns>
        public Subdictionary<string, Quaggan> GetQuaggans()
        {
            Contract.Ensures(Contract.Result<Subdictionary<string, Quaggan>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Subdictionary<string, Quaggan> GetQuaggans(IEnumerable<string> identifiers)
        {
            Contract.Requires(identifiers != null);
            Contract.Ensures(Contract.Result<Subdictionary<string, Quaggan>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of Quaggans.</returns>
        public PaginatedCollection<Quaggan> GetQuaggans(int page)
        {
            Contract.Ensures(Contract.Result<PaginatedCollection<Quaggan>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of Quaggans.</returns>
        public PaginatedCollection<Quaggan> GetQuaggans(int page, int size)
        {
            Contract.Ensures(Contract.Result<PaginatedCollection<Quaggan>>() != null);
            throw new System.NotImplementedException();
        }
    }
}