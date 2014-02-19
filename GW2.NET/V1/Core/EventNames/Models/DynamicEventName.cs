// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventName.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.EventNames.Models
{
    /// <summary>
    /// Represents the localized name for a specific event.
    /// </summary>
    public class DynamicEventName : JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventName"/> class.
        /// </summary>
        public DynamicEventName()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventName"/> class using the specified values.
        /// </summary>
        /// <param name="id">The event ID.</param>
        /// <param name="name">The localized event name.</param>
        public DynamicEventName(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the event ID.
        /// </summary>
        [JsonProperty("id", Order = 0)]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the localized event name.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }
    }
}