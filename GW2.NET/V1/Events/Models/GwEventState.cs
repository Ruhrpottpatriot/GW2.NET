// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwEventState.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the EventState type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Events.Models
{
    /// <summary>
    /// Enumerates all possible states an event can be.
    /// </summary>
    public enum GwEventState
    {
        /// <summary>
        ///  The event is running now.
        /// </summary>
        Active,

        /// <summary>
        /// The event has succeeded.
        /// </summary>
        Success,

        /// <summary>
        /// The event has failed.
        /// </summary>
        Fail,

        /// <summary>
        /// The event is inactive, 
        /// and will only become active once certain criteria are met.
        /// </summary>
        Warmup,

        /// <summary>
        /// The criteria for the event to start have been met, 
        /// but certain activities (such as an NPC dialogue) have not completed yet. 
        /// After the activities have been completed, the event will become Active.
        /// </summary>
        Preparation,

        /// <summary>
        /// The event is invalid. 
        /// For now no further information were released by Arena Net
        /// </summary>
        Invalid,

        /// <summary>
        /// The event is not running now.
        /// </summary>
        Inactive
    }
}