// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Asset.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Files
{
    /// <summary>
    /// Represents information about a file that can be retrieved from the render service.
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Asset"/> class.
        /// </summary>
        public Asset()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Asset"/> class.
        /// </summary>
        /// <param name="fileId">The file ID.</param>
        /// <param name="signature">The file signature.</param>
        [JsonConstructor]
        public Asset(string fileId, string signature)
        {
            this.FileId = fileId;
            this.Signature = signature;
        }

        /// <summary>
        /// Gets the file ID to be used with the render service.
        /// </summary>
        [JsonProperty("file_id")]
        public string FileId { get; private set; }

        /// <summary>
        /// Gets file signature to be used with the render service.
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; private set; }

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
