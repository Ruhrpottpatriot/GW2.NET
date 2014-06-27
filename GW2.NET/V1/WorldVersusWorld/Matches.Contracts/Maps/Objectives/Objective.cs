// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Objective.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents one of a World versus World map's objectives.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches.Contracts.Maps.Objectives
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Guilds.Contracts;
    using GW2DotNET.V1.WorldVersusWorld.Matches.Contracts.Common;

    using Newtonsoft.Json;

    /// <summary>Represents one of a World versus World map's objectives.</summary>
    public class Objective : ServiceContract, IEquatable<Objective>
    {
        /// <summary>Gets or sets the objective identifier.</summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>Gets or sets the name of the objective.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the current owner.</summary>
        [DataMember(Name = "owner")]
        public TeamColor Owner { get; set; }

        /// <summary>Gets or sets the guild currently claiming the objective.</summary>
        [DataMember(Name = "owner_guild")]
        [JsonConverter(typeof(UnknownGuildConverter))]
        public Guild OwnerGuild { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Objective left, Objective right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Objective left, Objective right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Objective other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Id == other.Id;
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

            return this.Equals((Objective)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.Id;
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

            return this.Id.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}