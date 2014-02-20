// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameEvent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GameEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.DynamicEvents.Models
{
    /// <summary>Represents a game in Guild Wars 2.</summary>
    public class GameEvent : IEquatable<GameEvent>
    {
        /// <summary>Enumerates the possible event flags.</summary>
        [Flags]
        [JsonConverter(typeof(StringEnumConverter))]
        public enum GameEventFlags
        {
            /// <summary>The event is a group event.</summary>
            [EnumMember(Value = "group_event")]
            GroupEvent = 0x01, 

            /// <summary>The event is map wide.</summary>
            [EnumMember(Value = "map_wide")]
            MapWide = 0x02, 
        }

        /// <summary>The event id. This field is read only.</summary>
        private readonly Guid eventId;

        /// <summary>The map id.</summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here." + "JSON.NET will not deserialize the JSON if there is not at least a field present." + "Aa we don't want the user to see the map id outside the nested class this has to be done.")]
        [JsonProperty("map_id")]
        private readonly int mapId;

        /// <summary>The world id.</summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here. " + "JSON.NET will not deserialize th JSON if there is not at least a field present." + "Aa we don't want the user to see the map id outside the nested class this has to be done.")]
        [JsonProperty("world_id")]
        // ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
        private readonly int worldId;

        // ReSharper restore PrivateFieldCanBeConvertedToLocalVariable

        /// <summary>Initializes a new instance of the <see cref="GameEvent"/> class.</summary>
        /// <param name="worldId">The world.</param>
        /// <param name="mapId">The map.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="state">The event state.</param>
        [JsonConstructor]
        public GameEvent(int worldId, int mapId, Guid eventId, GameEventState state)
        {
            this.worldId = worldId;
            this.World = new GameEventWorld(this.worldId);

            this.mapId = mapId;
            this.Map = new GameEventMap(this.mapId);

            this.eventId = eventId;
            this.State = state;
        }

        /// <summary>Gets or sets the event name.</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>Gets or sets the event flags.</summary>
        [JsonProperty("flags")]
        public IEnumerable<GameEventFlags> Flags { get; set; }

        /// <summary>Gets or sets the level requirement for the event.</summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>Gets or sets the location the event takes place.</summary>
        [JsonProperty("location")]
        public GameEventLocation Location { get; set; }

        /// <summary>Gets or sets the world the event takes place.</summary>
        public GameEventWorld World { get; set; }

        /// <summary>Gets or sets the map the event takes place..</summary>
        public GameEventMap Map { get; set; }

        /// <summary>Gets the event id.</summary>
        [JsonProperty("event_id")]
        public Guid EventId
        {
            get
            {
                return this.eventId;
            }
        }

        /// <summary>Gets or sets the event state.</summary>
        [JsonProperty("state")]
        public GameEventState State { get; set; }

        /// <summary>Indicates whether this instance and a specified <see cref="GameEvent"/> are equal.</summary>
        /// <returns>true if <paramref name="other"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="other">Another object to compare to. </param>
        public bool Equals(GameEvent other)
        {
            if ((object)other == null)
            {
                return false;
            }

            return this.eventId == other.EventId;
        }

        /// <summary>Determines whether two specified instances of <see cref="GameEvent" /> are equal.</summary>
        /// <param name="eventA">The first object to compare.</param>
        /// param>
        /// <param name="eventB">The second object to compare. </param>
        /// <returns>true if eventA and eventB represent the same event; otherwise, false.</returns>
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

            return eventA.eventId == eventB.eventId;
        }

        /// <summary>Determines whether two specified instances of <see cref="GameEvent" /> are not equal.</summary>
        /// <param name="a">The first object to compare.</param>
        /// param>
        /// <param name="b">The second object to compare. </param>
        /// <returns>true if eventA and eventB do not represent the same event; otherwise, false.</returns>
        public static bool operator !=(GameEvent a, GameEvent b)
        {
            return !(a == b);
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
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
            var gameEvent = obj as GameEvent;

            if ((object)gameEvent == null)
            {
                return false;
            }

            return gameEvent.EventId == this.eventId;
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return this.eventId.GetHashCode();
        }

        /// <summary>Represents a location the event takes place.</summary>
        public class GameEventLocation
        {
            /// <summary>The location type.</summary>
            public enum LocationType
            {
                /// <summary>The event is a sphere.</summary>
                Sphere = 0x01, 

                /// <summary>The event is a cylinder.</summary>
                Cylinder = 0x02, 

                /// <summary>The event is a poly.</summary>
                Poly = 0x04
            }

            /// <summary>Gets or sets the type of the location.</summary>
            [JsonProperty("type")]
            public LocationType Type { get; set; }

            /// <summary>Gets or sets the coordinates of the event center.</summary>
            [JsonProperty("center")]
            public decimal[] Center { get; set; }

            /// <summary>Gets or sets the height the event reaches. This integer can be null.</summary>
            /// <remarks>This integer represents how high an event goes. If the integer is null then the event area is flat.</remarks>
            [JsonProperty("height")]
            public int? Height { get; set; }

            /// <summary>Gets or sets the radius of the event. This integer can be null.</summary>
            /// <remarks>This integer represents the radius of an event. If it is null it means that the event is not circular, but poly.</remarks>
            [JsonProperty("radius")]
            public int? Radius { get; set; }

            /// <summary>Gets or sets the rotation of the event. This integer can be null.</summary>
            [JsonProperty("rotation")]
            public int? Rotation { get; set; }

            /// <summary>Gets or sets the z range of the event..</summary>
            [JsonProperty("z_range")]
            public decimal[] ZRange { get; set; }

            /// <summary>Gets or sets the outlying points of the events.</summary>
            public decimal[][] Points { get; set; }
        }

        /// <summary>Represents a map in the game.</summary>
        public class GameEventMap
        {
            /// <summary>The id of the map.</summary>
            private readonly int id;

            /// <summary>Initializes a new instance of the <see cref="GameEventMap"/> class.</summary>
            /// <param name="id">The id.</param>
            public GameEventMap(int id)
            {
                this.id = id;
            }

            /// <summary>Initializes a new instance of the <see cref="GameEventMap"/> class.</summary>
            /// <param name="id">The id.</param>
            /// <param name="name">The name.</param>
            public GameEventMap(int id, string name)
                : this(id)
            {
                this.Name = name;
            }

            /// <summary>Gets the id of the map.</summary>
            public int Id
            {
                get
                {
                    return this.id;
                }
            }

            /// <summary>Gets or sets the name of the map.</summary>
            public string Name { get; set; }

            /// <summary>Determines whether two specified instances of <see cref="GameEventMap" /> are equal.</summary>
            /// <param name="mapA">The first object to compare.</param>
            /// param>
            /// <param name="mapB">The second object to compare. </param>
            /// <returns>true if mapA and mapB represent the same map; otherwise, false.</returns>
            public static bool operator ==(GameEventMap mapA, GameEventMap mapB)
            {
                if (ReferenceEquals(mapA, mapB))
                {
                    return true;
                }

                if (((object)mapA == null) || ((object)mapB == null))
                {
                    return false;
                }

                return mapA.Id == mapB.Id;
            }

            /// <summary>Determines whether two specified instances of <see cref="GameEvent" /> are not equal.</summary>
            /// <param name="mapA">The first object to compare.</param>
            /// param>
            /// <param name="mapB">The second object to compare. </param>
            /// <returns>true if mapA and mapB do not represent the same event; otherwise, false.</returns>
            public static bool operator !=(GameEventMap mapA, GameEventMap mapB)
            {
                return !(mapA == mapB);
            }

            /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
            /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
            /// <param name="other">An object to compare with this object.</param>
            public bool Equals(GameEventWorld other)
            {
                if ((object)other == null)
                {
                    return false;
                }

                return this.Id == other.Id;
            }

            /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.</summary>
            /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
            /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
            public override bool Equals(object obj)
            {
                // If parameter is null return false.
                if (obj == null)
                {
                    return false;
                }

                // If parameter cannot be cast to Point return false.
                var gameEventWorld = obj as GameEventWorld;

                if ((object)gameEventWorld == null)
                {
                    return false;
                }

                return gameEventWorld.Id == this.Id;
            }

            /// <summary>Serves as a hash function for a particular type.</summary>
            /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
            public override int GetHashCode()
            {
                return this.Id.GetHashCode();
            }
        }

        /// <summary>Represents a world in the game.</summary>
        public class GameEventWorld : IEquatable<GameEventWorld>
        {
            /// <summary>The id of the world.</summary>
            private readonly int id;

            /// <summary>Initializes a new instance of the <see cref="GameEventWorld"/> class.</summary>
            /// <param name="id">The id.</param>
            public GameEventWorld(int id)
            {
                this.id = id;
            }

            /// <summary>Initializes a new instance of the <see cref="GameEventWorld"/> class.</summary>
            /// <param name="id">The id.</param>
            /// <param name="name">The name.</param>
            public GameEventWorld(int id, string name)
                : this(id)
            {
                this.Name = name;
            }

            /// <summary>Gets the id of the world.</summary>
            public int Id
            {
                get
                {
                    return this.id;
                }
            }

            /// <summary>Gets or sets the name of the world.</summary>
            public string Name { get; set; }

            /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
            /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
            /// <param name="other">An object to compare with this object.</param>
            public bool Equals(GameEventWorld other)
            {
                if ((object)other == null)
                {
                    return false;
                }

                return this.Id == other.Id;
            }

            /// <summary>Determines whether two specified instances of <see cref="GameEventWorld" /> are equal.</summary>
            /// <param name="worldA">The first object to compare.</param>
            /// param>
            /// <param name="worldB">The second object to compare. </param>
            /// <returns>true if mapA and mapB represent the same map; otherwise, false.</returns>
            public static bool operator ==(GameEventWorld worldA, GameEventWorld worldB)
            {
                if (ReferenceEquals(worldA, worldB))
                {
                    return true;
                }

                if (((object)worldA == null) || ((object)worldB == null))
                {
                    return false;
                }

                return worldA.Id == worldB.Id;
            }

            /// <summary>Determines whether two specified instances of <see cref="GameEvent" /> are not equal.</summary>
            /// <param name="worldA">The first object to compare.</param>
            /// param>
            /// <param name="worldB">The second object to compare. </param>
            /// <returns>true if worldA and worldB do not represent the same event; otherwise, false.</returns>
            public static bool operator !=(GameEventWorld worldA, GameEventWorld worldB)
            {
                return !(worldA == worldB);
            }

            /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.</summary>
            /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
            /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
            public override bool Equals(object obj)
            {
                // If parameter is null return false.
                if (obj == null)
                {
                    return false;
                }

                // If parameter cannot be cast to Point return false.
                var gameEventWorld = obj as GameEventWorld;

                if ((object)gameEventWorld == null)
                {
                    return false;
                }

                return gameEventWorld.Id == this.Id;
            }

            /// <summary>Serves as a hash function for a particular type.</summary>
            /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
            public override int GetHashCode()
            {
                return this.Id.GetHashCode();
            }
        }
    }
}