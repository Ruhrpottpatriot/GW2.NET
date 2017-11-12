// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IngredientDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the IngredientDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Recipes.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/recipe_details")]
    internal sealed class IngredientDataContract
    {
        [DataMember(Name = "item_id", Order = 0)]
        internal string ItemId { get; set; }

        [DataMember(Name = "count", Order = 1)]
        internal string Count { get; set; }
    }
}