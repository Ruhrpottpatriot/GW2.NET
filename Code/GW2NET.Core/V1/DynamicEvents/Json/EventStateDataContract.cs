// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventStateDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the EventStateDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/events")]
    internal sealed class EventStateDataContract
    {
        [DataMember(Name = "world_id", Order = 0)]
        internal int WorldId { get; set; }

        [DataMember(Name = "map_id", Order = 1)]
        internal int MapId { get; set; }

        [DataMember(Name = "event_id", Order = 2)]
        internal string EventId { get; set; }

        [DataMember(Name = "state", Order = 3)]
        internal string State { get; set; }
    }
}