// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DyeUnlockConsumableDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Consumables
{
    /// <summary>
    /// Represents detailed information about a dye.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class DyeUnlockConsumableDetails : UnlockConsumableDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DyeUnlockConsumableDetails"/> class.
        /// </summary>
        public DyeUnlockConsumableDetails()
            : base(UnlockType.Dye)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DyeUnlockConsumableDetails"/> class using the specified values.
        /// </summary>
        /// <param name="colorId">The dye's color ID.</param>
        public DyeUnlockConsumableDetails(int colorId)
            : base(UnlockType.Dye)
        {
            this.ColorId = colorId;
        }

        /// <summary>
        /// Gets or sets the dye's color ID.
        /// </summary>
        [JsonProperty("color_id", Order = 101)]
        public int ColorId { get; set; }
    }
}