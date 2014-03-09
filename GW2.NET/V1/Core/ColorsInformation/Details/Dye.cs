// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dye.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;
using Newtonsoft.Json;
using ColorConverter = GW2DotNET.V1.Core.Converters.ColorConverter;

namespace GW2DotNET.V1.Core.ColorsInformation.Details
{
    /// <summary>
    ///     Represents a dye and its color component information.
    /// </summary>
    public class Dye : JsonObject
    {
        /// <summary>
        ///     Gets or sets the base RGB values.
        /// </summary>
        [JsonProperty("base_rgb", Order = 2)]
        [JsonConverter(typeof(ColorConverter))]
        public Color BaseRgb { get; set; }

        /// <summary>
        ///     Gets or sets detailed information on the appearance when applied on cloth armor.
        /// </summary>
        [JsonProperty("cloth", Order = 3)]
        public Material Cloth { get; set; }

        /// <summary>
        ///     Gets or sets the color's ID.
        /// </summary>
        [JsonProperty("color_id", Order = 0)]

        public int ColorId { get; set; }

        /// <summary>
        ///     Gets or sets detailed information on the appearance when applied on leather armor.
        /// </summary>
        [JsonProperty("leather", Order = 4)]
        public Material Leather { get; set; }

        /// <summary>
        ///     Gets or sets detailed information on the appearance when applied on metal armor.
        /// </summary>
        [JsonProperty("metal", Order = 5)]
        public Material Metal { get; set; }

        /// <summary>
        ///     Gets or sets the name of the dye.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }
    }
}