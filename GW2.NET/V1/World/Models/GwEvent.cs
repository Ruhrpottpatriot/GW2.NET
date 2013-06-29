// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwEvent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GwEvent type.
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
    public struct GwEvent
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

        /// <summary>
        /// The event name backing field
        /// </summary>
        private string name;

        /// <summary>
        /// The world backing field
        /// </summary>
        private GwWorld? world;

        /// <summary>
        /// The map backing field
        /// </summary>
        private Map? map;

        /// <summary>
        /// Initializes a new instance of the <see cref="GwEvent"/> struct.
        /// </summary>
        /// <param name="worldId">The world id.</param>
        /// <param name="mapId">The map id.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="state">The state.</param>
        /// <param name="name">The name.</param>
        [JsonConstructor]
        public GwEvent(int worldId, int mapId, Guid eventId, GwEventState state, string name)
        {
            this.worldId = worldId;
            this.mapId = mapId;
            this.eventId = eventId;
            this.state = state;
            this.name = name;

            // Because this is a struct, we have to assign dummy values
            this.world = null;
            this.map = null;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GwEvent"/> struct.
        /// This is the construction that should be used when we've
        /// resolved the IDs.
        /// </summary>
        /// <param name="worldId">The world id.</param>
        /// <param name="mapId">The map id.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="state">The state.</param>
        /// <param name="name">The name.</param>
        /// <param name="world">The GwWorld object.</param>
        /// <param name="map">The GwMap object.</param>
        public GwEvent(int worldId, int mapId, Guid eventId, GwEventState state, string name, GwWorld world, Map map)
        {
            this.worldId = worldId;
            this.mapId = mapId;
            this.eventId = eventId;
            this.state = state;
            this.name = name;
            this.world = world;
            this.map = map;
        }

        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets the world
        /// </summary>
        public GwWorld? World
        {
            get
            {
                return this.world;
            }

            private set
            {
                this.world = value;
            }
        }

        /// <summary>
        /// Gets the map
        /// </summary>
        public Map? Map
        {
            get
            {
                return this.map;
            }

            private set
            {
                this.map = value;
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
        
        /// <summary>
        /// Determines whether two specified instances of <see crdef="Map"/> are equal.
        /// </summary>
        /// <param name="a">The first object to compare.</param>param>
        /// <param name="b">The second object to compare. </param>
        /// <returns>true if mapA and mapB represent the same map; otherwise, false.</returns>
        public static bool operator ==(GwEvent a, GwEvent b)
        {
            return a.EventId == b.EventId;
        }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="Map"/> are not equal.
        /// </summary>
        /// <param name="a">The first object to compare.</param>param>
        /// <param name="b">The second object to compare. </param>
        /// <returns>true if mapA and mapB do not represent the same map; otherwise, false.</returns>
        public static bool operator !=(GwEvent a, GwEvent b)
        {
            return a.EventId != b.EventId;
        }
        
        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="obj">Another object to compare to.</param>
        public override bool Equals(object obj)
        {
            return obj is GwEvent && this == (GwEvent)obj;
        }

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="Map"/> are equal.
        /// </summary>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="obj">Another object to compare to. </param>
        public bool Equals(GwEvent obj)
        {
            return this.EventId == obj.EventId;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return this.EventId.GetHashCode();
        }

        /// <summary>
        /// Resolves the name of an event.
        /// </summary>
        /// <param name="apiManager">The GW2ApiManager</param>
        /// <returns>The <see cref="GwEvent"/> with the resolved names.</returns>
        internal GwEvent ResolveIDs(ApiManager apiManager)
        {
            this.Map = apiManager.Maps[this.mapId];
            this.World = apiManager.Worlds[this.worldId];
            this.Name = apiManager.Events.EventNames[this.EventId];

            return this;
        }
    }
}
