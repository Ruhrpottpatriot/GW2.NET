// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitiveMap.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for World versus World maps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Contracts.Maps
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.WorldVersusWorld.Contracts.Common;
    using GW2DotNET.V1.WorldVersusWorld.Contracts.Maps.Bonuses;
    using GW2DotNET.V1.WorldVersusWorld.Contracts.Maps.Objectives;

    /// <summary>Provides the base class for World versus World maps.</summary>
    public abstract class CompetitiveMap : ServiceContract
    {
        /// <summary>Gets or sets the map's bonuses.</summary>
        [DataMember(Name = "bonuses")]
        public virtual MapBonusCollection Bonuses { get; set; }

        /// <summary>Gets or sets the map's objectives.</summary>
        [DataMember(Name = "objectives")]
        public virtual ObjectiveCollection Objectives { get; set; }

        /// <summary>Gets or sets the map's scoreboard.</summary>
        [DataMember(Name = "scores")]
        public virtual Scoreboard Scores { get; set; }
    }
}