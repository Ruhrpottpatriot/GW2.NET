// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmblemDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the EmblemDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Guilds.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/guild_details")]
    internal sealed class EmblemDataContract
    {
        [DataMember(Name = "background_id", Order = 0)]
        internal int BackgroundId { get; set; }

        [DataMember(Name = "foreground_id", Order = 1)]
        internal int ForegroundId { get; set; }

        [DataMember(Name = "flags", Order = 2)]
        internal string[] Flags { get; set; }

        [DataMember(Name = "background_color_id", Order = 3)]
        internal int BackgroundColorId { get; set; }

        [DataMember(Name = "foreground_primary_color_id", Order = 4)]
        internal int ForegroundPrimaryColorId { get; set; }

        [DataMember(Name = "foreground_secondary_color_id", Order = 5)]
        internal int ForegroundSecondaryColorId { get; set; }
    }
}