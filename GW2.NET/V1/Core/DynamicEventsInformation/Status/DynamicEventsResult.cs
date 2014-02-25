// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventsResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Status
{
    /// <summary>
    /// Wraps a collection of dynamic events.
    /// </summary>
    public class DynamicEventsResult : JsonObject
    {
        /// <summary>
        /// Gets or sets a list of event details.
        /// </summary>
        [JsonProperty("events", Order = 0)]
        public DynamicEvents Events { get; set; }
    }
}