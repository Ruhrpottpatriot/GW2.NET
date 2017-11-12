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

    /// <summary>Provides contextual information for collections that are a subset of a larger collection.</summary>
    public interface ISubsetContext
    {
        /// <summary>Gets or sets the number of values in this subset.</summary>
        /// <exception cref="ArgumentOutOfRangeException">The value is less than 0.</exception>
        int SubtotalCount { get; set; }

        /// <summary>Gets or sets the number of values in the collection.</summary>
        /// <exception cref="ArgumentOutOfRangeException">The value is less than 0.</exception>
        int TotalCount { get; set; }
    }
}