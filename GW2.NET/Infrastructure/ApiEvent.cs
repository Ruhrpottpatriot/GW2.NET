// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiEvent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   An item returned by a call to events.JSON
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace GW2DotNET.Infrastructure
{
    /// <summary>
    /// An item returned by a call to events.JSON
    /// </summary>
    public class ApiEvent
    {
        /// <summary>
        /// Gets or sets the world ID
        /// </summary>
        public int WorldId { get; set; }

        /// <summary>
        /// Gets or sets the map ID
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// Gets or sets the event ID
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// Gets or sets the event state
        /// </summary>
        public Events.Models.GwEventState State { get; set; }
    }
}