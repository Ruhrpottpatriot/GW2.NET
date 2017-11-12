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
    internal sealed class ColorPaletteDataContract
    {
        [DataMember(Name = "id", Order = 0)]
        internal int Id { get; set; }

        [DataMember(Name = "name", Order = 1)]
        internal string Name { get; set; }

        [DataMember(Name = "base_rgb", Order = 2)]
        internal int[] BaseRgb { get; set; }

        [DataMember(Name = "cloth", Order = 3)]
        internal ColorModelDataContract Cloth { get; set; }

        [DataMember(Name = "leather", Order = 4)]
        internal ColorModelDataContract Leather { get; set; }

        [DataMember(Name = "metal", Order = 4)]
        internal ColorModelDataContract Metal { get; set; }

        [DataMember(Name = "item", Order = 5)]
        internal int ItemId { get; set; }

        [DataMember(Name = "categories", Order = 6)]
        internal string[] Categories { get; set; }
    }
}
