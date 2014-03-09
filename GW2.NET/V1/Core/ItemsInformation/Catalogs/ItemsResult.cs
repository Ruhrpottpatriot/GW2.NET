// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of item IDs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Catalogs
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Wraps a collection of item IDs.
    /// </summary>
    public class ItemsResult : JsonObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets a collection of item IDs.
        /// </summary>
        [JsonProperty("items")]
        public ItemCollection Items { get; set; }

        #endregion
    }
}