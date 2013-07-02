// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwColour.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GwColour type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models
{
    /// <summary>
    /// Represents a colour in the game.
    /// </summary>
    public partial struct GwColour
    {
        /// <summary>
        /// The colour id.
        /// </summary>
        private readonly int id;

        /// <summary>Initializes a new instance of the <see cref="GwColour"/> struct.</summary>
        /// <param name="id">The colour id.</param>
        /// <param name="name">The name of the colour</param>
        /// <param name="baseRgb">The base Rgb.</param>
        /// <param name="clothDetail">The colour modifying attributes on cloth.</param>
        /// <param name="leatherDetail">The  colour modifying attributes on leather.</param>
        /// <param name="metalDetail">The colour modifying attributes on metal.</param>
        [JsonConstructor]
        public GwColour(int id, string name, int[] baseRgb, ColourDetails clothDetail, ColourDetails leatherDetail, ColourDetails metalDetail)
            : this()
        {
            this.id = id;
            this.Name = name;
            this.BaseRgb = baseRgb;
            this.Cloth = clothDetail;
            this.Leather = leatherDetail;
            this.Metal = metalDetail;
        }

        /// <summary>
        /// Gets the colour id.
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the base rgb.
        /// </summary>
        [JsonProperty("base_rgb")]
        public int[] BaseRgb { get; private set; }

        /// <summary>
        /// Gets the colour modifying attributes on cloth.
        /// </summary>
        [JsonProperty("cloth")]
        public ColourDetails Cloth
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the colour modifying attributes on leather.
        /// </summary>
        [JsonProperty("leather")]
        public ColourDetails Leather
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the colour modifying attributes on metal.
        /// </summary>
        [JsonProperty("metal")]
        public ColourDetails Metal
        {
            get;
            private set;
        }
    }
}
