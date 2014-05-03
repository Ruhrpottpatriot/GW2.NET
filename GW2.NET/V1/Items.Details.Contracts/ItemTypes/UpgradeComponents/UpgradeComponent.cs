// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an upgrade component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents an upgrade component.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class UpgradeComponent : Item
    {
        /// <summary>Initializes a new instance of the <see cref="UpgradeComponent" /> class.</summary>
        public UpgradeComponent()
            : base(ItemType.UpgradeComponent)
        {
        }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "upgrade_component", Order = 100)]
        [JsonConverter(typeof(UpgradeComponentDetailsConverter))]
        public new UpgradeComponentDetails Details
        {
            get
            {
                return base.Details as UpgradeComponentDetails;
            }

            set
            {
                base.Details = value;
            }
        }
    }
}