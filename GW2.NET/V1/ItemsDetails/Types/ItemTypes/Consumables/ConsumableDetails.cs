// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a consumable item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ItemsDetails.Types.ItemTypes.Consumables
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Types;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a consumable item.</summary>
    [JsonConverter(typeof(ConsumableDetailsConverter))]
    public abstract class ConsumableDetails : JsonObject, IEquatable<ConsumableDetails>
    {
        /// <summary>Infrastructure. Stores type information.</summary>
        private readonly ConsumableType type;

        /// <summary>Initializes a new instance of the <see cref="ConsumableDetails"/> class.</summary>
        /// <param name="type">The consumable's type.</param>
        protected ConsumableDetails(ConsumableType type)
        {
            this.type = type;
        }

        /// <summary>Gets or sets the consumable.</summary>
        public Consumable Consumable { get; set; }

        /// <summary>Gets the consumable's type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public ConsumableType Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(ConsumableDetails left, ConsumableDetails right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(ConsumableDetails left, ConsumableDetails right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(ConsumableDetails other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return object.Equals(this.Consumable, other.Consumable);
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current<see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
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

            return this.Equals((ConsumableDetails)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.Consumable != null ? this.Consumable.GetHashCode() : 0;
        }
    }
}