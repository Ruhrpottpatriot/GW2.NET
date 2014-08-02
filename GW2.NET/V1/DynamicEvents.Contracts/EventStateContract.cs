// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventStateContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a dynamic event and its state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents a dynamic event and its state.</summary>
    [DataContract]
    public sealed class EventStateContract
    {
        /// <summary>Gets or sets the event identifier.</summary>
        [DataMember(Name = "event_id", Order = 2)]
        public string EventId { get; set; }

        /// <summary>Gets or sets the map identifier.</summary>
        [DataMember(Name = "map_id", Order = 1)]
        public int MapId { get; set; }

        /// <summary>Gets or sets the current state of the event.</summary>
        [DataMember(Name = "state", Order = 3)]
        public string State { get; set; }

        /// <summary>Gets or sets the world identifier.</summary>
        [DataMember(Name = "world_id", Order = 0)]
        public int WorldId { get; set; }
    }
}