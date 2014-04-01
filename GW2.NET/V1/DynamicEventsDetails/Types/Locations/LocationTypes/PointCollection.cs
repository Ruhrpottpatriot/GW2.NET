// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of points.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEventsDetails.Types.Locations.LocationTypes
{
    using System.Collections.Generic;
    using System.Drawing;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Common.Types;

    using Newtonsoft.Json;

    /// <summary>Represents a collection of points.</summary>
    [JsonArray(ItemConverterType = typeof(JsonPointFConverter))]
    public class PointCollection : JsonList<PointF>
    {
        /// <summary>Initializes a new instance of the <see cref="PointCollection" /> class.</summary>
        public PointCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PointCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public PointCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PointCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public PointCollection(IEnumerable<PointF> collection)
            : base(collection)
        {
        }
    }
}