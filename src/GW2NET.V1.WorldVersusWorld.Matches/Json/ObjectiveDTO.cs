// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ObjectiveDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.WorldVersusWorld.Matches.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/wvw/match_details")]
    public sealed class ObjectiveDTO
    {
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "owner", Order = 1)]
        public string Owner { get; set; }

        [DataMember(Name = "owner_guild", Order = 2)]
        public string OwnerGuild { get; set; }
    }
}