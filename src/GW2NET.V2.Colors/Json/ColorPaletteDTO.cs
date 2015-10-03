// <copyright file="ColorPaletteDTO.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Colors.Json
{
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class ColorPaletteDTO
    {
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "base_rgb", Order = 2)]
        public int[] BaseRgb { get; set; }

        [DataMember(Name = "cloth", Order = 3)]
        public ColorModelDTO Cloth { get; set; }

        [DataMember(Name = "leather", Order = 4)]
        public ColorModelDTO Leather { get; set; }

        [DataMember(Name = "metal", Order = 4)]
        public ColorModelDTO Metal { get; set; }
    }
}