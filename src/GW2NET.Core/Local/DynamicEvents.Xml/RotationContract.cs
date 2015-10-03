// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RotationContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a dynamic event rotation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Local.DynamicEvents.Xml
{
    using System.Runtime.Serialization;

    /// <summary>Represents a dynamic event rotation.</summary>
    [DataContract(Name = "rotation", Namespace = "")]
    public sealed class RotationContract
    {
        /// <summary>Gets or sets the event identifier.</summary>
        [DataMember(Name = "event_id", Order = 0)]
        public string EventId { get; set; }

        /// <summary>Gets or sets a collection of rotating shifts.</summary>
        [DataMember(Name = "shifts", Order = 1)]
        public ShiftCollectionContract Shifts { get; set; }
    }
}