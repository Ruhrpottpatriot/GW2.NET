// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenownTask.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations
{
    /// <summary>
    ///     Represents a renown heart location.
    /// </summary>
    public class RenownTask : JsonObject
    {
        /// <summary>
        ///     Gets or sets the task's coordinates.
        /// </summary>
        [JsonProperty("coord", Order = 3)]
        [JsonConverter(typeof(PointFConverter))]
        public PointF Coordinates { get; set; }

        /// <summary>
        ///     Gets or sets the level.
        /// </summary>
        [JsonProperty("level", Order = 2)]
        public int Level { get; set; }

        /// <summary>
        ///     Gets or sets the name or objective.
        /// </summary>
        [JsonProperty("objective", Order = 1)]
        public string Objective { get; set; }

        /// <summary>
        ///     Gets or sets the renown heart ID.
        /// </summary>
        [JsonProperty("task_id", Order = 0)]
        public int TaskId { get; set; }
    }
}