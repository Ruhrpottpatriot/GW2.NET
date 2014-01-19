// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dye.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Drawing;
using Newtonsoft.Json;
using JsonColorConverter = GW2DotNET.V1.Core.Converters.ColorConverter;

namespace GW2DotNET.V1.Core.Colors
{
    /// <summary>
    /// Represents a dye and its color component information.
    /// </summary>
    public class Dye
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dye"/> class.
        /// </summary>
        public Dye()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dye"/> class using the specified values.
        /// </summary>
        /// <param name="name">The name of the dye.</param>
        /// <param name="baseRGB">The base RGB values.</param>
        /// <param name="cloth">Information on the appearance when applied on cloth armor.</param>
        /// <param name="leather">Information on the appearance when applied on leather armor.</param>
        /// <param name="metal">Information on the appearance when applied on metal armor.</param>
        public Dye(string name, Color baseRGB, Material cloth, Material leather, Material metal)
        {
            this.Name = name;
            this.BaseRGB = baseRGB;
            this.Cloth = cloth;
            this.Leather = leather;
            this.Metal = metal;
        }

        /// <summary>
        /// Gets or sets the base RGB values.
        /// </summary>
        [JsonProperty("base_rgb", Order = 1)]
        [JsonConverter(typeof(JsonColorConverter))]
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