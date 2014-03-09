// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BagDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a bag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Bags
{
    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a bag.
    /// </summary>
    public class BagDetails : JsonObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets a value indicating whether this is an invisible bag.
        /// </summary>
        [JsonProperty("no_sell_or_sort", Order = 0)]
        [JsonConverter(typeof(JsonBooleanConverter))]
        public bool NoSellOrSort { get; set; }

        /// <summary>
        ///     Gets or sets the bag's capacity.
        /// </summary>
        [JsonProperty("size", Order = 1)]
        public int Size { get; set; }

        #endregion
    }
}