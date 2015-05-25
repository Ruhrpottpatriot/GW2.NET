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

    /// <summary>Factory class. Provides factory methods for creating <see cref="ChatLink"/> instances.</summary>
    public class ChatLinkFactory
    {
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
            var converterForBase64 = new ConverterForBase64();
            var converterForChatLink = new ConverterForChatLink();
            var bytes = converterForBase64.Convert(input, null);
            return converterForChatLink.Convert(bytes, null);
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
            return new CoinChatLink
            {
                Quantity = quantity
            };
        }

        /// <summary>Encodes a dialog.</summary>
        /// <param name="dialogId">The dialog identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public DialogChatLink EncodeDialog(int dialogId)
        {
            return new DialogChatLink
            {
                DialogId = dialogId
            };
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

            return new ItemChatLink
            {
                ItemId = itemId,
                Quantity = quantity,
                SuffixItemId = suffixItemId,
                SecondarySuffixItemId = secondarySuffixItemId,
                SkinId = skinId
            };
        }

        /// <summary>Encodes an outfit.</summary>
        /// <param name="outfitId">The outfit identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public OutfitChatLink EncodeOutfit(int outfitId)
        {
            return new OutfitChatLink
            {
                OutfitId = outfitId
            };
        }

        /// <summary>Encodes a point of interest.</summary>
        /// <param name="pointOfInterestId">The point of interest identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public PointOfInterestChatLink EncodePointOfInterest(int pointOfInterestId)
        {
            return new PointOfInterestChatLink
            {
                PointOfInterestId = pointOfInterestId
            };
        }

        /// <summary>Encodes a recipe.</summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public RecipeChatLink EncodeRecipe(int recipeId)
        {
            return new RecipeChatLink
            {
                RecipeId = recipeId
            };
        }

        /// <summary>Encodes a skill.</summary>
        /// <param name="skillId">The skill identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public SkillChatLink EncodeSkill(int skillId)
        {
            return new SkillChatLink
            {
                SkillId = skillId
            };
        }

        /// <summary>Encodes a skin.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public SkinChatLink EncodeSkin(int skinId)
        {
            return new SkinChatLink
            {
                SkinId = skinId
            };
        }

        /// <summary>Encodes a trait.</summary>
        /// <param name="traitId">The trait identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public TraitChatLink EncodeTrait(int traitId)
        {
            return new TraitChatLink
            {
                TraitId = traitId
            };
        }
    }
}