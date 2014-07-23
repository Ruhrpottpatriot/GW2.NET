// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventNameContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a dynamic event and its localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a dynamic event and its localized name.</summary>
    public sealed class EventNameContract : ServiceContract
    {
        /// <summary>Gets or sets the event identifier.</summary>
        [DataMember(Name = "id", Order = 0)]
        public string Id { get; set; }

        /// <summary>Gets or sets the localized event name.</summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }
    }
}