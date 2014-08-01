// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuagganService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the Quaggan service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Quaggans
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using GW2DotNET.Quaggans;
    using GW2DotNET.V2.Common;

    /// <summary>Provides the interface for the Quaggan service.</summary>
    [ContractClass(typeof(QuagganServiceContract))]
    public interface IQuagganService
    {
        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A Quaggan</returns>
        Quaggan GetQuaggan(string identifier);

        /// <summary>Gets a collection of Quaggan identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        ICollection<string> GetQuagganIdentifiers();

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <returns>A collection of Quaggans.</returns>
        Subdictionary<string, Quaggan> GetQuaggans();

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of Quaggans.</returns>
        Subdictionary<string, Quaggan> GetQuaggans(IEnumerable<string> identifiers);

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of Quaggans.</returns>
        PaginatedCollection<Quaggan> GetQuaggans(int page);

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of Quaggans.</returns>
        PaginatedCollection<Quaggan> GetQuaggans(int page, int size);
    }
}