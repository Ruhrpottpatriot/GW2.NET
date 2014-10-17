// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitiveMapContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World versus World map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents a World versus World map.</summary>
    [DataContract]
    public sealed class CompetitiveMapContract
    {
        /// <summary>Gets or sets the map's bonuses.</summary>
        [DataMember(Name = "bonuses", Order = 3)]
        public ICollection<MapBonusContract> Bonuses { get; set; }

        /// <summary>Gets or sets the map's objectives.</summary>
        [DataMember(Name = "objectives", Order = 2)]
        public ICollection<ObjectiveContract> Objectives { get; set; }

        /// <summary>Gets or sets the map's scoreboard.</summary>
        [DataMember(Name = "scores", Order = 1)]
        public int[] Scores { get; set; }

        /// <summary>Gets or sets the map type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }
    }
}