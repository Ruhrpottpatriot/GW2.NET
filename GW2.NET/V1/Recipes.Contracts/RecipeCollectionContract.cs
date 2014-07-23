// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeCollectionContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of recipe identifiers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Wraps a collection of recipe identifiers.</summary>
    public sealed class RecipeCollectionContract : ServiceContract
    {
        /// <summary>Gets or sets a collection of recipe identifiers.</summary>
        [DataMember(Name = "recipes", Order = 0)]
        public ICollection<int> Recipes { get; set; }
    }
}