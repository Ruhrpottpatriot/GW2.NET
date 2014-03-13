// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an upgrade component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.UpgradeComponents
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents an upgrade component.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class UpgradeComponent : Item
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UpgradeComponent" /> class.
        /// </summary>
        public UpgradeComponent()
            : base(ItemType.UpgradeComponent)
        {
        }

        /// <summary>
        ///     Gets or sets the upgrade component's details.
        /// </summary>
        [JsonProperty("upgrade_component", Order = 100)]
        public UpgradeComponentDetails UpgradeComponentDetails { get; set; }
    }
}