// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Location.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the location of an event on the map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Details.Contracts.Locations
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.Common.Drawing;

    /// <summary>Represents the location of an event on the map.</summary>
    public abstract class Location : JsonObject
    {
        /// <summary>Gets or sets the center coordinates.</summary>
        [DataMember(Name = "center", Order = 1)]
        public Point3D Center { get; set; }
    }
}