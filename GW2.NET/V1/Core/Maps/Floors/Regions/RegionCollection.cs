// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of regions on the map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Floors.Regions
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Core.Common;

    /// <summary>Represents a collection of regions on the map.</summary>
    public class RegionCollection : JsonDictionary<int, Region>
    {
        /// <summary>Initializes a new instance of the <see cref="RegionCollection" /> class.</summary>
        public RegionCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RegionCollection"/> class.</summary>
        /// <param name="capacity">The initial number of elements that the new dictionary can contain.</param>
        public RegionCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RegionCollection"/> class.</summary>
        /// <param name="dictionary">The dictionary whose values are copied to the new dictionary.</param>
        public RegionCollection(IDictionary<int, Region> dictionary)
            : base(dictionary)
        {
        }

        /// <summary>Sets each value's ID property to its corresponding key.</summary>
        /// <param name="context">The streaming context.</param>
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            foreach (var kvp in this)
            {
                kvp.Value.RegionId = kvp.Key;
            }
        }
    }
}