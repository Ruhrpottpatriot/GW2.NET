// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding a map floor, used to populate a world map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2DotNET.Common;

    /// <summary>Represents a request for details regarding a map floor, used to populate a world map.</summary>
    public class MapFloorRequest : IRequest, ILocalizable
    {
        /// <summary>Gets or sets the continent identifier.</summary>
        public int? ContinentId { get; set; }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the floor number.</summary>
        public int? Floor { get; set; }

        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return "v1/map_floor.json";
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            // Get the 'continent_id' parameter
            if (this.ContinentId.HasValue)
            {
                yield return new KeyValuePair<string, string>("continent_id", this.ContinentId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Get the 'floor' parameter
            if (this.Floor.HasValue)
            {
                yield return new KeyValuePair<string, string>("floor", this.Floor.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Get the 'lang' parameter
            if (this.Culture != null)
            {
                yield return new KeyValuePair<string, string>("lang", this.Culture.TwoLetterISOLanguageName);
            }
        }
    }
}