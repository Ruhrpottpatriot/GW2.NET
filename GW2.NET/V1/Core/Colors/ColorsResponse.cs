// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Colors
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="ColorsRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/colors"/> for more information.
    /// </remarks>
    public class ColorsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorsResponse"/> class.
        /// </summary>
        public ColorsResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorsResponse"/> class using the specified collection of dyes.
        /// </summary>
        /// <param name="colors">The collection of dyes.</param>
        public ColorsResponse(IDictionary<int, Dye> colors)
        {
            this.Colors = colors;
        }

        /// <summary>
        /// Gets or sets a collection of all dyes in the game.
        /// </summary>
        [JsonProperty("colors", Order = 0)]
        public IDictionary<int, Dye> Colors { get; set; }

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