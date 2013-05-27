// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwWorld.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the World type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.World.Models
{
    /// <summary>
    /// Represents a Guild Wars 2 world.
    /// </summary>
    public struct GwWorld
    {
        /// <summary>
        /// The id of the world. This field is readonly.
        /// </summary>
        private readonly int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="GwWorld"/> struct.
        /// </summary>
        /// <param name="id">The id of the world.</param>
        /// <param name="name">The name of the world.</param>
        [JsonConstructor]
        public GwWorld(int id, string name)
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
        }

        /// <summary>
        /// Gets the name of the world.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="GwMap"/> are equal.
        /// </summary>
        /// <param name="worldA">The first object to compare.</param>param>
        /// <param name="worldB">The second object to compare. </param>
        /// <returns>true if worldA and worldB represent the same map; otherwise, false.</returns>
        public static bool operator ==(GwWorld worldA, GwWorld worldB)
        {
            return worldA.Id == worldB.Id;
        }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="GwMap"/> are not equal.
        /// </summary>
        /// <param name="worldA">The first object to compare.</param>param>
        /// <param name="worldB">The second object to compare. </param>
        /// <returns>true if worldA and worldB do not represent the same map; otherwise, false.</returns>
        public static bool operator !=(GwWorld worldA, GwWorld worldB)
        {
            return !(worldA == worldB);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="obj">Another object to compare to.</param>
        public override bool Equals(object obj)
        {
            return obj is GwWorld && this == (GwWorld)obj;
        }

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="Events.Models.Map"/> are equal.
        /// </summary>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="obj">Another object to compare to. </param>
        public bool Equals(GwWorld obj)
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
