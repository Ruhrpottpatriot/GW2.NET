// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubsetContextContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The code contract class for <see cref="ISubsetContext" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Diagnostics.Contracts;

    /// <summary>The code contract class for <see cref="ISubsetContext"/>.</summary>
    [ContractClassFor(typeof(ISubsetContext))]
    internal abstract class SubsetContextContract : ISubsetContext
    {
        /// <summary>Gets or sets the number of values in this subset.</summary>
        public int SubtotalCount { get; set; }

        /// <summary>Gets or sets the number of values in the collection.</summary>
        public int TotalCount { get; set; }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.SubtotalCount >= 0);
            Contract.Invariant(this.TotalCount >= 0);
        }
    }
}