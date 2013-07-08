// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloor.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapFloor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace GW2DotNET.V1.Maps.Models
{
    using Newtonsoft.Json;

    /// <summary>Represents a map floor.</summary>
    public partial class MapFloor
    {
        /// <summary>Initializes a new instance of the <see cref="MapFloor"/> class.</summary>
        /// <param name="textureDims">The texture dims.</param>
        /// <param name="regions">The regions.</param>
        [JsonConstructor]
        public MapFloor(int[] textureDims, Dictionary<int, Region> regions)

        {
            this.Regions = regions.Values.Zip(regions.Keys, (value, key) => value.ResolveId(key));
            this.TextureDims = textureDims;
        }

        /// <summary>Gets the texture dims.</summary>
        [JsonProperty("texture_dims")]
        public int[] TextureDims
        {
            get;
            private set;
        }

        /// <summary>Gets the regions.</summary>
        [JsonProperty("regions")]
        public IEnumerable<Region> Regions
        {
            get;
            private set;
        }
    }
}