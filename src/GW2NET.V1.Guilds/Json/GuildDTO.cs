// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GuildDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Guilds.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/guild_details")]
    public sealed class GuildDTO
    {
        [DataMember(Name = "guild_id", Order = 0)]
        public string GuildId { get; set; }

        [DataMember(Name = "guild_name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "tag", Order = 2)]
        public string Tag { get; set; }

        [DataMember(Name = "emblem", Order = 3)]
        public EmblemDTO Emblem { get; set; }
    }
}