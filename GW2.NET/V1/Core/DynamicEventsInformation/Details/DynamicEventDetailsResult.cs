// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of dynamic events and their details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Details
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Wraps a collection of dynamic events and their details.
    /// </summary>
    public class DynamicEventDetailsResult : JsonObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets a list of details about dynamic events.
        /// </summary>
        [JsonProperty("events")]
        public DynamicEventDetailsCollection EventDetails { get; set; }

        #endregion
    }
}