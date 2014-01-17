// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEvent.EventState.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace GW2DotNET.V1.Core.Events
{
    /// <summary>
    /// Represents a dynamic event and its status.
    /// </summary>
    public partial class DynamicEvent
    {
        /// <summary>
        /// Enumerates the possible states of a dynamic event.
        /// </summary>
        public enum EventState
        {
            /// <summary>The event is not running.</summary>
            Inactive,

            /// <summary>The event is running now. </summary>
            Active,

            /// <summary>The event has succeeded. </summary>
            Success,

            /// <summary>The event has failed. </summary>
            Fail,

            /// <summary>The event is inactive and waiting for certain criteria to be met before  becoming Active.</summary>
            Warmup,

            /// <summary>The criteria for the event to start have been met, but certain activities (such as an NPC dialogue) have not completed yet. After the activities have been completed, the event will become Active.</summary>
            Preparation
        }
    }
}
