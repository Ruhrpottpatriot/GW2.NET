// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatLinkConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for chat link converters.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Text.RegularExpressions;

    /// <summary>Provides the base class for chat link converters.</summary>
    [ContractClass(typeof(ChatLinkConverterContracts))]
    public abstract class ChatLinkConverter
    {
        /// <summary>Infrastructure. The regular expression that is used to parse chat links.</summary>
        private static readonly Regex Pattern = new Regex(@"^\[&(?<base64>(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)??)\]$");

        /// <summary>Gets the chat link header.</summary>
        protected abstract byte Header { get; }

        /// <summary>Returns whether the given value is a valid chat link.</summary>
        /// <returns>true if the specified value is a valid chat link; otherwise, false.</returns>
        /// <param name="value">The <see cref="T:System.String"/> to test for validity. </param>
        [Pure]
        public static bool IsChatLink(string value)
        {
            Contract.Requires(value != null);
            return Pattern.Match(value).Success;
        }

        /// <summary>Returns whether this converter can convert the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>true if the specified value can be converted; otherwise, false.</returns>
        [Pure]
        public bool CanConvert(string value)
        {
            Contract.Ensures(Contract.Result<bool>() == false || IsChatLink(value));
            if (value == null || !IsChatLink(value))
            {
                return false;
            }

            return this.GetHeader(value) == this.Header;
        }

        /// <summary>Decodes a chat link.</summary>
        /// <param name="value">A <see cref="string"/>.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        [Pure]
        public ChatLink Decode(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition failed: value != null");
            }

            Contract.EndContractBlock();

            // Ensure that this converter can convert the specified value
            if (!this.CanConvert(value))
            {
                return null;
            }

            // Convert the value to its binary representation
            var bytes = this.GetBytes(value);

            // Return a blank instance if only the header byte was set
            if (bytes.Length == 0)
            {
                return (ChatLink)Activator.CreateInstance(this.GetType());
            }

            // Create a buffer
            var buffer = new byte[bytes.Length - 1];

            // Copy bytes to the buffer, except the header byte
            Buffer.BlockCopy(bytes, 1, buffer, 0, bytes.Length - 1);

            // Decode and return the chat link object
            return this.ConvertFromBytes(buffer);
        }

        /// <summary>Encodes a chat link.</summary>
        /// <param name="value">A <see cref="ChatLink"/>.</param>
        /// <returns>A <see cref="string"/>.</returns>
        [Pure]
        public string Encode(ChatLink value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition failed: value != null");
            }

            Contract.EndContractBlock();

            // Convert the value to its binary representation
            var bytes = this.ConvertToBytes(value);

            // Create a buffer
            var buffer = new byte[bytes.Length + 1];

            // Set the header byte
            Buffer.SetByte(buffer, 0, this.Header);

            // Copy bytes to the buffer
            Buffer.BlockCopy(bytes, 0, buffer, 1, bytes.Length);

            // Convert the buffer to its base64 representation
            var base64 = Convert.ToBase64String(buffer);

            // Encode and return the chat link object
            return string.Format(@"[&{0}]", base64);
        }

        /// <summary>Converts the given byte array to the specified chat link type.</summary>
        /// <param name="bytes">The byte array.</param>
        /// <returns>A chat link.</returns>
        protected abstract ChatLink ConvertFromBytes(byte[] bytes);

        /// <summary>Converts the given chat link to a byte array.</summary>
        /// <param name="value">The chat link.</param>
        /// <returns>A byte array.</returns>
        protected abstract byte[] ConvertToBytes(ChatLink value);

        /// <summary>Gets a byte array for the specified chat link.</summary>
        /// <param name="input">A chat link.</param>
        /// <returns>A byte array.</returns>
        [Pure]
        private byte[] GetBytes(string input)
        {
            Contract.Requires(input != null);
            Contract.Requires(IsChatLink(input));
            Contract.Ensures(Contract.Result<byte[]>() != null);

            // Search the input for a pattern
            var match = Pattern.Match(input);

            // Extract the encoded part of the input
            var base64 = match.Groups["base64"];

            // Return an empty byte array if the input is an empty chat code 
            if (base64 == null)
            {
                return new byte[0];
            }

            // Return a byte array from the decoded input
            return Convert.FromBase64String(base64.Value);
        }

        /// <summary>Gets the header byte for the specified chat link.</summary>
        /// <param name="input">A chat link.</param>
        /// <returns>The header byte.</returns>
        [Pure]
        private byte GetHeader(string input)
        {
            Contract.Requires(input != null);
            Contract.Requires(IsChatLink(input));
            var bytes = this.GetBytes(input);
            if (bytes.Length == 0)
            {
                return 0;
            }

            return bytes[0];
        }
    }
}