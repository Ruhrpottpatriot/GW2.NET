// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatLinkFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Factory class. Provides factory methods for creating <see cref="ChatLink" /> instances.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Linq;

    /// <summary>Factory class. Provides factory methods for creating <see cref="ChatLink"/> instances.</summary>
    public class ChatLinkFactory
    {
        /// <summary>Decodes chat links.</summary>
        /// <param name="input">A chat link.</param>
        /// <returns>A decoded <see cref="ChatLink"/>.</returns>
        public ChatLink Decode(string input)
        {
            Contract.Requires(input != null);
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            var baseType = typeof(ChatLink);
            var chatLinkTypes = this.GetType().Assembly.GetTypes().Where(link => link.IsSubclassOf(baseType));
            var typeConverter = chatLinkTypes.Select(TypeDescriptor.GetConverter).FirstOrDefault(converter => converter.IsValid(input));
            if (typeConverter == null)
            {
                throw new NotSupportedException("The specified chat link is not supported.");
            }

            var chatLink = (ChatLink)typeConverter.ConvertFromString(input);
            Contract.Assume(chatLink != null);
            return chatLink;
        }

        /// <summary>Decodes chat links of the specified type.</summary>
        /// <param name="input">A chat link.</param>
        /// <typeparam name="T">The chat link type.</typeparam>
        /// <returns>A decoded <see cref="ChatLink"/> of the specified type.</returns>
        public T Decode<T>(string input) where T : ChatLink
        {
            Contract.Requires(input != null);
            Contract.Ensures(Contract.Result<T>() != null);
            var typeConverter = TypeDescriptor.GetConverter(typeof(T));
            Contract.Assume(typeConverter != null);
            if (!typeConverter.IsValid(input))
            {
                throw new InvalidOperationException(string.Format("The specified input is not of type '{0}'", typeof(T).Name));
            }

            var chatLink = (T)typeConverter.ConvertFromString(input);
            Contract.Assume(chatLink != null);
            return chatLink;
        }

        /// <summary>Encodes an amount of coins.</summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public ChatLink EncodeCoins(int quantity)
        {
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            return new CoinChatLink { Quantity = quantity };
        }

        /// <summary>Encodes a dialog.</summary>
        /// <param name="dialogId">The dialog identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public ChatLink EncodeDialog(int dialogId)
        {
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            return new DialogChatLink { DialogId = dialogId };
        }

        /// <summary>Encodes an item.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="suffixItemId">The suffix item identifier.</param>
        /// <param name="secondarySuffixItemId">The secondary suffix item identifier.</param>
        /// <param name="skinId">The skin identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public ChatLink EncodeItem(int itemId, int quantity = 1, int? suffixItemId = null, int? secondarySuffixItemId = null, int? skinId = null)
        {
            Contract.Requires(quantity >= 1);
            Contract.Requires(quantity <= 255);
            Contract.Ensures(Contract.Result<ChatLink>() != null);
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
        public ChatLink EncodeOutfit(int outfitId)
        {
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            return new OutfitChatLink { OutfitId = outfitId };
        }

        /// <summary>Encodes a point of interest.</summary>
        /// <param name="pointOfInterestId">The point of interest identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public ChatLink EncodePointOfInterest(int pointOfInterestId)
        {
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            return new PointOfInterestChatLink { PointOfInterestId = pointOfInterestId };
        }

        /// <summary>Encodes a recipe.</summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public ChatLink EncodeRecipe(int recipeId)
        {
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            return new RecipeChatLink { RecipeId = recipeId };
        }

        /// <summary>Encodes a skill.</summary>
        /// <param name="skillId">The skill identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public ChatLink EncodeSkill(int skillId)
        {
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            return new SkillChatLink { SkillId = skillId };
        }

        /// <summary>Encodes a skin.</summary>
        /// <param name="skinId">The skin identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public ChatLink EncodeSkin(int skinId)
        {
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            return new SkinChatLink { SkinId = skinId };
        }

        /// <summary>Encodes a trait.</summary>
        /// <param name="traitId">The trait identifier.</param>
        /// <returns>A <see cref="ChatLink"/>.</returns>
        public ChatLink EncodeTrait(int traitId)
        {
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            return new TraitChatLink { TraitId = traitId };
        }
    }
}