// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldNameCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of worlds and their localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.WorldsInformation.Names
{
    using System.Collections.Generic;

    /// <summary>
    ///     Represents a collection of worlds and their localized name.
    /// </summary>
    public class WorldNameCollection : JsonList<WorldName>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WorldNameCollection" /> class.
        /// </summary>
        public WorldNameCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WorldNameCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public WorldNameCollection(IEnumerable<WorldName> collection)
            : base(collection)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WorldNameCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public WorldNameCollection(int capacity)
            : base(capacity)
        {
        }
    }
}