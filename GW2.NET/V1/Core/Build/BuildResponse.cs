// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Build
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="BuildRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/build"/> for more information.
    /// </remarks>
    public class BuildResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildResponse"/> class.
        /// </summary>
        /// <param name="buildId">The build ID.</param>
        [JsonConstructor]
        public BuildResponse(int buildId)
        {
            this.BuildId = buildId;
        }

        /// <summary>
        /// Gets the current build ID of the game.
        /// </summary>
        [JsonProperty("build_id")]
        public int BuildId { get; private set; }

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
