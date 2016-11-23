// --------------------------------------------------------------------------------------------------------------------
// <copyright file="World.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a world and its localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Worlds
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;

    /// <summary>Represents a world and its localized name and demographics.</summary>
    public class World : IEquatable<World>, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public virtual CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the name of the world.</summary>
        public virtual string Name { get; set; }

        /// <summary>Gets or sets the world identifier.</summary>
        public virtual int WorldId { get; set; }

        /// <summary>Gets or sets an indication of the world's population.</summary>
        public virtual Population Population { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(World left, World right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(World left, World right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(World other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.WorldId == other.WorldId;
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

            return this.Equals((World)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.WorldId;
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var name = this.Name;
            if (name != null)
            {
                return name;
            }

            return this.WorldId.ToString(NumberFormatInfo.InvariantInfo);
        }

        public string AbbreviatedName
        {
            get
            {
                string name;
                if (AbbreviatedNames.TryGetValue(this.WorldId, out name))
                {
                    return name;
                }
                return this.Name;
            }
        }

        private static readonly Dictionary<int, string> AbbreviatedNames = new System.Collections.Generic.Dictionary<int, string>(64)
        {
            { 1001, "AR" },
            { 1002, "BP" },
            { 1003, "YB" },
            { 1004, "HOD" },
            { 1005, "MAG" },
            { 1006, "SF" },
            { 1007, "GOM" },
            { 1008, "JQ" },
            { 1009, "FA" },
            { 1010, "EB" },
            { 1011, "SBI" },
            { 1012, "DH" },
            { 1013, "SOR" },
            { 1014, "CD" },
            { 1015, "IOJ" },
            { 1016, "SOS" },
            { 1017, "TC" },
            { 1018, "NSP" },
            { 1019, "BG" },
            { 1020, "FC" },
            { 1021, "DB" },
            { 1022, "KAIN" },
            { 1023, "DR" },
            { 1024, "ET" },
            { 2001, "FOW" },
            { 2002, "DESO" },
            { 2003, "GAND" },
            { 2004, "BT" },
            { 2005, "ROF" },
            { 2006, "UW" },
            { 2007, "FSP" },
            { 2008, "WR" },
            { 2009, "ROS" },
            { 2010, "SR" },
            { 2011, "VB" },
            { 2012, "PS" },
            { 2013, "AG" },
            { 2014, "GH" },
            { 2101, "JS" },
            { 2102, "FR" },
            { 2103, "AGR" },
            { 2104, "VS" },
            { 2105, "AS" },
            { 2201, "KOD" },
            { 2202, "RIV" },
            { 2203, "ER" },
            { 2204, "AM" },
            { 2205, "DL" },
            { 2206, "MS" },
            { 2207, "DZ" },
            { 2301, "BB" }
        };
    }
}