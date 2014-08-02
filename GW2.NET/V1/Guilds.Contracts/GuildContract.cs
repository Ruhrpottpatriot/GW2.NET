// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a guild and its details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Guilds.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents a guild and its details.</summary>
    [DataContract]
    public sealed class GuildContract
    {
        /// <summary>Gets or sets the guild's emblem.</summary>
        [DataMember(Name = "emblem", Order = 4)]
        public EmblemContract Emblem { get; set; }

        /// <summary>Gets or sets the guild identifier.</summary>
        [DataMember(Name = "guild_id", Order = 0)]
        public string GuildId { get; set; }

        /// <summary>Gets or sets the name of the guild.</summary>
        [DataMember(Name = "guild_name", Order = 1)]
        public string Name { get; set; }

        /// <summary>Gets or sets the guild's tag.</summary>
        [DataMember(Name = "tag", Order = 2)]
        public string Tag { get; set; }
    }
}