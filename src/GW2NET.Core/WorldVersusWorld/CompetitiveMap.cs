// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitiveMap.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
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
        /// <summary>Gets or sets the map's id.</summary>
        public virtual int Id { get; set; }

        /// <summary>Gets or sets the map's type.</summary>
        public virtual string Type { get; set; }

        private static readonly MapBonus[] EmptyBonuses = new MapBonus[0];

        private ICollection<MapBonus> bonuses = EmptyBonuses;

        private static readonly MatchObjective[] EmptyObjectives = new MatchObjective[0];

        private ICollection<MatchObjective> objectives;

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
        public virtual ICollection<MatchObjective> Objectives
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

        /// <summary>Gets or sets the map's kills.</summary>
        public virtual Scoreboard Kills { get; set; }

        /// <summary>Gets or sets the map's deaths.</summary>
        public virtual Scoreboard Deaths { get; set; }
    }
}