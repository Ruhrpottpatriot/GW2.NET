// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenownTaskCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations
{
    /// <summary>
    ///     Represents a collection of renown heart locations.
    /// </summary>
    public class RenownTaskCollection : JsonList<RenownTask>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RenownTaskCollection" /> class.
        /// </summary>
        public RenownTaskCollection()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RenownTaskCollection" /> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public RenownTaskCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RenownTaskCollection" /> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public RenownTaskCollection(IEnumerable<RenownTask> collection)
            : base(collection)
        {
        }
    }
}