// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapNamesResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace GW2DotNET.V1.Core.MapNames
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="MapNamesRequest"/>.
    /// </summary>
    /// <remarks>
    /// The returned data only contains static content. Dynamic content, such as vendors, is not currently available.
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names"/> for more information.
    /// </remarks>
    public class MapNamesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapNamesResponse"/> class.
        /// </summary>
        public MapNamesResponse()
        {
            throw new NotImplementedException();
        }
    }
}
