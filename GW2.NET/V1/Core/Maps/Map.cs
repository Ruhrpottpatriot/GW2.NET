// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map and its details, including details about floor and translation data on how to translate between
//   world coordinates and map coordinates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Core.Common;
    using GW2DotNET.V1.Core.Common.Converters;
    using GW2DotNET.V1.Core.Maps.Floors;

    using Newtonsoft.Json;

    /// <summary>Represents a map and its details, including details about floor and translation data on how to translate between world coordinates and map coordinates.</summary>
    public class Map : JsonObject, IEquatable<Map>, IComparable<Map>
    {
        /// <summary>Gets or sets the ID of the continent this map belongs to.</summary>
        [DataMember(Name = "continent_id", Order = 8)]
        public int ContinentId { get; set; }

        /// <summary>Gets or sets the name of the continent this map belongs to.</summary>
        [DataMember(Name = "continent_name", Order = 9)]
        public string ContinentName { get; set; }

        /// <summary>Gets or sets the dimensions of the map within the continent coordinate system.</summary>
        [DataMember(Name = "continent_rect", Order = 11)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle ContinentRectangle { get; set; }

        /// <summary>Gets or sets the default floor of this map.</summary>
        [DataMember(Name = "default_floor", Order = 4)]
        public int DefaultFloor { get; set; }

        /// <summary>Gets or sets a list of available floors for this map.</summary>
        [DataMember(Name = "floors", Order = 5)]
        public FloorCollection Floors { get; set; }

        /// <summary>Gets or sets the language info.</summary>
        [DataMember(Name = "lang", Order = 12)]
        public CultureInfo Language { get; set; }

        /// <summary>Gets or sets the map's ID.</summary>
        [DataMember(Name = "map_id", Order = 0)]
        public int MapId { get; set; }

        /// <summary>Gets or sets the map name.</summary>
        [DataMember(Name = "map_name", Order = 1)]
        public string MapName { get; set; }

        /// <summary>Gets or sets the dimensions of the map.</summary>
        [DataMember(Name = "map_rect", Order = 10)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle MapRectangle { get; set; }

        /// <summary>Gets or sets the maximum level of this map.</summary>
        [DataMember(Name = "max_level", Order = 3)]
        public int MaximumLevel { get; set; }

        /// <summary>Gets or sets the minimum level of this map.</summary>
        [DataMember(Name = "min_level", Order = 2)]
        public int MinimumLevel { get; set; }

        /// <summary>Gets or sets the ID of the region this map belongs to.</summary>
        [DataMember(Name = "region_id", Order = 6)]
        public int RegionId { get; set; }

        /// <summary>Gets or sets the name of the region this map belongs to.</summary>
        [DataMember(Name = "region_name", Order = 7)]
        public string RegionName { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Map left, Map right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Map left, Map right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than<paramref name="other"/>.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(Map other)
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
        public bool Equals(Map other)
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

            return this.Equals((Map)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.MapId;
        }
    }
}