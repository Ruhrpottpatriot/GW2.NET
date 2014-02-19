// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.Maps.Models;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Maps
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="MapsRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/maps"/> for more information.
    /// </remarks>
    public class MapsResponse : JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapsResponse"/> class.
        /// </summary>
        public MapsResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapsResponse"/> class using the specified collection of maps.
        /// </summary>
        /// <param name="maps">The collection of maps.</param>
        public MapsResponse(IDictionary<int, Map> maps)
        {
            this.Maps = maps;
        }

        /// <summary>
        /// Gets or sets the collection of maps.
        /// </summary>
        [JsonProperty("maps", Order = 0)]
        public IDictionary<int, Map> Maps { get; set; }
    }
}