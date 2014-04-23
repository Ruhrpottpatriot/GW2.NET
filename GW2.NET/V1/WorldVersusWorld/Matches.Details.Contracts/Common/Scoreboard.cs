// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Scoreboard.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World versus World scoreboard.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches.Details.Contracts.Common
{
    using GW2DotNET.V1.Common.Types;

    using Newtonsoft.Json;

    /// <summary>Represents a World versus World scoreboard.</summary>
    [JsonConverter(typeof(ScoreboardConverter))]
    public class Scoreboard : JsonObject
    {
        /// <summary>Gets or sets the blue team's score.</summary>
        public int Blue { get; set; }

        /// <summary>Gets or sets the green team's score.</summary>
        public int Green { get; set; }

        /// <summary>Gets or sets the red team's score.</summary>
        public int Red { get; set; }
    }
}