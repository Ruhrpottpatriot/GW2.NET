// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapNames.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.MapsInformation.Names
{
    /// <summary>
    /// Represents a collection of maps and their localized name.
    /// </summary>
    public class MapNames : JsonList<MapName>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapNames"/> class.
        /// </summary>
        public MapNames()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapNames"/> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public MapNames(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapNames"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public MapNames(IEnumerable<MapName> collection)
            : base(collection)
        {
        }
    }
}