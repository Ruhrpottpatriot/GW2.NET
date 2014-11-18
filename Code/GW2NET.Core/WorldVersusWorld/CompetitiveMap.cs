// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitiveMap.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for World versus World maps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.WorldVersusWorld
{
    using System.Collections.Generic;

    /// <summary>Provides the base class for World versus World maps.</summary>
    public abstract class CompetitiveMap
    {
        /// <summary>Gets or sets the map's bonuses.</summary>
        public virtual ICollection<MapBonus> Bonuses { get; set; }

        /// <summary>Gets or sets the map's objectives.</summary>
        public virtual ICollection<Objective> Objectives { get; set; }

        /// <summary>Gets or sets the map's scoreboard.</summary>
        public virtual Scoreboard Scores { get; set; }
    }
}