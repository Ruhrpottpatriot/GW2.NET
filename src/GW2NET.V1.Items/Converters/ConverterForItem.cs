// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItem.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Item" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="Item"/>.</summary>
    internal sealed class ConverterForItem : IConverter<ItemDataContract, Item>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, GameTypes> converterForGameTypes;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, ItemFlags> converterForItemFlags;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, ItemRarity> converterForItemRarity;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, ItemRestrictions> converterForItemRestrictions;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<ItemDataContract, Item>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForItem"/> class.</summary>
        public ConverterForItem()
            : this(GetKnownTypeConverters(), new ConverterForItemRarity(), new ConverterForGameTypeCollection(), new ConverterForItemFlagCollection(), new ConverterForItemRestrictionCollection())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForItem"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForItemRarity">The converter for <see cref="ItemRarity"/>.</param>
        /// <param name="converterForGameTypes">The converter for <see cref="GameTypes"/>.</param>
        /// <param name="converterForItemFlags">The converter for <see cref="ItemFlags"/>.</param>
        /// <param name="converterForItemRestrictions">The converter for <see cref="ItemRestrictions"/>.</param>
        public ConverterForItem(IDictionary<string, IConverter<ItemDataContract, Item>> typeConverters, IConverter<string, ItemRarity> converterForItemRarity, IConverter<ICollection<string>, GameTypes> converterForGameTypes, IConverter<ICollection<string>, ItemFlags> converterForItemFlags, IConverter<ICollection<string>, ItemRestrictions> converterForItemRestrictions)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            if (converterForItemRarity == null)
            {
                throw new ArgumentNullException("converterForItemRarity", "Precondition: converterForItemRarity != null");
            }

            if (converterForGameTypes == null)
            {
                throw new ArgumentNullException("converterForGameTypes", "Precondition: converterForGameTypes != null");
            }

            if (converterForItemFlags == null)
            {
                throw new ArgumentNullException("converterForItemFlags", "Precondition: converterForItemFlags != null");
            }

            if (converterForItemRestrictions == null)
            {
                throw new ArgumentNullException("converterForItemRestrictions", "Precondition: converterForItemRestrictions != null");
            }

            this.typeConverters = typeConverters;
            this.converterForItemRarity = converterForItemRarity;
            this.converterForGameTypes = converterForGameTypes;
            this.converterForItemFlags = converterForItemFlags;
            this.converterForItemRestrictions = converterForItemRestrictions;
        }

        /// <inheritdoc />
        public Item Convert(ItemDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            Item item;
            IConverter<ItemDataContract, Item> converter;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                item = converter.Convert(value);
            }
            else
            {
                item = new UnknownItem();
            }

            int itemId;
            if (int.TryParse(value.ItemId, out itemId))
            {
                item.ItemId = itemId;
            }

            item.Name = value.Name;
            item.Description = value.Description;

            int level;
            if (int.TryParse(value.Level, out level))
            {
                item.Level = level;
            }

            item.Rarity = this.converterForItemRarity.Convert(value.Rarity);

            int vendorValue;
            if (int.TryParse(value.VendorValue, out vendorValue))
            {
                item.VendorValue = vendorValue;
            }

            var gameTypes = value.GameTypes;
            if (gameTypes != null)
            {
                item.GameTypes = this.converterForGameTypes.Convert(gameTypes);
            }

            var flags = value.Flags;
            if (flags != null)
            {
                item.Flags = this.converterForItemFlags.Convert(flags);
            }

            var restrictions = value.Restrictions;
            if (restrictions != null)
            {
                item.Restrictions = this.converterForItemRestrictions.Convert(restrictions);
            }

            int iconFileId;
            if (int.TryParse(value.IconFileId, out iconFileId))
            {
                item.IconFileId = iconFileId;
            }

            // Set the icon file signature
            item.IconFileSignature = value.IconFileSignature;

            // Set the icon file URL
            const string IconUrlTemplate = @"https://render.guildwars2.com/file/{0}/{1}.{2}";
            var iconUrl = string.Format(IconUrlTemplate, value.IconFileSignature, value.IconFileId, "png");
            item.IconFileUrl = new Uri(iconUrl, UriKind.Absolute);

            return item;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<ItemDataContract, Item>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<ItemDataContract, Item>>
            {
                { "Armor", new ConverterForArmor() }, 
                { "Back", new ConverterForBackpack() }, 
                { "Bag", new ConverterForBag() }, 
                { "Consumable", new ConverterForConsumable() }, 
                { "Container", new ConverterForContainer() }, 
                { "CraftingMaterial", new ConverterForCraftingMaterial() }, 
                { "Gathering", new ConverterForGatheringTool() }, 
                { "Gizmo", new ConverterForGizmo() }, 
                { "MiniPet", new ConverterForMiniature() }, 
                { "Tool", new ConverterForTool() }, 
                { "Trait", new ConverterForTraitGuide() }, 
                { "Trinket", new ConverterForTrinket() }, 
                { "Trophy", new ConverterForTrophy() }, 
                { "UpgradeComponent", new ConverterForUpgradeComponent() }, 
                { "Weapon", new ConverterForWeapon() }
            };
        }
    }
}