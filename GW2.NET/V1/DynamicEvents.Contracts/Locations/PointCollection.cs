// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of points.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Contracts.Locations
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.Serialization;

    /// <summary>Represents a collection of points.</summary>
    [CollectionDataContract]
    public class PointCollection : List<PointF>
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