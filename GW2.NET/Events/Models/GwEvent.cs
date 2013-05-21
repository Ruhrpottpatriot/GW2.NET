// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwEvent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GwEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Events.Models
{
    /// <summary>
    /// Represents an event in the game.
    /// </summary>
    public struct GwEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GwEvent"/> struct.
        /// </summary>
        /// <param name="worldId">The world id.</param>
        /// <param name="mapId">The map id.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="state">The state.</param>
        /// <param name="name">The name.</param>
        public GwEvent(int worldId, int mapId, string eventId, string state, string name) : this()
        {
            this.WorldId = worldId;
            this.MapId = mapId;
            this.EventId = eventId;
            this.State = state;
            this.Name = name;
        }

        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the world id.
        /// </summary>
        public int WorldId { get; private set; }

        /// <summary>
        /// Gets the map id.
        /// </summary>
        public int MapId { get; private set; }

        /// <summary>
        /// Gets the event id.
        /// </summary>
        public string EventId { get; private set; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        public string State { get; private set; }
    }
}
