// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeCollectionResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of recipe identifiers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Types
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Types;

    /// <summary>Wraps a collection of recipe identifiers.</summary>
    public class RecipeCollectionResult : JsonObject
    {
        /// <summary>Gets or sets a collection of recipe identifiers.</summary>
        [DataMember(Name = "recipes", Order = 0)]
        public RecipeCollection Recipes { get; set; }
    }
}