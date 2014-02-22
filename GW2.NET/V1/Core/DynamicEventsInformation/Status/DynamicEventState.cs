// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventState.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Status
{
    /// <summary>
    /// Enumerates the possible states of a dynamic event.
    /// </summary>
    public enum DynamicEventState
    {
        /// <summary>The event is not running.</summary>
        Inactive = 1 << 0,

        /// <summary>The event is running now. </summary>
        Active = 1 << 1,

        /// <summary>The event has succeeded. </summary>
        Success = 1 << 2,

        /// <summary>The event has failed. </summary>
        Fail = 1 << 3,

        /// <summary>The event is inactive and waiting for certain criteria to be met before  becoming Active.</summary>
        Warmup = 1 << 4,

        /// <summary>The criteria for the event to start have been met, but certain activities (such as an NPC dialogue) have not completed yet. After the activities have been completed, the event will become Active.</summary>
        Preparation = 1 << 5
    }
}