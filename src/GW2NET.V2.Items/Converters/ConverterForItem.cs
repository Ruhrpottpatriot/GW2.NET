// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItem.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Item" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;

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
        private readonly IDictionary<string, IConverter<DetailsDataContract, Item>> typeConverters;

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
        public ConverterForItem(IDictionary<string, IConverter<DetailsDataContract, Item>> typeConverters, IConverter<string, ItemRarity> converterForItemRarity, IConverter<ICollection<string>, GameTypes> converterForGameTypes, IConverter<ICollection<string>, ItemFlags> converterForItemFlags, IConverter<ICollection<string>, ItemRestrictions> converterForItemRestrictions)
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

        /// <summary>Converts the given object of type <see cref="ItemDataContract"/> to an object of type <see cref="Item"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Item Convert(ItemDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            Item item;
            IConverter<DetailsDataContract, Item> converterForItem;
            if (this.typeConverters.TryGetValue(value.Type, out converterForItem))
            {
                item = converterForItem.Convert(value.Details);
            }
            else
            {
                Debug.Assert(false, "Unknown type discriminator: " + value.Type);
                item = new UnknownItem();
            }

            item.ItemId = value.Id;
            item.ChatLink = value.ChatLink;
            item.Name = value.Name;
            item.Description = value.Description;
            item.Level = value.Level;
            item.Rarity = this.converterForItemRarity.Convert(value.Rarity);
            item.VendorValue = value.VendorValue;
            var skinnableItem = item as ISkinnable;
            if (skinnableItem != null)
            {
                int defaultSkinId;
                if (int.TryParse(value.DefaultSkin, out defaultSkinId))
                {
                    skinnableItem.DefaultSkinId = defaultSkinId;
                }
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

            // Set the icon file identifier and signature
            Uri icon;
            if (Uri.TryCreate(value.Icon, UriKind.Absolute, out icon))
            {
                // Set the icon file URL
                item.IconFileUrl = icon;

                // Split the path into segments
                // Format: /file/{signature}/{identifier}.{extension}
                var segments = icon.LocalPath.Split('.')[0].Split('/');

                // Set the icon file signature
                if (segments.Length >= 3 && segments[2] != null)
                {
                    item.IconFileSignature = segments[2];
                }

                // Set the icon file identifier
                int iconFileId;
                if (segments.Length >= 4 && int.TryParse(segments[3], out iconFileId))
                {
                    item.IconFileId = iconFileId;
                }
            }

            return item;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<DetailsDataContract, Item>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDataContract, Item>>
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
                { "Weapon", new ConverterForWeapon() }, 
            };
        }
    }
}