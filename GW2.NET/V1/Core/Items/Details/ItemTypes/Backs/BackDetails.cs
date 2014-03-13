// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a back piece.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Backs
{
    using GW2DotNET.V1.Core.Items.Details.ItemTypes.Common;

    /// <summary>
    ///     Represents detailed information about a back piece.
    /// </summary>
    public class BackDetails : EquipmentDetails
    {
        /// <summary>Gets or sets the back.</summary>
        public Back Back { get; set; }
    }
}