// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Maps.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Details
{
    /// <summary>
    /// Represents a collection of World versus World maps.
    /// </summary>
    public class Maps : JsonList<Map>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Maps"/> class.
        /// </summary>
        public Maps()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Maps"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public Maps(IEnumerable<Map> collection)
            : base(collection)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Maps"/> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public Maps(int capacity)
            : base(capacity)
        {
        }
    }
}