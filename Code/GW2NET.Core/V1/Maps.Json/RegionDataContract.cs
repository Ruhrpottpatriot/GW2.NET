// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the RegionDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class RegionDataContract
    {
        [DataMember(Name = "label_coord", Order = 1)]
        internal double[] LabelCoordinates { get; set; }

        [DataMember(Name = "maps", Order = 2)]
        internal IDictionary<string, SubregionDataContract> Maps { get; set; }

        [DataMember(Name = "name", Order = 0)]
        internal string Name { get; set; }
    }
}