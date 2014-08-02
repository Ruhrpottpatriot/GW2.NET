// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a named color and its color component information for cloth, leather and metal materials.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents a named color and its color component information for cloth, leather and metal materials.</summary>
    [DataContract]
    public sealed class ColorContract
    {
        /// <summary>Gets or sets the base RGB values.</summary>
        [DataMember(Name = "base_rgb", Order = 1)]
        public int[] BaseRgb { get; set; }

        /// <summary>Gets or sets the color model for cloth armor.</summary>
        [DataMember(Name = "cloth", Order = 2)]
        public ColorModelContract Cloth { get; set; }

        /// <summary>Gets or sets the color model for leather armor.</summary>
        [DataMember(Name = "leather", Order = 3)]
        public ColorModelContract Leather { get; set; }

        /// <summary>Gets or sets the color model for metal armor.</summary>
        [DataMember(Name = "metal", Order = 4)]
        public ColorModelContract Metal { get; set; }

        /// <summary>Gets or sets the name of the color.</summary>
        [DataMember(Name = "name", Order = 0)]
        public string Name { get; set; }
    }
}