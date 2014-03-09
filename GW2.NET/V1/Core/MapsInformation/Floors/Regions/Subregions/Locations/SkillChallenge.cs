// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkillChallenge.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a skill challenge location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations
{
    using System.Drawing;

    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a skill challenge location.
    /// </summary>
    public class SkillChallenge : JsonObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the skill challenge's coordinates.
        /// </summary>
        [JsonProperty("coord", Order = 0)]
        [JsonConverter(typeof(JsonPointFConverter))]
        public PointF Coordinates { get; set; }

        #endregion
    }
}