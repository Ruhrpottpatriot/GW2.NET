// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemsInformation.Details.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Containers
{
    /// <summary>
    /// Represents a container.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class Container : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Container"/> class.
        /// </summary>
        public Container()
            : base(ItemType.Container)
        {
        }

        /// <summary>
        /// Gets or sets the container's details.
        /// </summary>
        [JsonProperty("container", Order = 100)]
        public ContainerItemDetails ContainerItemDetails { get; set; }
    }
}