// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Unlocker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an unlock item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes
{
    using System.Runtime.Serialization;

    /// <summary>Represents detailed information about an unlock item.</summary>
    public abstract class Unlocker : Consumable
    {
        /// <summary>Initializes a new instance of the <see cref="Unlocker"/> class.</summary>
        /// <param name="type">The unlock item's unlock type.</param>
        protected Unlocker(UnlockType type)
            : base(ConsumableType.Unlock)
        {
            this.UnlockType = type;
        }

        /// <summary>Gets or sets the unlock item's unlock type.</summary>
        [DataMember(Name = "unlock_type")]
        protected UnlockType UnlockType { get; set; }
    }
}