// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnlockConsumableItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemsInformation.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Consumables
{
    /// <summary>
    /// Represents detailed information about an unlock item.
    /// </summary>
    [JsonConverter(typeof(UnlockDetailsConverter))]
    public abstract class UnlockConsumableItemDetails : ConsumableItemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnlockConsumableItemDetails"/> class.
        /// </summary>
        /// <param name="type">The unlock item's unlock type.</param>
        protected UnlockConsumableItemDetails(UnlockType type)
            : base(ConsumableType.Unlock)
        {
            this.UnlockType = type;
        }

        /// <summary>
        /// Gets or sets the unlock item's unlock type.
        /// </summary>
        [JsonProperty("unlock_type", Order = 100)]
        public UnlockType UnlockType { get; set; }
    }
}