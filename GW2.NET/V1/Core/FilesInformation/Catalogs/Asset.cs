// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Asset.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents information about a file that can be retrieved from the render service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.FilesInformation.Catalogs
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents information about a file that can be retrieved from the render service.
    /// </summary>
    public class Asset : JsonObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the file ID to be used with the render service.
        /// </summary>
        [JsonProperty("file_id", Order = 0)]
        public int FileId { get; set; }

        /// <summary>
        ///     Gets or sets the file name.
        /// </summary>
        [JsonProperty("file_name", Order = 2)]
        public string FileName { get; set; }

        /// <summary>
        ///     Gets or sets file signature to be used with the render service.
        /// </summary>
        [JsonProperty("signature", Order = 1)]
        public string Signature { get; set; }

        #endregion
    }
}