// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForBase64.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="T:byte[]" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="T:byte[]"/>.</summary>
    internal sealed class ConverterForBase64 : IConverter<string, byte[]>, IConverter<byte[], string>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="T:byte[]"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public byte[] Convert(string value)
        {
            Contract.Assume(value != null);
            return System.Convert.FromBase64String(value);
        }

        /// <summary>Converts the given object of type <see cref="T:byte[]"/> to an object of type <see cref="string"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public string Convert(byte[] value)
        {
            Contract.Assume(value != null);
            return System.Convert.ToBase64String(value);
        }
    }
}