// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlotCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of infusion slots.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ItemsDetails.Types.ItemTypes.Common
{
    using System.Collections.Generic;

    using GW2DotNET.V1.Common.Types;

    /// <summary>Represents a collection of infusion slots.</summary>
    public class InfusionSlotCollection : JsonList<InfusionSlot>
    {
        /// <summary>Initializes a new instance of the <see cref="InfusionSlotCollection" /> class.</summary>
        public InfusionSlotCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="InfusionSlotCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public InfusionSlotCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="InfusionSlotCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public InfusionSlotCollection(IEnumerable<InfusionSlot> collection)
            : base(collection)
        {
        }
    }
}