// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the PointOfInterestDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Floors.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/map_floor")]
    internal sealed class PointOfInterestDataContract
    {
        [DataMember(Name = "poi_id", Order = 0)]
        internal int PointOfInterestId { get; set; }

        [DataMember(Name = "name", Order = 1)]
        internal string Name { get; set; }

        [DataMember(Name = "type", Order = 2)]
        internal string Type { get; set; }

        [DataMember(Name = "floor", Order = 3)]
        internal int Floor { get; set; }

        [DataMember(Name = "coord", Order = 4)]
        internal double[] Coordinates { get; set; }
    }
}
