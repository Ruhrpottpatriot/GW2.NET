// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for an in-game asset.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Rendering
{
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>Represents a request for an in-game asset.</summary>
    public sealed class RenderRequest : IRenderRequest
    {
        /// <summary>Gets or sets the file identifier.</summary>
        public int FileId { get; set; }

        /// <summary>Gets or sets the file signature.</summary>
        public string FileSignature { get; set; }

        /// <summary>Gets or sets the image format.</summary>
        public string ImageFormat { get; set; }

        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                var signature = this.FileSignature;
                var id = this.FileId.ToString(NumberFormatInfo.InvariantInfo);
                var format = this.ImageFormat;
                return string.Format(@"file/{0}/{1}.{2}", signature, id, format);
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            yield break;
        }
    }
}