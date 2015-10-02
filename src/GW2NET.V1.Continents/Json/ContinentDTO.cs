// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContinentDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Continents.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/continents")]
    public sealed class ContinentDTO
    {
        [DataMember(Name = "continent_dims", Order = 1)]
        public double[] ContinentDimensions { get; set; }

        [DataMember(Name = "floors", Order = 4)]
        public ICollection<int> Floors { get; set; }

        [DataMember(Name = "max_zoom", Order = 3)]
        public int MaximumZoom { get; set; }

        [DataMember(Name = "min_zoom", Order = 2)]
        public int MinimumZoom { get; set; }

        [DataMember(Name = "name", Order = 0)]
        public string Name { get; set; }
    }
}