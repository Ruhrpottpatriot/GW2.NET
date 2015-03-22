// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the map object from the api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents the map object from the api.</summary>
    [DataContract]
    internal sealed class MapDataContract
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name", Order = 0)]
        internal string Name { get; set; }

        /// <summary>
        /// Gets or sets the minimum level.
        /// </summary>
        [DataMember(Name = "min_level", Order = 1)]
        internal int MinimumLevel { get; set; }

        /// <summary>
        /// Gets or sets the maximum level.
        /// </summary>
        [DataMember(Name = "max_level", Order = 2)]
        internal int MaximumLevel { get; set; }

        /// <summary>
        /// Gets or sets the default floor.
        /// </summary>
        [DataMember(Name = "default_floor", Order = 3)]
        internal int DefaultFloor { get; set; }

        /// <summary>
        /// Gets or sets the map rectangle.
        /// </summary>
        [DataMember(Name = "map_rect", Order = 4)]
        internal double[][] MapRectangle { get; set; }

        /// <summary>
        /// Gets or sets the continent rectangle.
        /// </summary>
        [DataMember(Name = "continent_rect", Order = 5)]
        internal double[][] ContinentRectangle { get; set; }

        /// <summary>
        /// Gets or sets the points of interest.
        /// </summary>
        [DataMember(Name = "points_of_interest", Order = 6)]
        internal ICollection<PointOfInterestDataContract> PointsOfInterest { get; set; }

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        [DataMember(Name = "tasks", Order = 7)]
        internal ICollection<TaskDataContract> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the skill challenges.
        /// </summary>
        [DataMember(Name = "skill_challenges", Order = 8)]
        internal ICollection<SkillChallengeDataContract> SkillChallenges { get; set; }

        /// <summary>
        /// Gets or sets the sectors.
        /// </summary>
        [DataMember(Name = "sectors", Order = 9)]
        internal ICollection<SectorDataContract> Sectors { get; set; }
    }
}