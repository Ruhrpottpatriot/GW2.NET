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

    using Newtonsoft.Json;

    /// <summary>Represents a container.</summary>
    [JsonConverter(typeof(ContainerConverter))]
    public class Container : Item
    {
        /// <summary>Initializes a new instance of the <see cref="Container"/> class.</summary>
        /// <param name="containerType">The container type.</param>
        public Container(ContainerType containerType)
            : base(ItemType.Container, "container")
        {
            this.ContainerType = containerType;
        }

        /// <summary>Gets or sets the container's type.</summary>
        [DataMember(Name = "container_type")]
        protected ContainerType ContainerType { get; set; }
    }
}