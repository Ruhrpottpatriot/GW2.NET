// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.World.Models;

namespace GW2DotNET.V1.World
{
    /// <summary>
    /// Contains methods to get or modify the map data.
    /// </summary>
    internal class MapData
    {
        /// <summary>
        /// Gets the maps from the api.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <returns>The <see cref="IList"/> of maps.</returns>
        internal IList<GwMap> GetMaps(Language language = Language.En)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", language.ToString())
            };

            return ApiCall.GetContent<List<GwMap>>("map_names.json", arguments, ApiCall.Categories.World);
        }
    }
}
