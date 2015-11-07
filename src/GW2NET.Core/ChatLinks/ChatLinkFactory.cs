// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatLinkFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Factory class. Provides factory methods for creating <see cref="ChatLink" /> instances.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    using GW2NET.ChatLinks.Interop;

    /// <summary>Factory class. Provides factory methods for creating <see cref="ChatLink"/> instances.</summary>
    public class ChatLinkFactory
    {
        private static readonly int Size = Marshal.SizeOf(typeof(ChatLinkStruct));

        /// <summary>Decodes chat links.</summary>
        /// <param name="input">A chat link.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="input"/> is a null reference.</exception>
        /// <returns>A decoded <see cref="ChatLink"/>.</returns>
        public ChatLink Decode(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input", "Precondition: input != null");
            }

            input = input.Trim('[', ']', '&');
            byte[] bytes = new byte[Size];
            Convert.FromBase64String(input).CopyTo(bytes, 0);
            var ptr = Marshal.AllocHGlobal(Size);
            var link = new ChatLinkStruct();
            try
            {
                Marshal.Copy(bytes, 0, ptr, Size);
                Marshal.PtrToStructure(ptr, link);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            switch (link.header)
            {
                case Header.Coin:
                    return new CoinChatLink { Quantity = link.coin.count };
                case Header.Item:
                    var chatLink = new ItemChatLink
                    {
                        ItemId = (int)link.item.itemId.Value,
                        Quantity = link.item.count,
                    };

                    var modifiers = new Stack<int>(3);
                    modifiers.Push(link.item.modifier3);
                    modifiers.Push(link.item.modifier2);
                    modifiers.Push(link.item.modifier1);
                    if (link.item.Modifiers.HasFlag(ItemModifiers.Skin))
                    {
                        chatLink.SkinId = modifiers.Pop();
                    }

                    if (link.item.Modifiers.HasFlag(ItemModifiers.SuffixItem))
                    {
                        chatLink.SuffixItemId = modifiers.Pop();
                    }

                    if (link.item.Modifiers.HasFlag(ItemModifiers.SecondarySuffixItem))
                    {
                        chatLink.SecondarySuffixItemId = modifiers.Pop();
                    }

                    return chatLink;
                case Header.Text:
                    return new DialogChatLink { DialogId = link.text.dialogId };
                case Header.Map:
                    return new PointOfInterestChatLink { PointOfInterestId = link.map.pointOfInterestId };
                case Header.Skill:
                    return new SkillChatLink { SkillId = link.skill.skillId };
                case Header.Trait:
                    return new TraitChatLink { TraitId = link.trait.traitId };
                case Header.Recipe:
                    return new RecipeChatLink { RecipeId = link.recipe.recipeId };
                case Header.Skin:
                    return new SkinChatLink { SkinId = link.skin.skinId };
                case Header.Outfit:
                    return new OutfitChatLink { OutfitId = link.outfit.outfitId };
                default:
                    return null;
            }
        }

        /// <summary>Decodes chat links of the specified type.</summary>
        /// <param name="input">A chat link.</param>
        /// <typeparam name="T">The chat link type.</typeparam>
        /// <exception cref="ArgumentNullException">The value of <paramref name="input"/> is a null reference.</exception>
        /// <returns>A decoded <see cref="ChatLink"/> of the specified type.</returns>
        public T Decode<T>(string input) where T : ChatLink
        {
            if (input == null)
            {
                throw new ArgumentNullException("input", "Precondition: input != null");
            }

            return this.Decode(input) as T;
        }

        /// <summary>Encodes an amount of coins.</summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public CoinChatLink EncodeCoins(int quantity)
        {
            return new CoinChatLink { Quantity = quantity };
        }

        /// <summary>Encodes a dialog.</summary>
        /// <param name="dialogId">The dialog identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public DialogChatLink EncodeDialog(int dialogId)
        {
            return new DialogChatLink { DialogId = dialogId };
        }

        /// <summary>Encodes an item.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="suffixItemId">The suffix item identifier.</param>
        /// <param name="secondarySuffixItemId">The secondary suffix item identifier.</param>
        /// <param name="skinId">The skin identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public ItemChatLink EncodeItem(int itemId, int quantity = 1, int? suffixItemId = null, int? secondarySuffixItemId = null, int? skinId = null)
        {
            if (quantity < 1)
            {
                throw new ArgumentOutOfRangeException("quantity", quantity, "Precondition: quantity > 0");
            }

            if (quantity > 255)
            {
                throw new ArgumentOutOfRangeException("quantity", quantity, "Precondition: quantity < 256");
            }

            return new ItemChatLink { ItemId = itemId, Quantity = quantity, SuffixItemId = suffixItemId, SecondarySuffixItemId = secondarySuffixItemId, SkinId = skinId };
        }

        /// <summary>Encodes an outfit.</summary>
        /// <param name="outfitId">The outfit identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public OutfitChatLink EncodeOutfit(int outfitId)
        {
            return new OutfitChatLink { OutfitId = outfitId };
        }

        /// <summary>Encodes a point of interest.</summary>
        /// <param name="pointOfInterestId">The point of interest identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public PointOfInterestChatLink EncodePointOfInterest(int pointOfInterestId)
        {
            return new PointOfInterestChatLink { PointOfInterestId = pointOfInterestId };
        }

        /// <summary>Encodes a recipe.</summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public RecipeChatLink EncodeRecipe(int recipeId)
        {
            return new RecipeChatLink { RecipeId = recipeId };
        }

        /// <summary>Encodes a skill.</summary>
        /// <param name="skillId">The skill identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public SkillChatLink EncodeSkill(int skillId)
        {
            return new SkillChatLink { SkillId = skillId };
        }

        /// <summary>Encodes a skin.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public SkinChatLink EncodeSkin(int skinId)
        {
            return new SkinChatLink { SkinId = skinId };
        }

        /// <summary>Encodes a trait.</summary>
        /// <param name="traitId">The trait identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public TraitChatLink EncodeTrait(int traitId)
        {
            return new TraitChatLink { TraitId = traitId };
        }
    }
}