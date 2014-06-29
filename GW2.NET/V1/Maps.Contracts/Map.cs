// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map and its details, including details about floor and translation data on how to translate between world coordinates and map coordinates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a map and its details, including details about floor and translation data on how to translate between world coordinates and map coordinates.</summary>
    public class Map : ServiceContract, IEquatable<Map>
    {
        /// <summary>Gets or sets the continent identifier of the continent that this map belongs to.</summary>
        [DataMember(Name = "continent_id")]
        public int ContinentId { get; set; }

        /// <summary>Gets or sets the name of the continent that this map belongs to.</summary>
        [DataMember(Name = "continent_name")]
        public string ContinentName { get; set; }

        /// <summary>Gets or sets the dimensions of the map within the continent coordinate system.</summary>
        [DataMember(Name = "continent_rect")]
        public Rectangle ContinentRectangle { get; set; }

        /// <summary>Gets or sets the default floor of this map.</summary>
        [DataMember(Name = "default_floor")]
        [JsonConverter(typeof(UnknownFloorConverter))]
        public Floor DefaultFloor { get; set; }

        /// <summary>Gets or sets a list of available floors for this map.</summary>
        [DataMember(Name = "floors")]
        public FloorCollection Floors { get; set; }

        /// <summary>Gets or sets the language.</summary>
        [DataMember(Name = "lang")]
        public string Language { get; set; }

        /// <summary>Gets or sets the map identifier.</summary>
        [DataMember(Name = "map_id")]
        public int MapId { get; set; }

        /// <summary>Gets or sets the name of the map.</summary>
        [DataMember(Name = "map_name")]
        public string MapName { get; set; }

        /// <summary>Gets or sets the dimensions of the map.</summary>
        [DataMember(Name = "map_rect")]
        public Rectangle MapRectangle { get; set; }

        /// <summary>Gets or sets the maximum level of this map.</summary>
        [DataMember(Name = "max_level")]
        public int MaximumLevel { get; set; }

        /// <summary>Gets or sets the minimum level of this map.</summary>
        [DataMember(Name = "min_level")]
        public int MinimumLevel { get; set; }

        /// <summary>Gets or sets the region identifier of the region that this map belongs to.</summary>
        [DataMember(Name = "region_id")]
        public int RegionId { get; set; }

        /// <summary>Gets or sets the name of the region that this map belongs to.</summary>
        [DataMember(Name = "region_name")]
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

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            var name = this.MapName;
            if (name != null)
            {
                return name;
            }

            return this.MapId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}