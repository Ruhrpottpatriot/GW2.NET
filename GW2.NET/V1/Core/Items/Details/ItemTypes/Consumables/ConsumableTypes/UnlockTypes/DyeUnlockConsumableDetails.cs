// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DyeUnlockConsumableDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a dye.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Consumables.ConsumableTypes.UnlockTypes
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a dye.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class DyeUnlockConsumableDetails : UnlockConsumableDetails
    {
        /// <summary>Initializes a new instance of the <see cref="DyeUnlockConsumableDetails" /> class.</summary>
        public DyeUnlockConsumableDetails()
            : base(UnlockType.Dye)
        {
        }

        /// <summary>Gets or sets the dye's color ID.</summary>
        [JsonProperty("color_id", Order = 101)]
        public int ColorId { get; set; }
    }
}