// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuffDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the BuffDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed class BuffDTO
    {
        [DataMember(Name = "description", Order = 1)]
        public string Description { get; set; }

        [DataMember(Name = "skill_id", Order = 0)]
        public int? SkillId { get; set; }
    }
}