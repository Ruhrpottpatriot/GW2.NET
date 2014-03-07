// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Points.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations
{
    /// <summary>
    /// Represents a collection of points.
    /// </summary>
    [JsonArray(ItemConverterType = typeof(PointFConverter))]
    public class Points : JsonList<PointF>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Points"/> class.
        /// </summary>
        public Points() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Points"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public Points(IEnumerable<PointF> collection)
            : base(collection)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Points"/> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public Points(int capacity)
            : base(capacity)
        {
        }
    }
}