// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorModelDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ColorModelDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Colors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/colors")]
    internal sealed class ColorModelDataContract
    {
        [DataMember(Name = "brightness", Order = 0)]
        internal int Brightness { get; set; }

        [DataMember(Name = "contrast", Order = 1)]
        internal double Contrast { get; set; }

        [DataMember(Name = "hue", Order = 2)]
        internal int Hue { get; set; }

        [DataMember(Name = "saturation", Order = 3)]
        internal double Saturation { get; set; }

        [DataMember(Name = "lightness", Order = 4)]
        internal double Lightness { get; set; }

        [DataMember(Name = "rgb", Order = 5)]
        internal int[] Rgb { get; set; }
    }
}