// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the LocationDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Events.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/event_details")]
    public sealed class LocationDTO
    {
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        [DataMember(Name = "center", Order = 1)]
        public double[] Center { get; set; }

        [DataMember(Name = "height", Order = 2)]
        public double Height { get; set; }

        [DataMember(Name = "radius", Order = 3)]
        public double Radius { get; set; }

        [DataMember(Name = "rotation", Order = 4)]
        public double Rotation { get; set; }

        [DataMember(Name = "z_range", Order = 5)]
        public double[] ZRange { get; set; }

        [DataMember(Name = "points", Order = 6)]
        public double[][] Points { get; set; }
    }
}