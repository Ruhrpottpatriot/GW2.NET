// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FloorContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class FloorContract
    {
        [DataMember(Name = "clamped_view", Order = 1)]
        internal double[][] ClampedView { get; set; }

        [DataMember(Name = "regions", Order = 2)]
        internal IDictionary<string, RegionContract> Regions { get; set; }

        [DataMember(Name = "texture_dims", Order = 0)]
        internal double[] TextureDimensions { get; set; }
    }
}