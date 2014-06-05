// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestChatLinkConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a type converter to convert string objects to and from its <see cref="PointOfInterestChatLink" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks
{
    using System;

    /// <summary>Provides a type converter to convert string objects to and from its <see cref="PointOfInterestChatLink"/> representation.</summary>
    internal class PointOfInterestChatLinkConverter : ChatLinkConverter<PointOfInterestChatLink>
    {
        /// <summary>Gets the chat link header.</summary>
        protected override byte Header
        {
            get
            {
                return 0x4;
            }
        }

        /// <summary>Converts the given byte array to the specified chat link type.</summary>
        /// <param name="bytes">The byte array.</param>
        /// <returns>A chat link.</returns>
        protected override PointOfInterestChatLink ConvertFromBytes(byte[] bytes)
        {
            return new PointOfInterestChatLink { PointOfInterestId = BitConverter.ToInt32(bytes, 0) };
        }

        /// <summary>Converts the given chat link to a byte array.</summary>
        /// <param name="value">The chat link.</param>
        /// <returns>A byte array.</returns>
        protected override byte[] ConvertToBytes(PointOfInterestChatLink value)
        {
            return BitConverter.GetBytes(value.PointOfInterestId);
        }
    }
}