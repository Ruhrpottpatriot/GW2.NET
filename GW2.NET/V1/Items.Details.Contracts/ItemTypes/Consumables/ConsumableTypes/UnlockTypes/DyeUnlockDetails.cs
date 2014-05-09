// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DyeUnlockDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a dye.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes.UnlockTypes
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a dye.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class DyeUnlockDetails : UnlockDetails
    {
        /// <summary>Initializes a new instance of the <see cref="DyeUnlockDetails" /> class.</summary>
        public DyeUnlockDetails()
            : base(UnlockType.Dye)
        {
        }

        /// <summary>Gets or sets the dye's color ID.</summary>
        [DataMember(Name = "color_id", Order = 101)]
        public virtual int ColorId { get; set; }
    }
}