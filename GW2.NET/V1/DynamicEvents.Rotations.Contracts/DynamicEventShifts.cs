// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventShifts.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of world boss shifts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Rotations.Contracts
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Common.Contracts;

    /// <summary>Represents a collection of world boss shifts.</summary>
    public class DynamicEventShifts : JsonList<DateTimeOffset>
    {
        /// <summary>Initializes a new instance of the <see cref="DynamicEventShifts" /> class.</summary>
        public DynamicEventShifts()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventShifts"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public DynamicEventShifts(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventShifts"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public DynamicEventShifts(IEnumerable<DateTimeOffset> collection)
            : base(collection)
        {
        }
    }
}