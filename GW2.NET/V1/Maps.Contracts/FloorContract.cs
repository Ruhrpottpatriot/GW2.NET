// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map floor, used to populate a world map. All coordinates are map coordinates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a map floor, used to populate a world map. All coordinates are map coordinates.</summary>
    public sealed class FloorContract : ServiceContract
    {
        /// <summary>Gets or sets a rectangle of downloadable textures. Every tile coordinate outside of this rectangle is not available on the tile server.</summary>
        [DataMember(Name = "clamped_view", Order = 1)]
        public double[][] ClampedView { get; set; }

        /// <summary>Gets or sets the collection of regions.</summary>
        [DataMember(Name = "regions", Order = 2)]
        public IDictionary<string, RegionContract> Regions { get; set; }

        /// <summary>Gets or sets the texture's dimensions.</summary>
        [DataMember(Name = "texture_dims", Order = 0)]
        public double[] TextureDimensions { get; set; }
    }
}