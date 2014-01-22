// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchesResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.WvW.Matches.Models;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WvW.Matches
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="MatchesRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches"/> for more information.
    /// </remarks>
    public class MatchesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatchesResponse"/> class.
        /// </summary>
        public MatchesResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchesResponse"/> class using the specified values.
        /// </summary>
        /// <param name="matches">The list of matches.</param>
        public MatchesResponse(IEnumerable<Match> matches)
        {
            this.Matches = matches;
        }

        /// <summary>
        /// Gets or sets the list of matches.
        /// </summary>
        [JsonProperty("wvw_matches", Order = 0)]
        public IEnumerable<Match> Matches { get; set; }

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