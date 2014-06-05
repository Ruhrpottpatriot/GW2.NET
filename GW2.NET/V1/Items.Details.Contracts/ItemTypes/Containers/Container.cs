// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="GW2.NET Coding Team">
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
    public abstract class Container : Item
    {
        /// <summary>Initializes a new instance of the <see cref="Container"/> class.</summary>
        /// <param name="containerType">The container type.</param>
        protected Container(ContainerType containerType)
            : base(ItemType.Container)
        {
            this.ContainerType = containerType;
        }

        /// <summary>Gets or sets the container's type.</summary>
        [DataMember(Name = "container_type")]
        protected ContainerType ContainerType { get; set; }

        /// <summary>Gets the name of the property that provides additional information.</summary>
        /// <returns>The name of the property.</returns>
        protected override string GetTypeKey()
        {
            return "container";
        }
    }
}