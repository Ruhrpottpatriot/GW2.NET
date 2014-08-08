// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatLinkConverterBase.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for type converters that convert string objects to and from chat link representations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Text.RegularExpressions;

    /// <summary>Provides the base class for type converters that convert string objects to and from chat link representations.</summary>
    internal class ChatLinkConverterBase : StringConverter
    {
        /// <summary>Infrastructure. The regular expression that is used to parse chat links.</summary>
        private static readonly Regex Pattern = new Regex(@"^\[&(?<base64>(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)??)\]$");

        /// <summary>Returns whether the given value is a valid chat link.</summary>
        /// <returns>true if the specified value is a valid chat link; otherwise, false.</returns>
        /// <param name="value">The <see cref="T:System.String"/> to test for validity. </param>
        [Pure]
        protected static bool IsValidChatLink(string value)
        {
            Contract.Requires(value != null);
            return Pattern.Match(value).Success;
        }

        /// <summary>Gets a byte array for the specified chat link.</summary>
        /// <param name="input">A chat link.</param>
        /// <returns>A byte array.</returns>
        [Pure]
        protected byte[] GetBytes(string input)
        {
            Contract.Requires(input != null);
            Contract.Requires(IsValidChatLink(input));
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
        protected byte GetHeader(string input)
        {
            Contract.Requires(input != null);
            Contract.Requires(IsValidChatLink(input));
            var bytes = this.GetBytes(input);
            if (bytes.Length == 0)
            {
                return 0;
            }

            return bytes[0];
        }
    }
}