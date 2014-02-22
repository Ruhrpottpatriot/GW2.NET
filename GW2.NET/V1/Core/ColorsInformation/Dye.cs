// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dye.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;
using Newtonsoft.Json;
using ColorConverter = GW2DotNET.V1.Core.Converters.ColorConverter;

namespace GW2DotNET.V1.Core.ColorsInformation
{
    /// <summary>
    /// Represents a dye and its color component information.
    /// </summary>
    public class Dye : JsonObject
    {
        /// <summary>
        /// Gets or sets the base RGB values.
        /// </summary>
        [JsonProperty("base_rgb", Order = 1)]
        [JsonConverter(typeof(ColorConverter))]
        public Color BaseRGB { get; set; }

        /// <summary>
        /// Gets or sets detailed information on the appearance when applied on cloth armor.
        /// </summary>
        [JsonProperty("cloth", Order = 2)]
        public Material Cloth { get; set; }

        /// <summary>
        /// Gets or sets detailed information on the appearance when applied on leather armor.
        /// </summary>
        [JsonProperty("leather", Order = 3)]
        public Material Leather { get; set; }

        /// <summary>
        /// Gets or sets detailed information on the appearance when applied on metal armor.
        /// </summary>
        [JsonProperty("metal", Order = 4)]
        public Material Metal { get; set; }

        /// <summary>
        /// Gets or sets the name of the dye.
        /// </summary>
        [JsonProperty("name", Order = 0)]
        public string Name { get; set; }
    }
}