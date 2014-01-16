// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Continents
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="ContinentsRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/continents"/> for more information.
    /// </remarks>
    public class ContinentsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContinentsResponse"/> class.
        /// </summary>
        public ContinentsResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContinentsResponse"/> class using the specified values.
        /// </summary>
        /// <param name="continents">The collection of continents.</param>
        public ContinentsResponse(IDictionary<int, Continent> continents)
        {
            this.Continents = continents;
        }

        /// <summary>
        /// Gets or sets the collection of continents.
        /// </summary>
        [JsonProperty("continents")]
        public IDictionary<int, Continent> Continents { get; set; }

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
