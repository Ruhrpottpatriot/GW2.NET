// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FloorDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Floors.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/map_floor")]
    internal sealed class FloorDataContract
    {
        [DataMember(Name = "texture_dims", Order = 0)]
        internal double[] TextureDimensions { get; set; }

        [DataMember(Name = "clamped_view", Order = 1)]
        internal double[][] ClampedView { get; set; }

        [DataMember(Name = "regions", Order = 2)]
        internal IDictionary<string, RegionDataContract> Regions { get; set; }
    }
}