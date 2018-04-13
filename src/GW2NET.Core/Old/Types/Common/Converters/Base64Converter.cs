// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Base64Converter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="T:byte[]" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Converters
{
    using System;

    /// <summary>Converts an array of 8-bit unsigned integers to and from its equivalent string representation that is encoded with base-64 digits.</summary>
    public sealed class Base64Converter : IConverter<string, byte[]>, IConverter<byte[], string>
    {
        /// <inheritdoc />
        public byte[] Convert(string value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return System.Convert.FromBase64String(value);
        }

        /// <inheritdoc />
        public string Convert(byte[] value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return System.Convert.ToBase64String(value);
        }
    }
}