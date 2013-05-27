// --------------------------------------------------------------------------------------------------------------------
// <copyright file="World.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the World type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.Events.Models
{
    using System;

    /// <summary>
    /// Represents a Guild Wars 2 world.
    /// </summary>
    [Obsolete("This class is obsolete. Use the WorldManager class in the GW2DotNET.V1.World namespace instead.")]
    public struct World
    {
        /// <summary>
        /// The id of the world. This field is readonly.
        /// </summary>
        private int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> struct.
        /// </summary>
        /// <param name="id">The id of the world.</param>
        /// <param name="name">The name of the world.</param>
        public World(int id, string name)
            : this()
        {
            this.id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets the id of the world.
        /// </summary>
        [JsonProperty("id")]
        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets the name of the world.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="Map"/> are equal.
        /// </summary>
        /// <param name="mapA">The first object to compare.</param>param>
        /// <param name="mapB">The second object to compare. </param>
        /// <returns>true if mapA and mapB represent the same map; otherwise, false.</returns>
        public static bool operator ==(World mapA, World mapB)
        {
            return mapA.Id == mapB.Id;
        }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="Map"/> are not equal.
        /// </summary>
        /// <param name="mapA">The first object to compare.</param>param>
        /// <param name="mapB">The second object to compare. </param>
        /// <returns>true if mapA and mapB do not represent the same map; otherwise, false.</returns>
        public static bool operator !=(World mapA, World mapB)
        {
            return !(mapA == mapB);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="obj">Another object to compare to.</param>
        public override bool Equals(object obj)
        {
            return obj is World && this == (World)obj;
        }

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="Map"/> are equal.
        /// </summary>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="obj">Another object to compare to. </param>
        public bool Equals(World obj)
        {
            return this.id == obj.id;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }
}
