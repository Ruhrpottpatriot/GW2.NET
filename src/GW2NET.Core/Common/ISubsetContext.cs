// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISubsetContext.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides contextual information for collections that are a subset of a larger collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>Provides contextual information for collections that are a subset of a larger collection.</summary>
    [ContractClass(typeof(ContractClassForISubsetContext))]
    public interface ISubsetContext
    {
        /// <summary>Gets or sets the number of values in this subset.</summary>
        /// <exception cref="ArgumentOutOfRangeException">The given value is negative.</exception>
        int SubtotalCount { get; set; }

        /// <summary>Gets or sets the number of values in the collection.</summary>
        /// <exception cref="ArgumentOutOfRangeException">The given value is negative.</exception>
        int TotalCount { get; set; }
    }
}