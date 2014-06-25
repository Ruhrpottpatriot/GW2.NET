// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventRotation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a dynamic event and its rotation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Rotations.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a dynamic event and its rotation.</summary>
    public class DynamicEventRotation : JsonObject
    {
        /// <summary>Gets or sets the event identifier.</summary>
        [DataMember(Name = "event_id")]
        public Guid EventId { get; set; }

        /// <summary>Gets or sets the event shifts.</summary>
        [DataMember(Name = "shifts")]
        public DynamicEventShifts Shifts { get; set; }
    }
}