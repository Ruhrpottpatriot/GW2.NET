// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BagSlotUnlocker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a bag slot unlock item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes.UnlockTypes
{
    /// <summary>Represents detailed information about a bag slot unlock item.</summary>
    public class BagSlotUnlocker : Unlocker
    {
        /// <summary>Initializes a new instance of the <see cref="BagSlotUnlocker" /> class.</summary>
        public BagSlotUnlocker()
            : base(UnlockType.BagSlot)
        {
        }
    }
}