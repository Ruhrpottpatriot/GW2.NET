// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContinentDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class ContinentDataContract
    {
        [DataMember(Name = "continent_dims", Order = 1)]
        internal double[] ContinentDimensions { get; set; }

        [DataMember(Name = "floors", Order = 4)]
        internal ICollection<int> Floors { get; set; }

        [DataMember(Name = "max_zoom", Order = 3)]
        internal int MaximumZoom { get; set; }

        [DataMember(Name = "min_zoom", Order = 2)]
        internal int MinimumZoom { get; set; }

        [DataMember(Name = "name", Order = 0)]
        internal string Name { get; set; }
    }
}