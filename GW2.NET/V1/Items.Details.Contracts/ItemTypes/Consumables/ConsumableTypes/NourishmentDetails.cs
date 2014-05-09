// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NourishmentDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a nourishment item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a nourishment item.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class NourishmentDetails : ConsumableDetails
    {
        /// <summary>Initializes a new instance of the <see cref="NourishmentDetails"/> class.</summary>
        /// <param name="type">The consumable's type.</param>
        public NourishmentDetails(ConsumableType type)
            : base(type)
        {
        }

        /// <summary>Gets or sets the nourishment's effect description.</summary>
        [DataMember(Name = "description", Order = 101)]
        public virtual string Description { get; set; }

        /// <summary>Gets or sets the nourishment's effect duration.</summary>
        [DataMember(Name = "duration_ms", Order = 100)]
        [JsonConverter(typeof(JsonTimespanConverter))]
        public virtual TimeSpan? Duration { get; set; }
    }
}