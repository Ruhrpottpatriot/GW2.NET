// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDynamicEventRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for dynamic event requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common
{
    using System;

    using GW2DotNET.Common;

    /// <summary>Provides the interface for dynamic event requests.</summary>
    public interface IDynamicEventRequest : IRequest
    {
        /// <summary>Gets or sets the event identifier.</summary>
        Guid? EventId { get; set; }

        /// <summary>Gets or sets the map identifier.</summary>
        int? MapId { get; set; }

        /// <summary>Gets or sets the world identifier.</summary>
        int? WorldId { get; set; }
    }
}