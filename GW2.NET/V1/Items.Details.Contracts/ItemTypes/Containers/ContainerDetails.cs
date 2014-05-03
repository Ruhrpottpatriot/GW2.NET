// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Containers
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a container.</summary>
    [JsonConverter(typeof(ContainerDetailsConverter))]
    public abstract class ContainerDetails : ItemDetails
    {
        /// <summary>Initializes a new instance of the <see cref="ContainerDetails"/> class.</summary>
        /// <param name="containerType">The container type.</param>
        protected ContainerDetails(ContainerType containerType)
        {
            this.Type = containerType;
        }

        /// <summary>Gets the container's type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public ContainerType Type { get; private set; }
    }
}