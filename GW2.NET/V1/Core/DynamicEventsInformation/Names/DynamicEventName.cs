// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventName.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a dynamic event and its localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.DynamicEventsInformation.Names
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a dynamic event and its localized name.
    /// </summary>
    public class DynamicEventName : JsonObject
    {
        /// <summary>
        ///     Gets or sets the event ID.
        /// </summary>
        [JsonProperty("ID", Order = 0)]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the localized event name.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }
    }
}