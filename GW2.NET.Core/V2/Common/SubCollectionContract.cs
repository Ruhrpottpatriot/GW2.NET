// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubCollectionContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The sub collection contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V2.Common
{
    using System.Diagnostics.Contracts;

    /// <summary>The sub collection contract.</summary>
    [ContractClassFor(typeof(ISubcollection))]
    internal abstract class SubCollectionContract : ISubcollection
    {
        /// <summary>Gets or sets the number of values in this subset.</summary>
        public int PageCount { get; set; }

        /// <summary>Gets or sets the number of values in the collection.</summary>
        public int TotalCount { get; set; }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.PageCount >= 0);
            Contract.Invariant(this.TotalCount >= 0);
        }
    }
}