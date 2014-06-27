// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of worlds and their localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Worlds.Contracts
{
    using System.Collections.Generic;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a collection of worlds and their localized name.</summary>
    public class WorldCollection : ServiceContractList<World>
    {
        /// <summary>Initializes a new instance of the <see cref="WorldCollection" /> class.</summary>
        public WorldCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WorldCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public WorldCollection(IEnumerable<World> collection)
            : base(collection)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WorldCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public WorldCollection(int capacity)
            : base(capacity)
        {
        }
    }
}