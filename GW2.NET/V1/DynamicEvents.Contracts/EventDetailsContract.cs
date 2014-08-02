// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventDetailsContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a dynamic event and its localized details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents a dynamic event and its localized details.</summary>
    [DataContract]
    public sealed class EventDetailsContract
    {
        /// <summary>Gets or sets additional flags.</summary>
        [DataMember(Name = "flags", Order = 3)]
        public string[] Flags { get; set; }

        /// <summary>Gets or sets the event level.</summary>
        [DataMember(Name = "level", Order = 1)]
        public int Level { get; set; }

        /// <summary>Gets or sets the location of the event.</summary>
        [DataMember(Name = "location", Order = 4)]
        public LocationContract Location { get; set; }

        /// <summary>Gets or sets the map.</summary>
        [DataMember(Name = "map_id", Order = 2)]
        public int MapId { get; set; }

        /// <summary>Gets or sets the name of the event.</summary>
        [DataMember(Name = "name", Order = 0)]
        public string Name { get; set; }
    }
}