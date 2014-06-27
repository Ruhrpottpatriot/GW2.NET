// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ferocity.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an item's Ferocity attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts.Common.Attributes
{
    using GW2DotNET.Common;

    /// <summary>Represents an item's Ferocity attribute.</summary>
    [TypeDiscriminator(Value = "CritDamage", BaseType = typeof(ItemAttribute))]
    public class Ferocity : ItemAttribute
    {
    }
}