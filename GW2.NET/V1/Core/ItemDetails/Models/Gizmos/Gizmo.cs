// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gizmo.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Gizmos
{
    /// <summary>
    /// Represents a gizmo.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class Gizmo : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gizmo"/> class.
        /// </summary>
        public Gizmo()
            : base(ItemType.Gizmo)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Gizmo"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The gizmo's ID.</param>
        /// <param name="name">The gizmo's name.</param>
        /// <param name="description">The gizmo's description.</param>
        /// <param name="type">The gizmo's type.</param>
        /// <param name="level">The gizmo's level.</param>
        /// <param name="rarity">The gizmo's rarity.</param>
        /// <param name="vendorValue">The gizmo's vendor value.</param>
        /// <param name="iconFileId">The gizmo's icon ID.</param>
        /// <param name="iconFileSignature">The gizmo's icon signature.</param>
        /// <param name="gameTypes">The gizmo's game types.</param>
        /// <param name="flags">The gizmo's additional flags.</param>
        /// <param name="restrictions">The gizmo's restrictions.</param>
        /// <param name="gizmoItemDetails">The gizmo's details.</param>
        public Gizmo(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions, GizmoItemDetails gizmoItemDetails)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
            this.GizmoItemDetails = gizmoItemDetails;
        }

        /// <summary>
        /// Gets or sets the gizmo's details.
        /// </summary>
        [JsonProperty("gizmo", Order = 100)]
        public GizmoItemDetails GizmoItemDetails { get; set; }
    }
}