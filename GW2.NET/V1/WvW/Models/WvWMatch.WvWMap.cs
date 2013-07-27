// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WvWMatch.WvWMap.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WvWMatch type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.WvW.Models
{
    /// <summary>
    /// Represents a world vs world match.
    /// </summary>
    public partial class WvWMatch
    {
        /// <summary>
        /// Represents a world vs world map.
        /// </summary>
        public partial class WvWMap
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="WvWMap"/> class.
            /// </summary>
            /// <param name="mapType">
            /// The map type.
            /// </param>
            /// <param name="scores">
            /// The scores.
            /// </param>
            /// <param name="objectives">
            /// The objectives.
            /// </param>
            [JsonConstructor]
            public WvWMap(Type mapType, IEnumerable<int> scores, IEnumerable<Objective> objectives)
    
            {
                this.MapType = mapType;
                this.Scores = scores;
                this.Objectives = objectives;
            }

            /// <summary>
            /// Gets the map type.
            /// </summary>
            [JsonProperty("type")]
            public Type MapType
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the scores.
            /// </summary>
            [JsonProperty("scores")]
            public IEnumerable<int> Scores
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the objectives.
            /// </summary>
            [JsonProperty("objectives")]
            public IEnumerable<Objective> Objectives
            {
                get;
                private set;
            }
        }
    }
}
