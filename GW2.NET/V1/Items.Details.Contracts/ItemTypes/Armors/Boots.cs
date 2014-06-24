// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Boots.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents feet protection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Armors
{
    using GW2DotNET.Common;

    /// <summary>Represents feet protection.</summary>
    [TypeDiscriminator(Value = "Boots", BaseType = typeof(Armor))]
    public class Boots : Armor
    {
    }
}