// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapRegionCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.MapsInformation.Floors.Regions
{
    /// <summary>
    /// Represents a collection of regions on the map.
    /// </summary>
    public class MapRegionCollection : JsonDictionary<int, MapRegion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapRegionCollection"/> class.
        /// </summary>
        public MapRegionCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapRegionCollection"/> class.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the new dictionary can contain.</param>
        public MapRegionCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapRegionCollection"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary whose values are copied to the new dictionary.</param>
        public MapRegionCollection(IDictionary<int, MapRegion> dictionary)
            : base(dictionary)
        {
        }
    }
}