// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBulkServiceRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for bulk service requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using System.Collections.Generic;

    /// <summary>Provides the interface for bulk service requests.</summary>
    public interface IBulkServiceRequest : IServiceRequest
    {
        /// <summary>Gets the collection of resource identifiers.</summary>
        ICollection<int> Identifiers { get; }
    }
}