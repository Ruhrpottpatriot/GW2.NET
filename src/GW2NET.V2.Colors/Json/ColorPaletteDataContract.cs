// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/items interface. See the remarks section for important limitations regarding this implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Colors
{
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class ColorPaletteDataContract
    {
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "base_rgb", Order = 2)]
        public int[] BaseRgb { get; set; }

        [DataMember(Name = "cloth", Order = 3)]
        public ColorModelDataContract Cloth { get; set; }

        [DataMember(Name = "leather", Order = 4)]
        public ColorModelDataContract Leather { get; set; }

        [DataMember(Name = "metal", Order = 4)]
        public ColorModelDataContract Metal { get; set; }
    }
}