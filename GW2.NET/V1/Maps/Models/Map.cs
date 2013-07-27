// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Map type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Maps.Models
{
    using Newtonsoft.Json;

    /// <summary>Represents a map.</summary>
    public partial class Map
    {
        /// <summary>Gets the continent id.</summary>
        [JsonProperty("continent_id")]
        internal int ContinentId;

        /// <summary>Initializes a new instance of the <see cref="Map"/> class.</summary>
        /// <param name="mapId">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="minimumLevel">The minimum level.</param>
        /// <param name="maximumLevel">The maximum level.</param>
        /// <param name="defaultFloor">The default floor.</param>
        /// <param name="floors">The floors.</param>
        /// <param name="regionId">The region id.</param>
        /// <param name="regionName">The region name.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="mapRectangle">The map rectangle.</param>
        /// <param name="continentRectangle">The continent rectangle.</param>
        /// <param name="pointsOfInterest">The points Of Interest.</param>
        /// <param name="tasks">The tasks.</param>
        /// <param name="sectors">The sectors.</param>
        /// <param name="skillChallenges">The skill Challenges.</param>
        [JsonConstructor]
        public Map(int mapId, string name, int minimumLevel, int maximumLevel, int defaultFloor, int[] floors, int regionId, string regionName, int continentId, float[,] mapRectangle, float[,] continentRectangle, IEnumerable<PointOfInterest> pointsOfInterest, IEnumerable<Task> tasks, IEnumerable<Sector> sectors, IEnumerable<SkillChallenge> skillChallenges)

        {
            this.MaximumLevel = maximumLevel;
            this.MinimumLevel = minimumLevel;
            this.Name = name;
            this.Id = mapId;
            this.ContinentRectangle = continentRectangle;
            this.MapRectangle = mapRectangle;
            this.ContinentId = continentId;
            this.SkillChallenges = skillChallenges;
            this.Sectors = sectors;
            this.Tasks = tasks;
            this.PointsOfInterest = pointsOfInterest;
            this.RegionName = regionName;
            this.RegionId = regionId;
            this.Floors = floors;
            this.DefaultFloor = defaultFloor;
        }

        /// <summary>Gets the id.</summary>
        public int Id
        {
            get;
            private set;
        }

        /// <summary>Gets the name.</summary>
        [JsonProperty("map_name")]
        public string Name
        {
            get;
            private set;
        }

        /// <summary>Gets the minimum level.</summary>
        [JsonProperty("min_level")]
        public int MinimumLevel
        {
            get;
            private set;
        }

        /// <summary>Gets the maximum level.</summary>
        [JsonProperty("max_level")]
        public int MaximumLevel
        {
            get;
            private set;
        }

        /// <summary>Gets the default floor.</summary>
        [JsonProperty("default_floor")]
        public int DefaultFloor
        {
            get;
            private set;
        }

        /// <summary>Gets the floors.</summary>
        [JsonProperty("floors")]
        public int[] Floors
        {
            get;
            private set;
        }

        /// <summary>Gets the region id.</summary>
        [JsonProperty("region_id")]
        public int RegionId
        {
            get;
            private set;
        }

        /// <summary>Gets the region name.</summary>
        [JsonProperty("region_name")]
        public string RegionName
        {
            get;
            private set;
        }

        /// <summary>Gets the continent.</summary>
        public Continent Continent
        {
            get;
            private set;
        }

        /// <summary>Gets the map rectangle.</summary>
        [JsonProperty("map_rect")]
        public float[,] MapRectangle
        {
            get;
            private set;
        }

        /// <summary>Gets the continent rectangle.</summary>
        [JsonProperty("continent_rect")]
        public float[,] ContinentRectangle
        {
            get;
            private set;
        }

        /// <summary>Gets the points of interest.</summary>
        [JsonProperty("points_of_interest")]
        public IEnumerable<PointOfInterest> PointsOfInterest
        {
            get;
            private set;
        }

        /// <summary>Gets the tasks.</summary>
        [JsonProperty("tasks")]
        public IEnumerable<Task> Tasks
        {
            get;
            private set;
        }

        /// <summary>Gets the sectors.</summary>
        [JsonProperty("sectors")]
        public IEnumerable<Sector> Sectors
        {
            get;
            private set;
        }

        /// <summary>Gets the skill challenges.</summary>
        [JsonProperty("skill_challenges")]
        public IEnumerable<SkillChallenge> SkillChallenges
        {
            get;
            private set;
        }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="Map"/> are equal.
        /// </summary>
        /// <param name="mapA">The first object to compare.</param>param>
        /// <param name="mapB">The second object to compare. </param>
        /// <returns>true if mapA and mapB represent the same map; otherwise, false.</returns>
        public static bool operator ==(Map mapA, Map mapB)
        {
            return mapA.Id == mapB.Id;
        }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="Map"/> are not equal.
        /// </summary>
        /// <param name="mapA">The first object to compare.</param>param>
        /// <param name="mapB">The second object to compare. </param>
        /// <returns>true if mapA and mapB do not represent the same map; otherwise, false.</returns>
        public static bool operator !=(Map mapA, Map mapB)
        {
            return !(mapA == mapB);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="obj">Another object to compare to.</param>
        public override bool Equals(object obj)
        {
            return obj is Map && this == (Map)obj;
        }

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="Map"/> are equal.
        /// </summary>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="obj">Another object to compare to. </param>
        public bool Equals(Map obj)
        {
            return this.Id == obj.Id;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>Resolves the id for the map.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Map"/> with a resolved id.</returns>
        internal Map ResolveId(int id)
        {
            this.Id = id;

            return this;
        }

        /// <summary>Resolves a continent by its id.</summary>
        /// <param name="continent">The continent.</param>
        /// <returns>The <see cref="Map"/>.</returns>
        internal Map ResolveContinent(Continent continent)
        {
            this.Continent = continent;

            return this;
        }
    }
}
