// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GzipInflator.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Decompresses streams that were compressed using a deflation algorithm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Compression
{
    using System;
    using System.IO;
    using System.IO.Compression;

    using GW2NET.Common;

    /// <summary>Decompresses streams that were compressed using a deflation algorithm.</summary>
    public class GzipInflator : IConverter<Stream, Stream>
    {
        /// <inheritdoc />
        public Stream Convert(Stream value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return new GZipStream(value, CompressionMode.Decompress);
        }
    }
}