// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Scoreboard.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.WvW.MatchDetails.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WvW.MatchDetails.Models
{
    /// <summary>
    /// Represents a World versus World scoreboard.
    /// </summary>
    [JsonConverter(typeof(ScoreboardConverter))]
    public class Scoreboard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Scoreboard"/> class.
        /// </summary>
        public Scoreboard()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Scoreboard"/> class using the specified values.
        /// </summary>
        /// <param name="red">The red team's score.</param>
        /// <param name="blue">The blue team's score.</param>
        /// <param name="green">The green team's score.</param>
        public Scoreboard(int red, int blue, int green)
        {
            this.Red = red;
            this.Blue = blue;
            this.Green = green;
        }

        /// <summary>
        /// Gets or sets the blue team's score.
        /// </summary>
        public int Blue { get; set; }

        /// <summary>
        /// Gets or sets the green team's score.
        /// </summary>
        public int Green { get; set; }

        /// <summary>
        /// Gets or sets the red team's score.
        /// </summary>
        public int Red { get; set; }

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