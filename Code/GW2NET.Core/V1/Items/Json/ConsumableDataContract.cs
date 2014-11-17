// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ConsumableDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/item_details")]
    internal sealed class ConsumableDataContract
    {
        [DataMember(Name = "type", Order = 0)]
        internal string Type { get; set; }

        [DataMember(Name = "duration_ms", Order = 1)]
        internal string Duration { get; set; }

        [DataMember(Name = "description", Order = 2)]
        internal string Description { get; set; }

        [DataMember(Name = "unlock_type", Order = 3)]
        internal string UnlockType { get; set; }

        [DataMember(Name = "recipe_id", Order = 4)]
        internal string RecipeId { get; set; }

        [DataMember(Name = "color_id", Order = 5)]
        internal string ColorId { get; set; }
    }
}