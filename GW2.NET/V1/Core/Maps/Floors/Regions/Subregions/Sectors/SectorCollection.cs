// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectorCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of areas within a map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Floors.Regions.Subregions.Sectors
{
    using System.Collections.Generic;

    using GW2DotNET.V1.Core.Common;

    /// <summary>Represents a collection of areas within a map.</summary>
    public class SectorCollection : JsonList<Sector>
    {
        /// <summary>Initializes a new instance of the <see cref="SectorCollection" /> class.</summary>
        public SectorCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SectorCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public SectorCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SectorCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public SectorCollection(IEnumerable<Sector> collection)
            : base(collection)
        {
        }
    }
}