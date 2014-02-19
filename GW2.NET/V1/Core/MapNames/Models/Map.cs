// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.MapNames.Models
{
    /// <summary>
    /// Represents a map and its localized name.
    /// </summary>
    public class Map : JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        public Map()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class using the specified values.
        /// </summary>
        /// <param name="id">The map's ID.</param>
        /// <param name="name">The map's name.</param>
        public Map(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the map's ID.
        /// </summary>
        [JsonProperty("id", Order = 0)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the map's name.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }
    }
}