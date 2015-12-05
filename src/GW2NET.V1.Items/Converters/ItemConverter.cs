// <copyright file="ItemConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;
    using ChatLinks;
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    public partial class ItemConverter
    {
        private readonly IConverter<ICollection<string>, GameTypes> gameTypesConverter;

        private readonly IConverter<ICollection<string>, ItemFlags> itemFlagsConverter;

        private readonly IConverter<string, ItemRarity> itemRarityConverter;

        private readonly IConverter<ICollection<string>, ItemRestrictions> itemRestrictionsConverter;

        public ItemConverter(
            ITypeConverterFactory<ItemDTO, Item> converterFactory,
            IConverter<string, ItemRarity> itemRarityConverter,
            IConverter<ICollection<string>, GameTypes> gameTypesConverter,
            IConverter<ICollection<string>, ItemFlags> itemFlagsConverter,
            IConverter<ICollection<string>, ItemRestrictions> itemRestrictionsConverter)
            : this(converterFactory)
        {
            if (itemRarityConverter == null)
            {
                throw new ArgumentNullException("itemRarityConverter");
            }

            if (itemRarityConverter == null)
            {
                throw new ArgumentNullException("itemRarityConverter");
            }

            if (gameTypesConverter == null)
            {
                throw new ArgumentNullException("gameTypesConverter");
            }

            if (itemFlagsConverter == null)
            {
                throw new ArgumentNullException("itemFlagsConverter");
            }

            if (itemRestrictionsConverter == null)
            {
                throw new ArgumentNullException("itemRestrictionsConverter");
            }

            this.itemRarityConverter = itemRarityConverter;
            this.gameTypesConverter = gameTypesConverter;
            this.itemFlagsConverter = itemFlagsConverter;
            this.itemRestrictionsConverter = itemRestrictionsConverter;
        }

        partial void Merge(Item entity, ItemDTO dto, object state)
        {
            ItemChatLink chatLink = new ItemChatLink { Quantity = 1 };
            int itemId;
            if (int.TryParse(dto.ItemId, out itemId))
            {
                entity.ItemId = itemId;
            }

            entity.Name = dto.Name;
            entity.Description = dto.Description;

            int level;
            if (int.TryParse(dto.Level, out level))
            {
                entity.Level = level;
            }

            entity.Rarity = this.itemRarityConverter.Convert(dto.Rarity, dto);

            int vendorValue;
            if (int.TryParse(dto.VendorValue, out vendorValue))
            {
                entity.VendorValue = vendorValue;
            }

            var gameTypes = dto.GameTypes;
            if (gameTypes != null)
            {
                entity.GameTypes = this.gameTypesConverter.Convert(gameTypes, dto);
            }

            var flags = dto.Flags;
            if (flags != null)
            {
                entity.Flags = this.itemFlagsConverter.Convert(flags, dto);
            }

            var restrictions = dto.Restrictions;
            if (restrictions != null)
            {
                entity.Restrictions = this.itemRestrictionsConverter.Convert(restrictions, dto);
            }

            int iconFileId;
            if (int.TryParse(dto.IconFileId, out iconFileId))
            {
                entity.IconFileId = iconFileId;
            }

            // Set the icon file signature
            entity.IconFileSignature = dto.IconFileSignature;

            // Set the icon file URL
            const string IconUrlTemplate = @"https://render.guildwars2.com/file/{0}/{1}.{2}";
            var iconUrl = string.Format(IconUrlTemplate, dto.IconFileSignature, dto.IconFileId, "png");
            entity.IconFileUrl = new Uri(iconUrl, UriKind.Absolute);

            var skinnable = entity as ISkinnable;
            if (skinnable != null)
            {
                int defaultSkinId;
                if (int.TryParse(dto.DefaultSkin, out defaultSkinId))
                {
                    skinnable.DefaultSkinId = defaultSkinId;
                    chatLink.SkinId = defaultSkinId;
                }
            }

            var upgrade = entity as IUpgradable;
            if (upgrade != null)
            {
                chatLink.SuffixItemId = upgrade.SuffixItemId;
                chatLink.SecondarySuffixItemId = upgrade.SecondarySuffixItemId;
            }

            entity.ChatLink = chatLink.ToString();
        }
    }
}