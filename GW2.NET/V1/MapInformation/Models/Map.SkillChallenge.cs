// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.SkillChallenge.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Map type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.MapInformation.Models
{
    /// <summary>Represents a map.</summary>
    public partial class Map
    {
        /// <summary>Represents a skill challenge.</summary>
        public class SkillChallenge
        {
            /// <summary>Initializes a new instance of the <see cref="SkillChallenge"/> class.</summary>
            /// <param name="coordinates">The coordinates.</param>
            [JsonConstructor]
            public SkillChallenge(float[] coordinates)
            {
                this.Coordinates = coordinates;
            }

            /// <summary>Gets the coordinates.</summary>
            [JsonProperty("coord")]
            public float[] Coordinates { get; private set; }
        }
    }
}