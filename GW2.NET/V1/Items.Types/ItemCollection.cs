// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of item identifiers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Types
{
    using System.Collections.Generic;

    using GW2DotNET.V1.Common.Types;

    /// <summary>Represents a collection of item identifiers.</summary>
    public class ItemCollection : JsonList<int>
    {
        /// <summary>Initializes a new instance of the <see cref="ItemCollection" /> class.</summary>
        public ItemCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public ItemCollection(IEnumerable<int> collection)
            : base(collection)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public ItemCollection(int capacity)
            : base(capacity)
        {
        }
    }
}