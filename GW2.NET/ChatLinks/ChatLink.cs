// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for chat links.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks
{
    using System.ComponentModel;

    /// <summary>Provides the base class for chat links.</summary>
    public abstract class ChatLink
    {
        /// <summary>Initializes static members of the <see cref="ChatLink"/> class.</summary>
        static ChatLink()
        {
            Factory = new ChatLinkFactory();
        }

        /// <summary>
        /// Gets a reference to the factory class that provides chat link factory methods.
        /// </summary>
        public static ChatLinkFactory Factory { get; private set; }

        /// <summary>Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.</summary>
        /// <returns>A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.</returns>
        public override string ToString()
        {
            var typeConverter = TypeDescriptor.GetConverter(this.GetType());
            return typeConverter.ConvertToString(this) ?? "[&]";
        }
    }
}