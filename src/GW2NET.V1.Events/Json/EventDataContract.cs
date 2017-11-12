// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the EventDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Events.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/event_details")]
    internal sealed class EventDataContract
    {
        [DataMember(Name = "name", Order = 0)]
        internal string Name { get; set; }

        [DataMember(Name = "level", Order = 1)]
        internal int Level { get; set; }

        [DataMember(Name = "map_id", Order = 2)]
        internal int MapId { get; set; }

        [DataMember(Name = "flags", Order = 3)]
        internal string[] Flags { get; set; }

        [DataMember(Name = "location", Order = 4)]
        internal LocationDataContract Location { get; set; }
    }
}
