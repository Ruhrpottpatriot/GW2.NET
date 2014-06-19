// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinExtensions.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides static extension methods for the <see cref="Skin" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks.Extensions
{
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Skins.Details.Contracts;

    /// <summary>Provides static extension methods for the <see cref="Skin" /> class.</summary>
    public static class SkinExtensions
    {
        /// <summary>Gets a chat link for the specified skin.</summary>
        /// <param name="instance">The skin.</param>
        /// <returns>The <see cref="ChatLink"/>The chat link.</returns>
        public static ChatLink GetChatLink(this Skin instance)
        {
            Preconditions.EnsureNotNull(instance);
            return new SkinChatLink { SkinId = instance.SkinId };
        }
    }
}