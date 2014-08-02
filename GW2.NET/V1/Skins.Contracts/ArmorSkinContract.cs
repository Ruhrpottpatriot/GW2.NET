// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorSkinContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an armor skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents an armor skin.</summary>
    [DataContract]
    public sealed class ArmorSkinContract
    {
        /// <summary>Gets or sets the armor skin type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        /// <summary>Gets or sets the armor skin's weight class.</summary>
        [DataMember(Name = "weight_class", Order = 1)]
        public string WeightClass { get; set; }
    }
}