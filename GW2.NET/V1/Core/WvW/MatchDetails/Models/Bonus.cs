// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bonus.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WvW.MatchDetails.Models
{
    /// <summary>
    /// Represents a World versus World map's bonus.
    /// </summary>
    public class Bonus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bonus"/> class.
        /// </summary>
        public Bonus()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bonus"/> class using the specified values.
        /// </summary>
        /// <param name="type">The bonus type.</param>
        /// <param name="owner">The team that holds the bonus.</param>
        public Bonus(BonusType type, TeamColor owner)
        {
            this.Type = type;
            this.Owner = owner;
        }

        /// <summary>
        /// Gets or sets the team that holds the bonus.
        /// </summary>
        [JsonProperty("owner", Order = 1)]
        public TeamColor Owner { get; set; }

        /// <summary>
        /// Gets or sets the bonus type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public BonusType Type { get; set; }

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