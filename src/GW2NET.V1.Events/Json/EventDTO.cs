// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the EventDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Events.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/event_details")]
    public sealed class EventDTO
    {
        [DataMember(Name = "name", Order = 0)]
        public string Name { get; set; }

        [DataMember(Name = "level", Order = 1)]
        public int Level { get; set; }

        [DataMember(Name = "map_id", Order = 2)]
        public int MapId { get; set; }

        [DataMember(Name = "flags", Order = 3)]
        public string[] Flags { get; set; }

        [DataMember(Name = "location", Order = 4)]
        public LocationDTO Location { get; set; }
    }
}