// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Details
{
    /// <summary>
    /// Wraps a collection of dynamic events and their details.
    /// </summary>
    public class DynamicEventDetailsResult : JsonObject
    {
        /// <summary>
        /// Gets or sets a list of details about dynamic events.
        /// </summary>
        [JsonProperty("events")]
        public Dictionary<Guid, DynamicEventDetails> EventDetails { get; set; }
    }
}