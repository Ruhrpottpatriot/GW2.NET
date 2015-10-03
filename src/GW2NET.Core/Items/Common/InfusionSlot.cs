// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlot.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents one of an item's infusion slots.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    /// <summary>Represents one of an item's infusion slots.</summary>
    public class InfusionSlot
    {
        /// <summary>Gets or sets the infusion slot's type(s).</summary>
        public virtual InfusionSlotFlags Flags { get; set; }

        /// <summary>Gets or sets the infusion slot's item. This is a navigation property. Use the value of <see cref="ItemId"/> to obtain a reference.</summary>
        public virtual Item Item { get; set; }

        /// <summary>Gets or sets the infusion slot's item identifier.</summary>
        public virtual int? ItemId { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.Flags.ToString();
        }
    }
}