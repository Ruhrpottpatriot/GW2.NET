// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractNpc.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a contract NPC.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes
{
    using GW2DotNET.Common;

    /// <summary>Represents a contract NPC.</summary>
    [TypeDiscriminator(Value = "ContractNpc", BaseType = typeof(Consumable))]
    public class ContractNpc : Consumable
    {
    }
}