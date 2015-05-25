// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GzipCompressor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the GZIP compressor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Compression
{
    using System.IO;
    using System.IO.Compression;

    using GW2NET.Common;

    /// <summary>Represents the GZIP compressor.</summary>
    public class GzipCompressor : IConverter<Stream, Stream>
    {
        /// <summary>Compresses the given <see cref="Stream"/>.</summary>
        /// <param name="value">The stream to compress.</param>
        /// <returns>The compressed <see cref="Stream"/>.</returns>
        public Stream Convert(Stream value)
        {
            return new GZipStream(value, CompressionMode.Compress);
        }
    }
}