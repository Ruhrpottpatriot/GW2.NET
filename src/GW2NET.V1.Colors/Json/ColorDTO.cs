// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ColorDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Colors.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/colors")]
    public sealed class ColorDTO
    {
        [DataMember(Name = "name", Order = 0)]
        public string Name { get; set; }

        [DataMember(Name = "base_rgb", Order = 1)]
        public int[] BaseRgb { get; set; }

        [DataMember(Name = "cloth", Order = 2)]
        public ColorModelDTO Cloth { get; set; }

        [DataMember(Name = "leather", Order = 3)]
        public ColorModelDTO Leather { get; set; }

        [DataMember(Name = "metal", Order = 4)]
        public ColorModelDTO Metal { get; set; }

        [DataMember(Name = "item", Order = 5)]
        public int ItemId { get; set; }

        [DataMember(Name = "categories", Order = 6)]
        public string[] Categories { get; set; }
    }
}