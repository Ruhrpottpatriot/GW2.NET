// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameEvent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GameEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Events.Models
{
    /// <summary>
    /// Represents an event in the game.
    /// </summary>
    [Obsolete("This model is obsolete, use the GameEvent model in the DynamicEvents namespace instead.", false)]
    public class GwEvent : IEquatable<GwEvent>
    {
        private readonly Guid eventId;

        /// <summary>Initializes a new instance of the <see cref="GwEvent"/> class.</summary>
        /// <param name="worldIdId">The world id.</param>
        /// <param name="mapIdId">The map id.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="state">The state.</param>
        [JsonConstructor]
        public GwEvent(int worldIdId, int mapIdId, Guid eventId, GwEventState state)
        {
            this.WorldId = worldIdId;
            this.MapId = mapIdId;
            this.eventId = eventId;
            this.State = state;

        }

        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets the world
        /// </summary>
        [JsonProperty("world_id")]
        public int WorldId { get; private set; }

        /// <summary>
        /// Gets the map
        /// </summary>
        [JsonProperty("map_id")]
        public int MapId { get; private set; }

        /// <summary>
        /// Gets the event id.
        /// </summary>
        [JsonProperty("event_id")]
        public Guid EventId
        {
            get { return this.eventId; }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        [JsonProperty("state")]
        public GwEventState State { get; private set; }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="Map"/> are equal.
        /// </summary>
        /// <param name="eventA">The first object to compare.</param>param>
        /// <param name="eventB">The second object to compare. </param>
        /// <returns>true if mapA and mapB represent the same map; otherwise, false.</returns>
        public static bool operator ==(GwEvent eventA, GwEvent eventB)
        {
            if (ReferenceEquals(eventA, eventB))
            {
                return true;
            }

            if (((object)eventA == null) || ((object)eventB == null))
            {
                return false;
            }

            return eventA.eventId == eventB.eventId;
        }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="Map"/> are not equal.
        /// </summary>
        /// <param name="a">The first object to compare.</param>param>
        /// <param name="b">The second object to compare. </param>
        /// <returns>true if mapA and mapB do not represent the same map; otherwise, false.</returns>
        public static bool operator !=(GwEvent a, GwEvent b)
        {
            return !(a == b);
        }
        
        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="obj">Another object to compare to.</param>
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            var gwEvent = obj as GwEvent;

            if ((object)gwEvent == null)
            {
                return false;
            }

            return gwEvent.EventId == this.eventId;
        }

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="MapId"/> are equal.
        /// </summary>
        /// <returns>true if <paramref name="other"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="other">Another object to compare to. </param>
        public bool Equals(GwEvent other)
        {
            if ((object)other == null)
            {
                return false;
            }

            return this.eventId == other.EventId;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return this.eventId.GetHashCode();
        }
    }
}
