// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ColorDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Colors.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/colors")]
    internal sealed class ColorDataContract
    {
        [DataMember(Name = "name", Order = 0)]
        internal string Name { get; set; }

        [DataMember(Name = "base_rgb", Order = 1)]
        internal int[] BaseRgb { get; set; }

        [DataMember(Name = "cloth", Order = 2)]
        internal ColorModelDataContract Cloth { get; set; }

        [DataMember(Name = "leather", Order = 3)]
        internal ColorModelDataContract Leather { get; set; }

        [DataMember(Name = "metal", Order = 4)]
        internal ColorModelDataContract Metal { get; set; }

        [DataMember(Name = "item", Order = 5)]
        internal int ItemId { get; set; }

        [DataMember(Name = "categories", Order = 6)]
        internal string[] Categories { get; set; }
    }
}