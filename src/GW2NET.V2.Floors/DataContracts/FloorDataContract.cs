// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FloorDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents the floor object from the api.</summary>
    [DataContract]
    internal sealed class FloorDataContract
    {
        /// <summary>
        /// Gets or sets the texture dimensions.
        /// </summary>
        [DataMember(Name = "texture_dims", Order = 0)]
        internal double[] TextureDimensions { get; set; }

        /// <summary>
        /// Gets or sets the clamped view.
        /// </summary>
        [DataMember(Name = "clamped_view", Order = 1)]
        internal double[][] ClampedView { get; set; }

        /// <summary>
        /// Gets or sets the regions.
        /// </summary>
        [DataMember(Name = "regions", Order = 2)]
        internal IDictionary<string, RegionDataContract> Regions { get; set; }
    }
}