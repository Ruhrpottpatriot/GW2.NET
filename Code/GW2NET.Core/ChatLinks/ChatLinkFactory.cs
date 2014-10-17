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
    using System.Diagnostics.Contracts;
    using System.Linq;

    using GW2NET.Common;

    /// <summary>Factory class. Provides factory methods for creating <see cref="ChatLink"/> instances.</summary>
    public class ChatLinkFactory
    {
        /// <summary>Decodes chat links.</summary>
        /// <param name="input">A chat link.</param>
        /// <returns>A decoded <see cref="ChatLink"/>.</returns>
        public ChatLink Decode(string input)
        {
            Contract.Requires(input != null);

            // Find a converter that can convert the input
            var type = typeof(ChatLink);
            var types = type.Assembly.GetTypes();
            var converterTypes = types.Where(t => t.IsSubclassOf(typeof(ChatLinkConverter)) && t.IsDefined(typeof(ConverterForAttribute), false));
            var converter = converterTypes.Select(Activator.CreateInstance).Cast<ChatLinkConverter>().FirstOrDefault(c => c.CanConvert(input));

            // Ensure that a converter exists
            if (converter == null)
            {
                return null;
            }

            return converter.Decode(input);
        }

        /// <summary>Decodes chat links of the specified type.</summary>
        /// <param name="input">A chat link.</param>
        /// <typeparam name="T">The chat link type.</typeparam>
        /// <returns>A decoded <see cref="ChatLink"/> of the specified type.</returns>
        public T Decode<T>(string input) where T : ChatLink
        {
            Contract.Requires(input != null);

            // Find a converter that can convert the input
            var type = typeof(T);
            var types = type.Assembly.GetTypes();
            var converterTypes = types.Where(t => t.IsSubclassOf(typeof(ChatLinkConverter)));
            var converterType = converterTypes.FirstOrDefault(t => GetAttributes<ConverterForAttribute>(t).Any(converterFor => converterFor.Type == type));

            // Ensure that a converter exists
            if (converterType == null)
            {
                return null;
            }

            var converter = (ChatLinkConverter)Activator.CreateInstance(converterType);

            return (T)converter.Decode(input);
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

        /// <summary>Infrastructure.Returns a collection of custom attributes applied to the specified type.</summary>
        /// <param name="type">The type.</param>
        /// <typeparam name="TAttribute">The type of the attributes.</typeparam>
        /// <returns>The attributes.</returns>
        private static IEnumerable<TAttribute> GetAttributes<TAttribute>(Type type)
        {
            Contract.Requires(type != null);
            Contract.Ensures(Contract.Result<IEnumerable<TAttribute>>() != null);
            return type.GetCustomAttributes(typeof(TAttribute), false).Cast<TAttribute>();
        }
    }
}