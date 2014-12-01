// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to a recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;

    /// <summary>Represents a chat link that links to a recipe.</summary>
    public class RecipeChatLink : ChatLink
    {
        /// <summary>Gets or sets the recipe identifier.</summary>
        public int RecipeId { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var stream = new ConverterForRecipeChatLink().Convert(this);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return string.Format("[&{0}]", Convert.ToBase64String(buffer));
        }
    }
}