// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventNames.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Names
{
    /// <summary>
    /// Represents a list of dynamic events and their localized name.
    /// </summary>
    public class DynamicEventNames : JsonList<DynamicEventName>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventNames"/> class.
        /// </summary>
        public DynamicEventNames()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventNames"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public DynamicEventNames(IEnumerable<DynamicEventName> collection)
            : base(collection)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventNames"/> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public DynamicEventNames(int capacity)
            : base(capacity)
        {
        }
    }
}