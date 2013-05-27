// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwMap.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map/region in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.World.Models
{
    /// <summary>
    /// Represents a map/region in the game.
    /// </summary>
    public struct GwMap
    {
        /// <summary>
        /// The id of the map. This field is readonly.
        /// </summary>
        private readonly int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="GwMap"/> struct.
        /// </summary>
        /// <param name="id">The map id.</param>
        /// <param name="name">The map name.</param>
        [JsonConstructor]
        public GwMap(int id, string name)
            : this()
        {
            this.id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets the map id.
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
        /// Gets the map name.
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
        /// <param name="mapA">The first object to compare.</param>param>
        /// <param name="mapB">The second object to compare. </param>
        /// <returns>true if mapA and mapB represent the same map; otherwise, false.</returns>
        public static bool operator ==(GwMap mapA, GwMap mapB)
        {
            return mapA.Id == mapB.Id;
        }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="GwMap"/> are not equal.
        /// </summary>
        /// <param name="mapA">The first object to compare.</param>param>
        /// <param name="mapB">The second object to compare. </param>
        /// <returns>true if mapA and mapB do not represent the same map; otherwise, false.</returns>
        public static bool operator !=(GwMap mapA, GwMap mapB)
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
            return obj is GwMap && this == (GwMap)obj;
        }

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="GwMap"/> are equal.
        /// </summary>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="obj">Another object to compare to. </param>
        public bool Equals(GwMap obj)
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