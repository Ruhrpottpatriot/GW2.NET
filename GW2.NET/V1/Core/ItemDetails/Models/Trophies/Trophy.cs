// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trophy.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Trophies
{
    /// <summary>
    /// Represents a trophy.
    /// </summary>
    public class Trophy : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trophy"/> class.
        /// </summary>
        public Trophy()
            : base(ItemType.Trophy)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trophy"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The trophy's ID.</param>
        /// <param name="name">The trophy's name.</param>
        /// <param name="description">The trophy's description.</param>
        /// <param name="type">The trophy's type.</param>
        /// <param name="level">The trophy's level.</param>
        /// <param name="rarity">The trophy's rarity.</param>
        /// <param name="vendorValue">The trophy's vendor value.</param>
        /// <param name="iconFileId">The trophy's icon ID.</param>
        /// <param name="iconFileSignature">The trophy's icon signature.</param>
        /// <param name="gameTypes">The trophy's game types.</param>
        /// <param name="flags">The trophy's additional flags.</param>
        /// <param name="restrictions">The trophy's restrictions.</param>
        public Trophy(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
        }
    }
}