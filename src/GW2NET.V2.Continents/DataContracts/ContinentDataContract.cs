// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContinentDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Continents
{
    using System.Runtime.Serialization;

    /// <summary>Represents the continent data from the GW2 api.</summary>
    [DataContract]
    internal sealed class ContinentDataContract
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the dimensions.
        /// </summary>
        [DataMember(Name = "continent_dims", Order = 2)]
        public int[] Dimensions { get; set; }

        /// <summary>
        /// Gets or sets the minimum zoom.
        /// </summary>
        [DataMember(Name = "min_zoom", Order = 3)]
        public int MinimumZoom { get; set; }

        /// <summary>
        /// Gets or sets the maximum zoom.
        /// </summary>
        [DataMember(Name = "max_zoom", Order = 4)]
        public int MaximumZoom { get; set; }

        /// <summary>
        /// Gets or sets the floors.
        /// </summary>
        [DataMember(Name = "floors", Order = 5)]
        public int[] Floors { get; set; }
    }
}