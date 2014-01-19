// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkillChallenge.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System.Drawing;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.MapFloor
{
    /// <summary>
    /// Represents a skill challenge location.
    /// </summary>
    public class SkillChallenge
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkillChallenge"/> class.
        /// </summary>
        public SkillChallenge()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillChallenge"/> class using the specified values.
        /// </summary>
        /// <param name="coordinates">The skill challenge's coordinates.</param>
        public SkillChallenge(PointF coordinates)
        {
            this.Coordinates = coordinates;
        }

        /// <summary>
        /// Gets or sets the skill challenge's coordinates.
        /// </summary>
        [JsonProperty("coord", Order = 0)]
        [JsonConverter(typeof(PointFConverter))]
        public PointF Coordinates { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}