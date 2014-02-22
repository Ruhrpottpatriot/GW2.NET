// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sector.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregion.Locations
{
    /// <summary>
    /// Represents an area within a map.
    /// </summary>
    public class Sector : JsonObject
    {
        /// <summary>
        /// Gets or sets the sector's coordinates, which is (usually) the center position.
        /// </summary>
        [JsonProperty("coord", Order = 3)]
        [JsonConverter(typeof(PointFConverter))]
        public PointF Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the sector's level.
        /// </summary>
        [JsonProperty("level", Order = 2)]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the sector's name.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sector's ID.
        /// </summary>
        [JsonProperty("sector_id", Order = 0)]
        public int SectorId { get; set; }
    }
}