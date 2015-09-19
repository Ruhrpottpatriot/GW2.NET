// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmblemDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the EmblemDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Guilds.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/guild_details")]
    public sealed class EmblemDTO
    {
        [DataMember(Name = "background_id", Order = 0)]
        public int BackgroundId { get; set; }

        [DataMember(Name = "foreground_id", Order = 1)]
        public int ForegroundId { get; set; }

        [DataMember(Name = "flags", Order = 2)]
        public string[] Flags { get; set; }

        [DataMember(Name = "background_color_id", Order = 3)]
        public int BackgroundColorId { get; set; }

        [DataMember(Name = "foreground_primary_color_id", Order = 4)]
        public int ForegroundPrimaryColorId { get; set; }

        [DataMember(Name = "foreground_secondary_color_id", Order = 5)]
        public int ForegroundSecondaryColorId { get; set; }
    }
}