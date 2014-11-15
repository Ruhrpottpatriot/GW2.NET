// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the LocationDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/event_details")]
    internal sealed class LocationDataContract
    {
        [DataMember(Name = "type", Order = 0)]
        internal string Type { get; set; }

        [DataMember(Name = "center", Order = 1)]
        internal double[] Center { get; set; }

        [DataMember(Name = "height", Order = 2)]
        internal double Height { get; set; }

        [DataMember(Name = "radius", Order = 3)]
        internal double Radius { get; set; }

        [DataMember(Name = "rotation", Order = 4)]
        internal double Rotation { get; set; }

        [DataMember(Name = "z_range", Order = 5)]
        internal double[] ZRange { get; set; }

        [DataMember(Name = "points", Order = 6)]
        internal double[][] Points { get; set; }
    }
}