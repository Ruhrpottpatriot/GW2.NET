// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WvW.MatchDetails.Models
{
    /// <summary>
    /// Represents a World versus World map.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        public Map()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class using the specified values.
        /// </summary>
        /// <param name="type">The map's type.</param>
        /// <param name="scores">The map's scoreboard.</param>
        /// <param name="objectives">The map's objectives.</param>
        /// <param name="bonuses">The map's bonuses.</param>
        public Map(MapType type, Scoreboard scores, IEnumerable<Objective> objectives, IEnumerable<Bonus> bonuses)
        {
            this.Type = type;
            this.Scores = scores;
            this.Objectives = objectives;
            this.Bonuses = bonuses;
        }

        /// <summary>
        /// Gets or sets the map's bonuses.
        /// </summary>
        [JsonProperty("bonuses", Order = 3)]
        public IEnumerable<Bonus> Bonuses { get; set; }

        /// <summary>
        /// Gets or sets the map's objectives.
        /// </summary>
        [JsonProperty("objectives", Order = 2)]
        public IEnumerable<Objective> Objectives { get; set; }

        /// <summary>
        /// Gets or sets the map's scoreboard.
        /// </summary>
        [JsonProperty("scores", Order = 1)]
        public Scoreboard Scores { get; set; }

        /// <summary>
        /// Gets or sets the map's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public MapType Type { get; set; }

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