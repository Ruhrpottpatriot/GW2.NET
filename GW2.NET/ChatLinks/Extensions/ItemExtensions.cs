// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemExtensions.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides static extension methods for the <see cref="Item" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks.Extensions
{
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Items.Details.Contracts;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    /// <summary>Provides static extension methods for the <see cref="Item" /> class.</summary>
    public static class ItemExtensions
    {
        /// <summary>Gets a chat link for the specified item.</summary>
        /// <param name="instance">The item.</param>
        /// <returns>The <see cref="ChatLink"/>.</returns>
        public static ChatLink GetChatLink(this Item instance)
        {
            Preconditions.EnsureNotNull(instance);
            var chatLink = new ItemChatLink(instance.ItemId);
            SetSuffixItems(chatLink, instance as IUpgradable);
            return chatLink;
        }

        /// <summary>Infrastructure. Configures the chat link for equipment with upgrade components.</summary>
        /// <param name="chatLink">The chat link.</param>
        /// <param name="equipmentDetails">The equipment details.</param>
        private static void SetSuffixItems(ItemChatLink chatLink, IUpgradable equipmentDetails)
        {
            if (equipmentDetails == null)
            {
                return;
            }

            chatLink.SuffixItemId = equipmentDetails.SuffixItemId;
            chatLink.SecondarySuffixItemId = equipmentDetails.SecondarySuffixItemId;
        }
    }
}