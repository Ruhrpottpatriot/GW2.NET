// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBulkRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for bulk resource details requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System.Collections.Generic;

    /// <summary>Provides the interface for bulk resource details requests.</summary>
    public interface IBulkRequest : IRequest
    {
        /// <summary>Gets or sets the collection of resource identifiers.</summary>
        ICollection<string> Identifiers { get; set; }
    }
}
