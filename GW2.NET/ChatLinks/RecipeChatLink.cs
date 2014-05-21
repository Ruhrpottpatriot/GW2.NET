// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to a recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks
{
    using System;

    /// <summary>Represents a chat link that links to a recipe.</summary>
    public class RecipeChatLink : ChatLink
    {
        /// <summary>Initializes a new instance of the <see cref="RecipeChatLink"/> class.</summary>
        /// <param name="recipeId">The recipe ID.</param>
        public RecipeChatLink(int recipeId)
            : base(ChatLinkType.Recipe)
        {
            this.RecipeId = recipeId;
        }

        /// <summary>Gets the recipe ID.</summary>
        public int RecipeId { get; private set; }

        /// <summary>Gets the bytes.</summary>
        /// <returns>The <see cref="byte" /> array.</returns>
        protected override byte[] GetBytes()
        {
            var buffer = new byte[5];
            Buffer.SetByte(buffer, 0, (byte)this.Type);
            Buffer.BlockCopy(BitConverter.GetBytes(this.RecipeId), 0, buffer, 1, 4);
            return buffer;
        }
    }
}