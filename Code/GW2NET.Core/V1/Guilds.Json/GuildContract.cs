// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GuildContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Guilds.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class GuildContract
    {
        [DataMember(Name = "emblem", Order = 4)]
        internal EmblemContract Emblem { get; set; }

        [DataMember(Name = "guild_id", Order = 0)]
        internal string GuildId { get; set; }

        [DataMember(Name = "guild_name", Order = 1)]
        internal string Name { get; set; }

        [DataMember(Name = "tag", Order = 2)]
        internal string Tag { get; set; }
    }
}