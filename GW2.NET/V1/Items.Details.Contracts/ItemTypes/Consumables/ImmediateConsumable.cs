// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImmediateConsumable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an immediate consumable item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents an immediate consumable item.</summary>
    [TypeDiscriminator(Value = "Immediate", BaseType = typeof(Consumable))]
    public class ImmediateConsumable : Consumable
    {
        /// <summary>Gets or sets the consumable's effect duration.</summary>
        [DataMember(Name = "duration_ms")]
        [JsonConverter(typeof(JsonTimespanConverter))]
        public virtual TimeSpan? Duration { get; set; }
    }
}