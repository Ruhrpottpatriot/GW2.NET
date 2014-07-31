// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubregionContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map and its details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a map and its details.</summary>
    public sealed class SubregionContract : ServiceContract
    {
        /// <summary>Gets or sets the dimensions of the map within the continent coordinate system.</summary>
        [DataMember(Name = "continent_rect", Order = 5)]
        public double[][] ContinentRectangle { get; set; }

        /// <summary>Gets or sets the default floor of this map.</summary>
        [DataMember(Name = "default_floor", Order = 3)]
        public int DefaultFloor { get; set; }

        /// <summary>Gets or sets the dimensions of the map.</summary>
        [DataMember(Name = "map_rect", Order = 4)]
        public double[][] MapRectangle { get; set; }

        /// <summary>Gets or sets the maximum level of this map.</summary>
        [DataMember(Name = "max_level", Order = 2)]
        public int MaximumLevel { get; set; }

        /// <summary>Gets or sets the minimum level of this map.</summary>
        [DataMember(Name = "min_level", Order = 1)]
        public int MinimumLevel { get; set; }

        /// <summary>Gets or sets the name of the map.</summary>
        [DataMember(Name = "name", Order = 0)]
        public string Name { get; set; }

        /// <summary>Gets or sets a collection of Points of Interest locations.</summary>
        [DataMember(Name = "points_of_interest", Order = 6)]
        public ICollection<PointOfInterestContract> PointsOfInterest { get; set; }

        /// <summary>Gets or sets a collection of areas within the map.</summary>
        [DataMember(Name = "sectors", Order = 9)]
        public ICollection<SectorContract> Sectors { get; set; }

        /// <summary>Gets or sets a collection of skill challenge locations.</summary>
        [DataMember(Name = "skill_challenges", Order = 8)]
        public ICollection<SkillChallengeContract> SkillChallenges { get; set; }

        /// <summary>Gets or sets a collection of renown heart locations.</summary>
        [DataMember(Name = "tasks", Order = 7)]
        public ICollection<RenownTaskContract> Tasks { get; set; }
    }
}