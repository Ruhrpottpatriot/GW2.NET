// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of recipe identifiers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents a collection of recipe identifiers.</summary>
    [CollectionDataContract]
    public class RecipeCollection : List<int>
    {
        /// <summary>Initializes a new instance of the <see cref="RecipeCollection" /> class.</summary>
        public RecipeCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RecipeCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public RecipeCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RecipeCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public RecipeCollection(IEnumerable<int> collection)
            : base(collection)
        {
        }
    }
}