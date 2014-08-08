// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageSerializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for serializing image streams.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common.Serializers
{
    using System.Diagnostics.Contracts;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    /// <summary>
    /// Provides methods for serializing image streams.
    /// </summary>
    public class ImageSerializer : ISerializer<Image>
    {
        /// <summary>Converts the input stream to the specified type.</summary>
        /// <param name="stream">The input stream.</param>
        /// <returns>An instance of the specified type.</returns>
        public Image Deserialize(Stream stream)
        {
            using (stream)
            {
                return Image.FromStream(stream);
            }
        }

        /// <summary>Converts the specified value to an output stream.</summary>
        /// <param name="value">An instance of the specified type.</param>
        /// <param name="stream">The output stream.</param>
        public void Serialize(Image value, Stream stream)
        {
            Contract.Assume(value != null);
            using (stream)
            {
                value.Save(stream, ImageFormat.Png);
            }
        }
    }
}