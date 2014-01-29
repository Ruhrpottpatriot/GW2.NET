// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.Sector.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Map type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.MapInformation.Models
{
    /// <summary>Represents a map.</summary>
    public partial class Map
    {
        /// <summary>Represents a sector.</summary>
        public class Sector
        {
            /// <summary>Initializes a new instance of the <see cref="Sector"/> class.</summary>
            /// <param name="sectorId">The sector id.</param>
            /// <param name="name">The name.</param>
            /// <param name="level">The level.</param>
            /// <param name="coordinates">The coordinates.</param>
            [JsonConstructor]
            public Sector(int sectorId, string name, int level, float[] coordinates)
            {
                this.Id = sectorId;
                this.Coordinates = coordinates;
                this.Level = level;
                this.Name = name;
            }

            /// <summary>Gets the id.</summary>
            [JsonProperty("sector_id")]
            public int Id
            {
                get;
                private set;
            }

            /// <summary>Gets the name.</summary>
            [JsonProperty("name")]
            public string Name
            {
                get;
                private set;
            }

            /// <summary>Gets the level.</summary>
            [JsonProperty("level")]
            public int Level
            {
                get;
                private set;
            }

            /// <summary>Gets the coordinates.</summary>
            [JsonProperty("coord")]
            public float[] Coordinates
            {
                get;
                private set;
            }
        }
    }
}
