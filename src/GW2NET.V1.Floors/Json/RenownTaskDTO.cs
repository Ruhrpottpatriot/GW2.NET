// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenownTaskDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the RenownTaskDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Floors.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/map_floor")]
    public sealed class RenownTaskDTO
    {
        [DataMember(Name = "task_id", Order = 0)]
        public int TaskId { get; set; }

        [DataMember(Name = "objective", Order = 1)]
        public string Objective { get; set; }

        [DataMember(Name = "level", Order = 2)]
        public int Level { get; set; }

        [DataMember(Name = "coord", Order = 3)]
        public double[] Coordinates { get; set; }
    }
}