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
    using System.Diagnostics;

    /// <summary>Provides the base class for World versus World maps.</summary>
    public abstract class CompetitiveMap
    {
        private static readonly MapBonus[] EmptyBonuses = new MapBonus[0];

        private ICollection<MapBonus> bonuses = EmptyBonuses;

        private static readonly Objective[] EmptyObjectives = new Objective[0];

        private ICollection<Objective> objectives;

        /// <summary>Gets or sets the map's bonuses.</summary>
        public virtual ICollection<MapBonus> Bonuses
        {
            get
            {
                Debug.Assert(this.bonuses != null, "this.bonuses != null");
                return this.bonuses;
            }
            set
            {
                this.bonuses = value ?? EmptyBonuses;
            }
        }

        /// <summary>Gets or sets the map's objectives.</summary>
        public virtual ICollection<Objective> Objectives
        {
            get
            {
                Debug.Assert(this.objectives != null, "this.objectives != null");
                return this.objectives;
            }
            set
            {
                this.objectives = value ?? EmptyObjectives;
            }
        }

        /// <summary>Gets or sets the map's scoreboard.</summary>
        public virtual Scoreboard Scores { get; set; }
    }
}
