// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapNameCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of maps and their localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Names
{
    using System.Collections.Generic;

    using GW2DotNET.V1.Core.Common;

    /// <summary>Represents a collection of maps and their localized name.</summary>
    public class MapNameCollection : JsonList<MapName>
    {
        /// <summary>Initializes a new instance of the <see cref="MapNameCollection" /> class.</summary>
        public MapNameCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapNameCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public MapNameCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapNameCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public MapNameCollection(IEnumerable<MapName> collection)
            : base(collection)
        {
        }
    }
}