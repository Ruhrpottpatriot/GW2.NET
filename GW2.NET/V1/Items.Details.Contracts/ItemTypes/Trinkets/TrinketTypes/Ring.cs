// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ring.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a ring.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trinkets.TrinketTypes
{
    /// <summary>Represents detailed information about a ring.</summary>
    public class Ring : Trinket
    {
        /// <summary>Initializes a new instance of the <see cref="Ring" /> class.</summary>
        public Ring()
            : base(TrinketType.Ring)
        {
        }
    }
}