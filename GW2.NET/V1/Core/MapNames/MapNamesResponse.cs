// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapNamesResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.MapNames.Converters;
using GW2DotNET.V1.Core.MapNames.Models;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.MapNames
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="MapNamesRequest"/>.
    /// </summary>
    /// <remarks>
    /// The returned data only contains static content. Dynamic content, such as vendors, is not currently available.
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names"/> for more information.
    /// </remarks>
    [JsonConverter(typeof(MapNamesResponseConverter))]
    public class MapNamesResponse : JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapNamesResponse"/> class.
        /// </summary>
        public MapNamesResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapNamesResponse"/> class using the specified list of maps.
        /// </summary>
        /// <param name="maps">The list of maps.</param>
        public MapNamesResponse(IEnumerable<Map> maps)
        {
            this.Maps = maps;
        }

        /// <summary>
        /// Gets or sets the list of maps.
        /// </summary>
        public IEnumerable<Map> Maps { get; set; }
    }
}