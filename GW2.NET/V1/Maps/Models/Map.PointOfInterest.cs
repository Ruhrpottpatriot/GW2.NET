// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.PointOfInterest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Maps.Models
{
    /// <summary>Represents a map.</summary>
    public partial struct Map
    {
        /// <summary>Represents a point of interest.</summary>
        public partial struct PointOfInterest
        {
            /// <summary>Initializes a new instance of the <see cref="PointOfInterest"/> struct.</summary>
            /// <param name="poiId">The poi id.</param>
            /// <param name="name">The name.</param>
            /// <param name="type">The type.</param>
            /// <param name="floor">The floor.</param>
            /// <param name="coordinates">The coordinates.</param>
            [JsonConstructor]
            public PointOfInterest(int poiId, string name, PoiType type, int floor, float[] coordinates)
                : this()
            {
                this.Id = poiId;
                this.Coordinates = coordinates;
                this.Floor = floor;
                this.Type = type;
                this.Name = name;
            }

            /// <summary>Gets the id.</summary>
            [JsonProperty("poi_id")]
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

            /// <summary>Gets the type.</summary>
            [JsonProperty("type")]
            public PoiType Type
            {
                get;
                private set;
            }

            /// <summary>Gets the floor.</summary>
            [JsonProperty("floor")]
            public int Floor
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
