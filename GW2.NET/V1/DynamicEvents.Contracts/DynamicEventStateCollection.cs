// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventStateCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of dynamic events and their status.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Contracts
{
    using System.Collections.Generic;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a collection of dynamic events and their status.</summary>
    public class DynamicEventStateCollection : ServiceContractList<DynamicEventState>
    {
        /// <summary>Initializes a new instance of the <see cref="DynamicEventStateCollection" /> class.</summary>
        public DynamicEventStateCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventStateCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public DynamicEventStateCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventStateCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public DynamicEventStateCollection(IEnumerable<DynamicEventState> collection)
            : base(collection)
        {
        }
    }
}