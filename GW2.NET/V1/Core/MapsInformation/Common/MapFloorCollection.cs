// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.MapsInformation.Common
{
    /// <summary>
    /// Represents a collection of map floors.
    /// </summary>
    public class MapFloorCollection : JsonList<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapFloorCollection"/> class.
        /// </summary>
        public MapFloorCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapFloorCollection"/> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public MapFloorCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapFloorCollection"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public MapFloorCollection(IEnumerable<int> collection)
            : base(collection)
        {
        }
    }
}
