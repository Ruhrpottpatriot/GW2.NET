// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of dynamic events and their localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a collection of dynamic events and their localized name.</summary>
    public class DynamicEventCollection : ServiceContractDictionary<Guid, DynamicEvent>
    {
        /// <summary>Initializes a new instance of the <see cref="DynamicEventCollection" /> class.</summary>
        public DynamicEventCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public DynamicEventCollection(IDictionary<Guid, DynamicEvent> collection)
            : base(collection)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public DynamicEventCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Sets each value's ID property to its corresponding key.</summary>
        /// <param name="context">The streaming context.</param>
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            foreach (var kvp in this)
            {
                kvp.Value.EventId = kvp.Key;
            }
        }
    }
}