// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapBonus.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for World versus World map bonuses.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.WorldVersusWorld
{
    /// <summary>Provides the base class for World versus World map bonuses.</summary>
    public abstract class MapBonus
    {
        /// <summary>Gets or sets the team that holds the bonus.</summary>
        public virtual TeamColor Owner { get; set; }
    }
}