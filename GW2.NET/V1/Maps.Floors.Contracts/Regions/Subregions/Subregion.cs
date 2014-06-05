// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Subregion.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map and its details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Floors.Contracts.Regions.Subregions
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Contracts;
    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Maps.Floors.Contracts.Regions.Subregions.PointsOfInterest;
    using GW2DotNET.V1.Maps.Floors.Contracts.Regions.Subregions.Sectors;
    using GW2DotNET.V1.Maps.Floors.Contracts.Regions.Subregions.SkillChallenges;
    using GW2DotNET.V1.Maps.Floors.Contracts.Regions.Subregions.Tasks;

    using Newtonsoft.Json;

    /// <summary>Represents a map and its details.</summary>
    public class Subregion : JsonObject, IEquatable<Subregion>, IComparable<Subregion>
    {
        /// <summary>Gets or sets the dimensions of the map within the continent coordinate system.</summary>
        [DataMember(Name = "continent_rect", Order = 6)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle ContinentRectangle { get; set; }

        /// <summary>Gets or sets the default floor of this map.</summary>
        [DataMember(Name = "default_floor", Order = 4)]
        public int DefaultFloor { get; set; }

        /// <summary>Gets or sets the map's ID.</summary>
        [DataMember(Name = "map_id", Order = 0)]
        public int MapId { get; set; }

        /// <summary>Gets or sets the dimensions of the map.</summary>
        [DataMember(Name = "map_rect", Order = 5)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle MapRectangle { get; set; }

        /// <summary>Gets or sets the maximum level of this map.</summary>
        [DataMember(Name = "max_level", Order = 3)]
        public int MaximumLevel { get; set; }

        /// <summary>Gets or sets the minimum level of this map.</summary>
        [DataMember(Name = "min_level", Order = 2)]
        public int MinimumLevel { get; set; }

        /// <summary>Gets or sets the map's name.</summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>Gets or sets a collection of Points of Interest locations.</summary>
        [DataMember(Name = "points_of_interest", Order = 7)]
        public PointOfInterestCollection PointsOfInterest { get; set; }

        /// <summary>Gets or sets a collection of areas within the map.</summary>
        [DataMember(Name = "sectors", Order = 10)]
        public SectorCollection Sectors { get; set; }

        /// <summary>Gets or sets a collection of skill challenge locations.</summary>
        [DataMember(Name = "skill_challenges", Order = 9)]
        public SkillChallengeCollection SkillChallenges { get; set; }

        /// <summary>Gets or sets a collection of renown heart locations.</summary>
        [DataMember(Name = "tasks", Order = 8)]
        public RenownTaskCollection Tasks { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Subregion left, Subregion right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Subregion left, Subregion right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than<paramref name="other"/>.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(Subregion other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.MapId.CompareTo(other.MapId);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Subregion other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.MapId == other.MapId;
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current<see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Subregion)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.MapId;
        }
    }
}