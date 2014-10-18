// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General internal License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ColorContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Colors.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class ColorContract
    {
        [DataMember(Name = "base_rgb", Order = 1)]
        internal int[] BaseRgb { get; set; }

        [DataMember(Name = "cloth", Order = 2)]
        internal ColorModelContract Cloth { get; set; }

        [DataMember(Name = "leather", Order = 3)]
        internal ColorModelContract Leather { get; set; }

        [DataMember(Name = "metal", Order = 4)]
        internal ColorModelContract Metal { get; set; }

        [DataMember(Name = "name", Order = 0)]
        internal string Name { get; set; }
    }
}