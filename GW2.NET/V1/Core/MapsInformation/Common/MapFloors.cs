// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloors.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.MapsInformation.Common
{
    /// <summary>
    /// Represents a collection of map floors.
    /// </summary>
    public class MapFloors : JsonList<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapFloors"/> class.
        /// </summary>
        public MapFloors()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapFloors"/> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public MapFloors(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapFloors"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public MapFloors(IEnumerable<int> collection)
            : base(collection)
        {
        }
    }
}
