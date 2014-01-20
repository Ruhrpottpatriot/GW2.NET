// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloor.Region.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map floor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace GW2DotNET.V1.MapInformation.Models
{
    /// <summary>Represents a map floor.</summary>
    public partial class MapFloor
    {
        /// <summary>Represents a region.</summary>
        public class Region
        {
            /// <summary>Initializes a new instance of the <see cref="Region"/> class.</summary>
            /// <param name="name">The name.</param>
            /// <param name="labelCoordinates">The label coordinates.</param>
            /// <param name="maps">The maps.</param>
            [JsonConstructor]
            public Region(string name, int[] labelCoordinates, Dictionary<int, Map> maps)
    
            {
                this.Maps = maps.Values.Zip(maps.Keys, (value, key) => value.ResolveId(key)).ToList();
                this.LabelCoordinates = labelCoordinates;
                this.Name = name;
            }

            /// <summary>Gets the id.</summary>
            public int Id
            {
                get;
                internal set;
            }

            /// <summary>Gets the name.</summary>
            [JsonProperty("name")]
            public string Name
            {
                get;
                private set;
            }

            /// <summary>Gets the label coordinates.</summary>
            [JsonProperty("label_coord")]
            public int[] LabelCoordinates
            {
                get;
                private set;
            }

            /// <summary>Gets the maps.</summary>
            [JsonProperty("maps")]
            public List<Map> Maps
            {
                get;
                private set;
            }

            /// <summary>Resolves the Id for the current instance of the Region struct</summary>
            /// <param name="id">The id.</param>
            /// <returns>The <see cref="Region"/>.</returns>
            internal Region ResolveId(int id)
            {
                this.Id = id;
                return this;
            }
        }
    }
}
