// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Containers
{
    /// <summary>
    /// Represents a container.
    /// </summary>
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
        /// Initializes a new instance of the <see cref="Container"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The container's ID.</param>
        /// <param name="name">The container's name.</param>
        /// <param name="description">The container's description.</param>
        /// <param name="type">The container's type.</param>
        /// <param name="level">The container's level.</param>
        /// <param name="rarity">The container's rarity.</param>
        /// <param name="vendorValue">The container's vendor value.</param>
        /// <param name="iconFileId">The container's icon ID.</param>
        /// <param name="iconFileSignature">The container's icon signature.</param>
        /// <param name="gameTypes">The container's game types.</param>
        /// <param name="flags">The container's additional flags.</param>
        /// <param name="restrictions">The container's restrictions.</param>
        /// <param name="containerDetails">The container's details.</param>
        public Container(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions, ContainerDetails containerDetails)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
            this.ContainerDetails = containerDetails;
        }

        /// <summary>
        /// Gets or sets the container's details.
        /// </summary>
        [JsonProperty("container", Order = 100)]
        public ContainerDetails ContainerDetails { get; set; }
    }
}