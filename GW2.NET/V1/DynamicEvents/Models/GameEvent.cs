// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameEvent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GameEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using GW2DotNET.V1.Maps.Models;

using Newtonsoft.Json;

namespace GW2DotNET.V1.World.Models
{
    /// <summary>
    /// Represents an event in the game.
    /// </summary>
    public class GameEvent : IEquatable<GameEvent>
    {
        /// <summary>
        /// The map id backing field
        /// </summary>
        [JsonProperty("map_id")]
        private readonly int mapId;

        /// <summary>
        /// The event id backing field
        /// </summary>
        private readonly Guid eventId;

        /// <summary>
        /// The world id backing field
        /// </summary>
        [JsonProperty("world_id")]
        private readonly int worldId;
        
        /// <summary>
        /// The event state backing field
        /// </summary>
        private readonly GwEventState state;

        /// <summary>Initializes a new instance of the <see cref="GameEvent"/> class.</summary>
        /// <param name="worldId">The world id.</param>
        /// <param name="mapId">The map id.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="state">The state.</param>
        /// <param name="apiManager">The api Manager.</param>
        [JsonConstructor]
        public GameEvent(int worldId, int mapId, Guid eventId, GwEventState state, ApiManager apiManager)
        {
            this.worldId = worldId;
            this.mapId = mapId;
            this.eventId = eventId;
            this.state = state;
            this.ApiManager = apiManager;
        }

        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return this.ApiManager.Events.EventNames[this.EventId];
            }
        }

        /// <summary>
        /// Gets the world
        /// </summary>
        public GwWorld World
        {
            get
            {
                return this.ApiManager.Worlds[this.worldId];
            }
        }

        /// <summary>
        /// Gets the map
        /// </summary>
        public Map Map
        {
            get
            {
                return this.ApiManager.Maps[this.mapId];
            }
        }

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
        public GwEventState State
        {
            get { return this.state; }
        }

        /// <summary>Gets or sets the api manager.</summary>
        /// ToDo: Remove
        internal ApiManager ApiManager
        {
            get;
            set;
        }
        
        /// <summary>
        /// Determines whether two specified instances of <see crdef="Map"/> are equal.
        /// </summary>
        /// <param name="eventA">The first object to compare.</param>param>
        /// <param name="eventB">The second object to compare. </param>
        /// <returns>true if mapA and mapB represent the same map; otherwise, false.</returns>
        public static bool operator ==(GameEvent eventA, GameEvent eventB)
        {
            if (ReferenceEquals(eventA, eventB))
            {
                return true;
            }

            if (((object)eventA == null) || ((object)eventB == null))
            {
                return false;
            }

            return eventA.EventId == eventB.EventId;
        }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="Map"/> are not equal.
        /// </summary>
        /// <param name="a">The first object to compare.</param>param>
        /// <param name="b">The second object to compare. </param>
        /// <returns>true if mapA and mapB do not represent the same map; otherwise, false.</returns>
        public static bool operator !=(GameEvent a, GameEvent b)
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
            var gwEvent = obj as GameEvent;

            if ((object)gwEvent == null)
            {
                return false;
            }

            return gwEvent.EventId == this.EventId;
        }

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="Map"/> are equal.
        /// </summary>
        /// <returns>true if <paramref name="other"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="other">Another object to compare to. </param>
        public bool Equals(GameEvent other)
        {
            if ((object)other == null)
            {
                return false;
            }

            return this.EventId == other.EventId;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return this.EventId.GetHashCode();
        }
    }
}
