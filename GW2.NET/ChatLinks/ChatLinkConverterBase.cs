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
    using System.Text.RegularExpressions;

    using GW2DotNET.Utilities;

    /// <summary>Provides the base class for type converters that convert string objects to and from chat link representations.</summary>
    internal class ChatLinkConverterBase : StringConverter
    {
        /// <summary>Infrastructure. The regular expression that is used to parse chat links.</summary>
        private static readonly Regex Pattern = new Regex(@"^\[&(?<base64>(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)??)\]$");

        /// <summary>
        /// Gets a byte array for the specified chat link.
        /// </summary>
        /// <param name="input">A chat link.</param>
        /// <returns>A byte array.</returns>
        protected byte[] GetBytes(string input)
        {
            var match = Pattern.Match(input);

            Preconditions.Ensure(match.Success, "input", "The specified input is not a valid chat link.");

            var base64 = match.Groups["base64"].Value;

            return Convert.FromBase64String(base64);
        }

        /// <summary>
        /// Gets the header byte for the specified chat link.
        /// </summary>
        /// <param name="input">A chat link.</param>
        /// <returns>The header byte.</returns>
        protected byte GetHeader(string input)
        {
            return this.GetBytes(input)[0];
        }
    }
}