// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an upgrade component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ItemsDetails.Types.ItemTypes.UpgradeComponents
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents an upgrade component.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class UpgradeComponent : Item
    {
        /// <summary>Infrastructure. Stores the item details.</summary>
        private UpgradeComponentDetails details;

        /// <summary>Initializes a new instance of the <see cref="UpgradeComponent" /> class.</summary>
        public UpgradeComponent()
            : base(ItemType.UpgradeComponent)
        {
        }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "upgrade_component", Order = 100)]
        public UpgradeComponentDetails Details
        {
            get
            {
                return this.details;
            }

            set
            {
                this.details = value;
                value.UpgradeComponent = this;
            }
        }
    }
}