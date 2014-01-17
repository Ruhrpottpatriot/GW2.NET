// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventName.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.Core.EventNames
{
    /// <summary>
    /// Represents the localized name for a specific event.
    /// </summary>
    public class DynamicEventName
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
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the localized event name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
