// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Catalogs
{
    /// <summary>
    ///     Represents a collection of World versus World matches.
    /// </summary>
    public class MatchCollection : JsonList<Match>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MatchCollection" /> class.
        /// </summary>
        public MatchCollection()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MatchCollection" /> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public MatchCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MatchCollection" /> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public MatchCollection(IEnumerable<Match> collection)
            : base(collection)
        {
        }
    }
}