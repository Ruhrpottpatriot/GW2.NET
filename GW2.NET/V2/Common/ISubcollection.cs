// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISubcollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for collections that are a subset of a larger collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    /// <summary>Provides the interface for collections that are a subset of a larger collection.</summary>
    public interface ISubcollection
    {
        /// <summary>Gets or sets the number of values in this subset.</summary>
        int PageCount { get; set; }

        /// <summary>Gets or sets the number of values in the collection.</summary>
        int TotalCount { get; set; }
    }
}