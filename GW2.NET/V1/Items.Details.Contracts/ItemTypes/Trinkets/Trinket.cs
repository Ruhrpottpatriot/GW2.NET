// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trinket.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a trinket.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trinkets
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents a trinket.</summary>
    [JsonConverter(typeof(TrinketConverter))]
    public abstract class Trinket : CombatItem
    {
        /// <summary>Initializes a new instance of the <see cref="Trinket"/> class.</summary>
        /// <param name="trinketType">The trinket's type.</param>
        protected Trinket(TrinketType trinketType)
            : base(ItemType.Trinket, "trinket")
        {
            this.TrinketType = trinketType;
        }

        /// <summary>Gets or sets the trinket's type.</summary>
        [DataMember(Name = "trinket_type")]
        protected TrinketType TrinketType { get; set; }
    }
}