// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AvatarContext.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides contextual data about a player's avatar. Check the <see cref="AvatarContext" /> of two different players for equality to determine if the players are in the same map instance.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.MumbleLink
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    /// <summary>
    ///     Provides contextual data about a player's avatar. Check the <see cref="AvatarContext" /> of two different
    ///     players for equality to determine if the players are in the same map instance.
    /// </summary>
    public sealed class AvatarContext : IEquatable<AvatarContext>
    {
        private byte[] innerContext;

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

        public static bool operator ==(AvatarContext left, AvatarContext right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AvatarContext left, AvatarContext right)
        {
            return !Equals(left, right);
        }

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

            if (this.innerContext == null || other.innerContext == null)
            {
                return false;
            }

            var length = this.innerContext.Length;
            if (length != other.innerContext.Length)
            {
                return false;
            }

            for (var i = 0; i < length; i++)
            {
                if (this.innerContext[i] != other.innerContext[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as AvatarContext);
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode",
            Justification = "The field is private, and no public API modifies it after it is already set.")]
        public override int GetHashCode()
        {
            return (this.innerContext != null ? this.innerContext.GetHashCode() : 0);
        }

        /// <summary>Sets the object that is used to compare the current object to another object of the same type.</summary>
        /// <param name="context">The context that is used in comparisons.</param>
        public void SetInnerContext(byte[] context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (this.innerContext != null)
            {
                throw new InvalidOperationException(
                    "The inner context is already set for this instance. You can only do this once.");
            }

            this.innerContext = context;
        }
    }
}