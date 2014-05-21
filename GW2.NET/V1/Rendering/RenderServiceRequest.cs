// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderServiceRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for an in-game asset.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Rendering
{
    using System.Drawing.Imaging;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Rendering.Contracts;

    /// <summary>Represents a request for an in-game asset.</summary>
    public class RenderServiceRequest : ServiceRequest
    {
        /// <summary>Initializes a new instance of the <see cref="RenderServiceRequest"/> class.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        public RenderServiceRequest(IRenderable file, ImageFormat imageFormat)
            : base(CreateFileResource(file, imageFormat))
        {
        }

        /// <summary>Gets the path that points to the specified file.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>The file path.</returns>
        private static string CreateFileResource(IRenderable file, ImageFormat imageFormat)
        {
            Preconditions.EnsureNotNull(paramName: "file", value: file);
            Preconditions.EnsureNotNull(paramName: "imageFormat", value: imageFormat);

            return string.Format("file/{0}/{1}.{2}", file.FileSignature, file.FileId, GetExtension(imageFormat));
        }

        /// <summary>Gets a file extension for the specified image format.</summary>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>The extension.</returns>
        private static string GetExtension(ImageFormat imageFormat)
        {
            if (object.Equals(imageFormat, ImageFormat.Jpeg))
            {
                return @"jpg";
            }

            return imageFormat.ToString().ToLowerInvariant();
        }
    }
}