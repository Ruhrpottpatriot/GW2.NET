// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Scoreboard.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World versus World scoreboard.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches.Contracts.Common
{
    using GW2DotNET.Common.Contracts;

    using Newtonsoft.Json;

    /// <summary>Represents a World versus World scoreboard.</summary>
    [JsonConverter(typeof(ScoreboardConverter))]
    public class Scoreboard : ServiceContract
    {
        /// <summary>Gets or sets the blue team's score.</summary>
        public int Blue { get; set; }

        /// <summary>Gets or sets the green team's score.</summary>
        public int Green { get; set; }

        /// <summary>Gets or sets the red team's score.</summary>
        public int Red { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format("Red: {0} Green: {1} Blue: {2}", this.Red, this.Green, this.Blue);
        }
    }
}