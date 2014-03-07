// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Items.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.ItemsInformation.Catalogs
{
    /// <summary>
    /// Represents a collection of item IDs.
    /// </summary>
    public class Items : JsonList<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Items"/> class.
        /// </summary>
        public Items()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Items"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public Items(IEnumerable<int> collection)
            : base(collection)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Items"/> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public Items(int capacity)
            : base(capacity)
        {
        }
    }
}