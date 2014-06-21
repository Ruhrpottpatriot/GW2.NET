// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for an in-game asset.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Rendering
{
    /// <summary>Represents a request for an in-game asset.</summary>
    public class RenderRequest : IRenderRequest
    {
        /// <summary>Gets or sets the file identifier.</summary>
        public int FileId { get; set; }

        /// <summary>Gets or sets the file signature.</summary>
        public string FileSignature { get; set; }

        /// <summary>Gets or sets the image format.</summary>
        public string ImageFormat { get; set; }
    }
}