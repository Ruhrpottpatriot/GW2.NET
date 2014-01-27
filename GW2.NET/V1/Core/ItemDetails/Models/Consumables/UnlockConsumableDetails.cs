// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnlockConsumableDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Consumables
{
    /// <summary>
    /// Represents detailed information about an unlock item.
    /// </summary>
    [JsonConverter(typeof(UnlockDetailsConverter))]
    public class UnlockConsumableDetails : ConsumableDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnlockConsumableDetails"/> class.
        /// </summary>
        public UnlockConsumableDetails()
            : base(ConsumableType.Unlock)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnlockConsumableDetails"/> class using the specified values.
        /// </summary>
        /// <param name="type">The unlock item's unlock type.</param>
        public UnlockConsumableDetails(UnlockType type)
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