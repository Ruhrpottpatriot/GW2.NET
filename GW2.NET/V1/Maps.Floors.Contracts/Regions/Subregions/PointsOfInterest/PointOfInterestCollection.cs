// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of Point of Interest (POI) locations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Floors.Contracts.Regions.Subregions.PointsOfInterest
{
    using System.Collections.Generic;

    using GW2DotNET.V1.Common.Types;

    /// <summary>Represents a collection of Point of Interest (POI) locations.</summary>
    public class PointOfInterestCollection : JsonList<PointOfInterest>
    {
        /// <summary>Initializes a new instance of the <see cref="PointOfInterestCollection" /> class.</summary>
        public PointOfInterestCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PointOfInterestCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public PointOfInterestCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PointOfInterestCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public PointOfInterestCollection(IEnumerable<PointOfInterest> collection)
            : base(collection)
        {
        }
    }
}