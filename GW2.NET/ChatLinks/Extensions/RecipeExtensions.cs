// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeExtensions.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides static extension methods for the <see cref="Recipe" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks.Extensions
{
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Recipes.Details.Contracts;

    /// <summary>Provides static extension methods for the <see cref="Recipe" /> class.</summary>
    public static class RecipeExtensions
    {
        /// <summary>Gets a chat link for the specified recipe.</summary>
        /// <param name="instance">The recipe.</param>
        /// <returns>The <see cref="ChatLink"/>The chat link.</returns>
        public static ChatLink GetChatLink(this Recipe instance)
        {
            Preconditions.EnsureNotNull(instance);
            return new RecipeChatLink(instance.RecipeId);
        }
    }
}