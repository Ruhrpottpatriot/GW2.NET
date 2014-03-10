// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnlockConsumableDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an unlock item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Unlock
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about an unlock item.
    /// </summary>
    [JsonConverter(typeof(UnlockConsumableDetailsConverter))]
    public abstract class UnlockConsumableDetails : ConsumableDetails
    {
        /// <summary>Initializes a new instance of the <see cref="UnlockConsumableDetails"/> class.</summary>
        /// <param name="type">The unlock item's unlock type.</param>
        protected UnlockConsumableDetails(UnlockType type)
            : base(ConsumableType.Unlock)
        {
            this.UnlockType = type;
        }

        /// <summary>
        ///     Gets or sets the unlock item's unlock type.
        /// </summary>
        [JsonProperty("unlock_type", Order = 100)]
        public UnlockType UnlockType { get; set; }
    }
}