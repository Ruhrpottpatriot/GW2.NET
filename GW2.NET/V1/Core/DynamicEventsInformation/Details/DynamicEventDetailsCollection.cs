// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of dynamic events and their localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Details
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Represents a collection of dynamic events and their localized name.
    /// </summary>
    public class DynamicEventDetailsCollection : JsonDictionary<Guid, DynamicEventDetails>
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicEventDetailsCollection" /> class.
        /// </summary>
        public DynamicEventDetailsCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventDetailsCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public DynamicEventDetailsCollection(IDictionary<Guid, DynamicEventDetails> collection)
            : base(collection)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventDetailsCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public DynamicEventDetailsCollection(int capacity)
            : base(capacity)
        {
        }

        #endregion

        #region Methods

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

        #endregion
    }
}