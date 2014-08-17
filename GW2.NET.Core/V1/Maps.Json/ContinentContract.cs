// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a continent.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents a continent.</summary>
    [DataContract]
    public sealed class ContinentContract
    {
        /// <summary>Gets or sets the dimensions of the continent.</summary>
        [DataMember(Name = "continent_dims", Order = 1)]
        public double[] ContinentDimensions { get; set; }

        /// <summary>Gets or sets a collection of floors available for this continent.</summary>
        [DataMember(Name = "floors", Order = 4)]
        public ICollection<int> Floors { get; set; }

        /// <summary>Gets or sets the maximum zoom level for use with the map tile service.</summary>
        [DataMember(Name = "max_zoom", Order = 3)]
        public int MaximumZoom { get; set; }

        /// <summary>Gets or sets the minimum zoom level for use with the map tile service.</summary>
        [DataMember(Name = "min_zoom", Order = 2)]
        public int MinimumZoom { get; set; }

        /// <summary>Gets or sets the name of the continent.</summary>
        [DataMember(Name = "name", Order = 0)]
        public string Name { get; set; }
    }
}