// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.BackPieces
{
    /// <summary>
    /// Represents detailed information about a back piece.
    /// </summary>
    public class BackDetails : EquipmentDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BackDetails"/> class.
        /// </summary>
        public BackDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BackDetails"/> class.
        /// </summary>
        /// <param name="infusionSlots">The back piece's infusion slots.</param>
        /// <param name="infixUpgrade">The back piece's infix upgrade.</param>
        /// <param name="suffixItemId">The back piece's suffix item ID.</param>
        public BackDetails(IEnumerable<InfusionSlot> infusionSlots, InfixUpgrade infixUpgrade, int? suffixItemId)
            : base(infusionSlots, infixUpgrade, suffixItemId)
        {
        }
    }
}