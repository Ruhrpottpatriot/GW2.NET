// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentFloorCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of continent floors.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Continents.Contracts
{
    using System.Collections.Generic;

    using GW2DotNET.V1.Common.Contracts;

    /// <summary>Represents a collection of continent floors.</summary>
    public class ContinentFloorCollection : JsonList<int>
    {
        /// <summary>Initializes a new instance of the <see cref="ContinentFloorCollection" /> class.</summary>
        public ContinentFloorCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ContinentFloorCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public ContinentFloorCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ContinentFloorCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public ContinentFloorCollection(IEnumerable<int> collection)
            : base(collection)
        {
        }
    }
}