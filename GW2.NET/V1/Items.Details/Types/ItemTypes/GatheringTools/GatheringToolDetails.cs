// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringToolDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a gathering tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Types.ItemTypes.GatheringTools
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Types;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a gathering tool.</summary>
    [JsonConverter(typeof(GatheringToolDetailsConverter))]
    public abstract class GatheringToolDetails : JsonObject, IEquatable<GatheringToolDetails>
    {
        /// <summary>Infrastructure. Stores type information.</summary>
        private readonly GatheringToolType type;

        /// <summary>Initializes a new instance of the <see cref="GatheringToolDetails"/> class.</summary>
        /// <param name="gatheringToolType">The gathering tool type.</param>
        protected GatheringToolDetails(GatheringToolType gatheringToolType)
        {
            this.type = gatheringToolType;
        }

        /// <summary>Gets or sets the gathering tool.</summary>
        public GatheringTool GatheringTool { get; set; }

        /// <summary>Gets the gathering tool's type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public GatheringToolType Type
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
        public static bool operator ==(GatheringToolDetails left, GatheringToolDetails right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(GatheringToolDetails left, GatheringToolDetails right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(GatheringToolDetails other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return object.Equals(this.GatheringTool, other.GatheringTool);
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

            return this.Equals((GatheringToolDetails)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.GatheringTool != null ? this.GatheringTool.GetHashCode() : 0;
        }
    }
}