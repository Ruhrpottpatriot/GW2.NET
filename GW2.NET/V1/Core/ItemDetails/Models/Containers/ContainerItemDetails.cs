// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Containers
{
    /// <summary>
    /// Represents detailed information about a container.
    /// </summary>
    public class ContainerItemDetails : Common.ItemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerItemDetails"/> class.
        /// </summary>
        public ContainerItemDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerItemDetails"/> class using the specified values.
        /// </summary>
        /// <param name="type">The container's type.</param>
        public ContainerItemDetails(ContainerType type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets the container's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public ContainerType Type { get; set; }
    }
}