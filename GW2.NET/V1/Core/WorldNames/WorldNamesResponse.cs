// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldNamesResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.WorldNames.Converters;
using GW2DotNET.V1.Core.WorldNames.Models;
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
    public class WorldNamesResponse : JsonObject
    {
        /// <summary>
        /// Gets or sets the list of worlds.
        /// </summary>
        public IEnumerable<World> Worlds { get; set; }
    }
}