// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldNamesResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WorldNames
{
    /// <summary>
    /// Represents a response that is the result of an <see cref="WorldNamesRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names"/> for more information.
    /// </remarks>
    [JsonConverter(typeof(WorldNamesResponseConverter))]
    public class WorldNamesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldNamesResponse"/> class.
        /// </summary>
        public WorldNamesResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldNamesResponse"/> class using the specified list of worlds.
        /// </summary>
        /// <param name="worlds">The list of worlds.</param>
        public WorldNamesResponse(IEnumerable<World> worlds)
        {
            this.Worlds = worlds;
        }

        /// <summary>
        /// Gets or sets the list of worlds.
        /// </summary>
        public IEnumerable<World> Worlds { get; set; }

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