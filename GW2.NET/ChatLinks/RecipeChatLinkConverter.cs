// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeChatLinkConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a type converter to convert string objects to and from its <see cref="RecipeChatLink" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>Provides a type converter to convert string objects to and from its <see cref="RecipeChatLink"/> representation.</summary>
    internal class RecipeChatLinkConverter : ChatLinkConverter<RecipeChatLink>
    {
        /// <summary>Gets the chat link header.</summary>
        protected override byte Header
        {
            get
            {
                return 0xA;
            }
        }

        /// <summary>Converts the given byte array to the specified chat link type.</summary>
        /// <param name="bytes">The byte array.</param>
        /// <returns>A chat link.</returns>
        protected override RecipeChatLink ConvertFromBytes(byte[] bytes)
        {
            // Create a new chat link object
            var value = new RecipeChatLink();

            // Create a buffer
            var buffer = new byte[sizeof(int)];

            // Copy up to the first 4 bytes to the buffer
            Buffer.BlockCopy(bytes, 0, buffer, 0, Math.Min(bytes.Length, buffer.Length));

            // Set the recipe identifier
            value.RecipeId = BitConverter.ToInt32(buffer, 0);

            // Return the chat link object
            return value;
        }

        /// <summary>Converts the given chat link to a byte array.</summary>
        /// <param name="value">The chat link.</param>
        /// <returns>A byte array.</returns>
        protected override byte[] ConvertToBytes(RecipeChatLink value)
        {
            return BitConverter.GetBytes(value.RecipeId);
        }
    }
}