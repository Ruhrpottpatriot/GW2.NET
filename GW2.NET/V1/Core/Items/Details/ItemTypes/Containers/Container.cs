// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Containers
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a container.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Container : Item
    {
        /// <summary>Infrastructure. Stores the item details.</summary>
        private ContainerDetails details;

        /// <summary>Initializes a new instance of the <see cref="Container" /> class.</summary>
        public Container()
            : base(ItemType.Container)
        {
        }

        /// <summary>Gets or sets the item details.</summary>
        [JsonProperty("container", Order = 100)]
        public ContainerDetails Details
        {
            get
            {
                return this.details;
            }

            set
            {
                this.details = value;
                value.Container = this;
            }
        }
    }
}