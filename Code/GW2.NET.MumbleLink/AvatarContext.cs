// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AvatarContext.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides contextual data about a player's avatar. Check the <see cref="AvatarContext" /> of two different players for equality to determine if the players are in the same map instance.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.MumbleLink
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    /// <summary>Provides contextual data about a player's avatar. Check the <see cref="AvatarContext"/> of two different players for equality to determine if the players are in the same map instance.</summary>
    public sealed class AvatarContext : IEquatable<AvatarContext>
    {
        /// <summary>Gets or sets the game client's build identifier.</summary>
        public int BuildId { get; set; }

        /// <summary>Gets or sets the instance identifier of the current instance.</summary>
        public int Instance { get; set; }

        /// <summary>Gets or sets the identifier of the current map.</summary>
        public int MapId { get; set; }

        /// <summary>Gets or sets the type of the current map.</summary>
        public int MapType { get; set; }

        /// <summary>Gets or sets the address of the server to which the game client is currently connected.</summary>
        public IPEndPoint ServerAddress { get; set; }

        /// <summary>Gets or sets the shard identifier of the current shard.</summary>
        public int ShardId { get; set; }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Operators do not require an explanation.")]
        public static bool operator ==(AvatarContext left, AvatarContext right)
        {
            return object.Equals(left, right);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Operators do not require an explanation.")]
        public static bool operator !=(AvatarContext left, AvatarContext right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(AvatarContext other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.BuildId == other.BuildId && this.Instance == other.Instance && this.MapId == other.MapId && this.MapType == other.MapType
                   && object.Equals(this.ServerAddress, other.ServerAddress) && this.ShardId == other.ShardId;
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((AvatarContext)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object"/>.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.BuildId;
                hashCode = (hashCode * 397) ^ this.Instance;
                hashCode = (hashCode * 397) ^ this.MapId;
                hashCode = (hashCode * 397) ^ this.MapType;
                hashCode = (hashCode * 397) ^ (this.ServerAddress != null ? this.ServerAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ this.ShardId;
                return hashCode;
            }
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var serverAddress = this.ServerAddress;
            if (serverAddress == null)
            {
                return base.ToString();
            }

            return serverAddress.ToString();
        }
    }
}