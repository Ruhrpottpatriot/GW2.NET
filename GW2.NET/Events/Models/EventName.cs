// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventName.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   An item returned by a call to event_names.JSON
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace GW2DotNET.Events.Models
{
    /// <summary>
    /// An item returned by a call to event_names.JSON
    /// </summary>
    public struct EventName
    {
        /// <summary>
        /// Gets or sets the event ID
        /// </summary>
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event name
        /// </summary>
        public string Name
        {
            get;
            set;
        }
    }
}
