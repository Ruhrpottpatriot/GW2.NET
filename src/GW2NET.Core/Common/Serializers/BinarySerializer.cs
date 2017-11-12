// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinarySerializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for serializing binary data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Serializers
{
    using System.IO;

    /// <summary>Provides methods for serializing binary data.</summary>
    public class BinarySerializer : ISerializer<byte[]>
    {
        /// <summary>Converts the input stream to the specified type.</summary>
        /// <param name="stream">The input stream.</param>
        /// <returns>An instance of the specified type.</returns>
        public byte[] Deserialize(Stream stream)
        {
            // Create a buffer (64KiB)
            var buffer = new byte[0xFFFF];

            // Copy all input data to memory
            using (stream)
            using (var memoryStream = new MemoryStream())
            {
                int count;
                while (0 < (count = stream.Read(buffer, 0, buffer.Length)))
                {
                    memoryStream.Write(buffer, 0, count);
                }

                // Convert to a byte array and return
                return memoryStream.ToArray();
            }
        }

        /// <summary>Converts the specified value to an output stream.</summary>
        /// <param name="value">An instance of the specified type.</param>
        /// <param name="stream">The output stream.</param>
        public void Serialize(byte[] value, Stream stream)
        {
            // Ensure that there is data to serialize
            if (value == null)
            {
                return;
            }

            // Copy all data to the output stream
            using (stream)
            {
                stream.Write(value, 0, value.Length);
            }
        }
    }
}
