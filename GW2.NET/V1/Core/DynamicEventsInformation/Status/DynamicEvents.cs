// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEvents.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Status
{
    /// <summary>
    /// Represents a list of dynamic events and their status.
    /// </summary>
    public class DynamicEvents : JsonList<DynamicEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEvents"/> class.
        /// </summary>
        public DynamicEvents()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEvents"/> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public DynamicEvents(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEvents"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public DynamicEvents(IEnumerable<DynamicEvent> collection)
            : base(collection)
        {
        }
    }
}