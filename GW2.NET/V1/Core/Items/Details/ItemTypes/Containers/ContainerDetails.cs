// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Containers
{
    using GW2DotNET.V1.Core.Common;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a container.
    /// </summary>
    [JsonConverter(typeof(ContainerDetailsConverter))]
    public abstract class ContainerDetails : JsonObject
    {
        /// <summary>Initializes a new instance of the <see cref="ContainerDetails"/> class.</summary>
        /// <param name="containerType">The container type.</param>
        protected ContainerDetails(ContainerType containerType)
        {
            this.Type = containerType;
        }

        /// <summary>
        ///     Gets or sets the container's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public ContainerType Type { get; set; }
    }
}