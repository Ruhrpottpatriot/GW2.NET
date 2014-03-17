// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppearanceChangeConsumableDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an appearance changing consumable item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Consumables.ConsumableTypes
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about an appearance changing consumable item.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class AppearanceChangeConsumableDetails : ConsumableDetails
    {
        /// <summary>Initializes a new instance of the <see cref="AppearanceChangeConsumableDetails" /> class.</summary>
        public AppearanceChangeConsumableDetails()
            : base(ConsumableType.AppearanceChange)
        {
        }
    }
}