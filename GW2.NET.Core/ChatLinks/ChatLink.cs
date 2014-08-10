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
    using System;
    using System.Linq;

    using GW2DotNET.Common;

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

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var type = this.GetType();
            var converterAttributes = type.GetCustomAttributes(typeof(ConverterAttribute), false).Cast<ConverterAttribute>();
            var converterTypes = converterAttributes.Select(converterAttribute => converterAttribute.Type);
            var converter = converterTypes.Select(Activator.CreateInstance).Cast<ChatLinkConverter>().SingleOrDefault();
            if (converter == null)
            {
                return base.ToString();
            }

            return converter.Encode(this);
        }
    }
}