// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HalloweenConsumable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a halloween consumable item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes
{
    /// <summary>Represents detailed information about a halloween consumable item.</summary>
    public class HalloweenConsumable : Consumable
    {
        /// <summary>Initializes a new instance of the <see cref="HalloweenConsumable" /> class.</summary>
        public HalloweenConsumable()
            : base(ConsumableType.Halloween)
        {
        }
    }
}