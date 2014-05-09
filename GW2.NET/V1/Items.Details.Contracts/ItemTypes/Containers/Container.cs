// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Containers
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a container.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Container : Item
    {
        /// <summary>Initializes a new instance of the <see cref="Container" /> class.</summary>
        public Container()
            : base(ItemType.Container)
        {
        }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "container", Order = 100)]
        [JsonConverter(typeof(ContainerDetailsConverter))]
        public new virtual ContainerDetails Details
        {
            get
            {
                return base.Details as ContainerDetails;
            }

            set
            {
                base.Details = value;
            }
        }
    }
}