// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bonuses.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Details
{
    /// <summary>
    /// Represents a collection of World versus World map bonuses.
    /// </summary>
    public class Bonuses : JsonList<Bonus>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bonuses"/> class.
        /// </summary>
        public Bonuses()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bonuses"/> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public Bonuses(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bonuses"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public Bonuses(IEnumerable<Bonus> collection)
            : base(collection)
        {
        }
    }
}