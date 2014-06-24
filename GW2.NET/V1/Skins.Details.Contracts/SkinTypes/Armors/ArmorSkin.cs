// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an armor skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details.Contracts.SkinTypes.Armors
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Armors;

    /// <summary>Represents an armor skin.</summary>
    [TypeDiscriminator(Value = "Armor", BaseType = typeof(Skin))]
    public abstract class ArmorSkin : Skin
    {
        /// <summary>Gets or sets the armor skin's weight class.</summary>
        [DataMember(Name = "weight_class")]
        public ArmorWeightClass WeightClass { get; set; }
    }
}