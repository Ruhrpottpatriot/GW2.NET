// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sector.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Drawing;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.MapFloor
{
    /// <summary>
    /// Represents an area within a map.
    /// </summary>
    public class Sector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sector"/> class.
        /// </summary>
        public Sector()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sector"/> class using the specified values.
        /// </summary>
        /// <param name="sectorId">The sector's ID.</param>
        /// <param name="name">The sector's name.</param>
        /// <param name="level">The sector's level.</param>
        /// <param name="coordinates">The sector's coordinates.</param>
        public Sector(int sectorId, string name, int level, PointF coordinates)
        {
            this.SectorId = sectorId;
            this.Name = name;
            this.Level = level;
            this.Coordinates = coordinates;
        }

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

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}