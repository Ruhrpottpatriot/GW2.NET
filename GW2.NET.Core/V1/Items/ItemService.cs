// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the items service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Entities.Items;
    using GW2DotNET.V1.Items.Json;

    /// <summary>Provides the default implementation of the items service.</summary>
    public class ItemService : IItemService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ItemService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ItemService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int item)
        {
            var culture = new CultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetItemDetails(item, culture);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int item, CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new ItemDetailsRequest { ItemId = item, Culture = language };
            var response = this.serviceClient.Send<ItemContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var value = ConvertItemContract(response.Content);
            value.Language = (response.Culture ?? language).TwoLetterISOLanguageName;
            return value;
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int item)
        {
            var culture = new CultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetItemDetailsAsync(item, culture, CancellationToken.None);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int item, CultureInfo language)
        {
            return this.GetItemDetailsAsync(item, language, CancellationToken.None);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int item, CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetItemDetailsAsync(item, culture, cancellationToken);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int item, CultureInfo language, CancellationToken cancellationToken)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new ItemDetailsRequest { ItemId = item, Culture = language };
            return this.serviceClient.SendAsync<ItemContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return null;
                        }

                        var value = ConvertItemContract(response.Content);
                        value.Language = (response.Culture ?? language).TwoLetterISOLanguageName;
                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public ICollection<int> GetItems()
        {
            Contract.Ensures(Contract.Result<ICollection<int>>() != null);
            var request = new ItemDiscoveryRequest();
            var response = this.serviceClient.Send<ItemCollectionContract>(request);
            if (response.Content == null || response.Content.Items == null)
            {
                return new int[0];
            }

            return response.Content.Items;
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetItemsAsync()
        {
            return this.GetItemsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetItemsAsync(CancellationToken cancellationToken)
        {
            var request = new ItemDiscoveryRequest();
            return this.serviceClient.SendAsync<ItemCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Items == null)
                        {
                            return new int[0];
                        }

                        return response.Content.Items;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertArmorContract(Armor item, ArmorContract content)
        {
            Contract.Requires(item != null);
            Contract.Requires(content != null);
            if (content.WeightClass != null)
            {
                item.WeightClass = ConvertArmorWeightClassContract(content.WeightClass);
            }

            if (content.Defense != null)
            {
                item.Defense = int.Parse(content.Defense);
            }

            if (content.InfusionSlots != null)
            {
                item.InfusionSlots = ConvertInfusionSlotContractCollection(content.InfusionSlots);
            }

            if (content.InfixUpgrade != null)
            {
                ConvertInfixUpgradeContract(item, content.InfixUpgrade);
            }

            if (!string.IsNullOrEmpty(content.SuffixItemId))
            {
                item.SuffixItemId = int.Parse(content.SuffixItemId);
            }

            if (!string.IsNullOrEmpty(content.SecondarySuffixItemId))
            {
                item.SecondarySuffixItemId = int.Parse(content.SecondarySuffixItemId);
            }
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static ArmorWeightClass ConvertArmorWeightClassContract(string content)
        {
            Contract.Requires(content != null);
            return (ArmorWeightClass)Enum.Parse(typeof(ArmorWeightClass), content, true);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="type">The content type.</param>
        /// <returns>An entity.</returns>
        private static int ConvertAttributeContract(IEnumerable<ItemAttributeContract> content, string type)
        {
            Contract.Requires(content != null);
            Contract.Requires(type != null);
            var attributes = content.Where(attribute => attribute.Attribute == type).ToList();
            return attributes.Any() ? attributes.Sum(attribute => int.Parse(attribute.Modifier)) : 0;
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertBackpackContract(Backpack item, BackpackContract content)
        {
            Contract.Requires(item != null);
            Contract.Requires(content != null);
            if (content.InfusionSlots != null)
            {
                item.InfusionSlots = ConvertInfusionSlotContractCollection(content.InfusionSlots);
            }

            if (content.InfixUpgrade != null)
            {
                ConvertInfixUpgradeContract(item, content.InfixUpgrade);
            }

            if (!string.IsNullOrEmpty(content.SuffixItemId))
            {
                item.SuffixItemId = int.Parse(content.SuffixItemId);
            }

            if (!string.IsNullOrEmpty(content.SecondarySuffixItemId))
            {
                item.SecondarySuffixItemId = int.Parse(content.SecondarySuffixItemId);
            }
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertBagContract(Bag item, BagContract content)
        {
            Contract.Requires(item != null);
            Contract.Requires(content != null);

            // Set the bag visibility flag
            if (content.NoSellOrSort != null)
            {
                item.NoSellOrSort = content.NoSellOrSort == "1";
            }

            // Set the bag size
            if (content.Size != null)
            {
                item.Size = int.Parse(content.Size);
            }
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertConsumableContract(Consumable item, ConsumableContract content)
        {
            Contract.Requires(content != null);
            TimeSpan? duration = null;
            string description = null;

            if (!string.IsNullOrEmpty(content.Duration))
            {
                duration = TimeSpan.FromMilliseconds(double.Parse(content.Duration));
            }

            if (!string.IsNullOrEmpty(content.Description))
            {
                description = content.Description;
            }

            var food = item as Food;
            if (food != null)
            {
                food.Duration = duration;
                food.Effect = description;
            }

            var generic = item as GenericConsumable;
            if (generic != null)
            {
                generic.Duration = duration;
                generic.Effect = description;
            }

            var immediate = item as ImmediateConsumable;
            if (immediate != null)
            {
                immediate.Duration = duration;
                immediate.Effect = description;
            }

            var utility = item as Utility;
            if (utility != null)
            {
                utility.Duration = duration;
                utility.Effect = description;
            }

            var dye = item as DyeUnlocker;
            if (dye != null && content.ColorId != null)
            {
                dye.ColorId = int.Parse(content.ColorId);
            }

            var recipe = item as CraftingRecipeUnlocker;
            if (recipe != null && content.RecipeId != null)
            {
                recipe.RecipeId = int.Parse(content.RecipeId);
            }
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static GameTypes ConvertGameTypesContract(string content)
        {
            Contract.Requires(content != null);
            return (GameTypes)Enum.Parse(typeof(GameTypes), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static GameTypes ConvertGameTypesContractCollection(IEnumerable<string> content)
        {
            Contract.Requires(content != null);
            return content.Aggregate(GameTypes.None, (flags, flag) => flags | ConvertGameTypesContract(flag));
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertInfixUpgradeContract(IUpgrade item, InfixUpgradeContract content)
        {
            Contract.Requires(item != null);
            Contract.Requires(content != null);
            if (content.Buff != null)
            {
                item.Buff = ConvertItemBuffContract(content.Buff);
            }

            if (content.Attributes != null)
            {
                item.ConditionDamage = ConvertAttributeContract(content.Attributes, "ConditionDamage");
                item.Ferocity = ConvertAttributeContract(content.Attributes, "CritDamage");
                item.Healing = ConvertAttributeContract(content.Attributes, "Healing");
                item.Power = ConvertAttributeContract(content.Attributes, "Power");
                item.Precision = ConvertAttributeContract(content.Attributes, "Precision");
                item.Toughness = ConvertAttributeContract(content.Attributes, "Toughness");
                item.Vitality = ConvertAttributeContract(content.Attributes, "Vitality");
            }
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static InfusionSlot ConvertInfusionSlotContract(InfusionSlotContract content)
        {
            Contract.Requires(content != null);
            return new InfusionSlot
                       {
                           Flags = MapInfusionSlotFlags(content.Flags), 
                           ItemId = string.IsNullOrEmpty(content.ItemId) ? (int?)null : int.Parse(content.ItemId)
                       };
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<InfusionSlot> ConvertInfusionSlotContractCollection(ICollection<InfusionSlotContract> content)
        {
            Contract.Requires(content != null);
            var values = new List<InfusionSlot>(content.Count);
            values.AddRange(content.Select(ConvertInfusionSlotContract));
            return values;
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static ItemBuff ConvertItemBuffContract(ItemBuffContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<ItemBuff>() != null);

            // Create a new buff object
            var value = new ItemBuff();

            // Set the skill identifier
            if (content.SkillId != null)
            {
                value.SkillId = int.Parse(content.SkillId);
            }

            // Set the description
            if (content.Description != null)
            {
                value.Description = content.Description;
            }

            // Return the buff object
            return value;
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertItemContract(ItemContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Item>() != null);

            // Map type discriminators to .NET types
            var value = (Item)Activator.CreateInstance(GetItemType(content));

            // Map item identifier
            if (content.ItemId != null)
            {
                value.ItemId = int.Parse(content.ItemId);
            }

            // Map item name
            value.Name = content.Name;

            // Map item description
            value.Description = content.Description;

            // Map item level
            if (content.Level != null)
            {
                value.Level = int.Parse(content.Level);
            }

            // Map item rarity
            if (content.Rarity != null)
            {
                value.Rarity = ConvertItemRarityContract(content.Rarity);
            }

            // Map vendor value
            if (content.VendorValue != null)
            {
                value.VendorValue = int.Parse(content.VendorValue);
            }

            // Map icon file identifier
            if (content.IconFileId != null)
            {
                value.FileId = int.Parse(content.IconFileId);
            }

            // Map icon file signature
            if (content.IconFileSignature != null)
            {
                value.FileSignature = content.IconFileSignature;
            }

            // Map item game types
            if (content.GameTypes != null)
            {
                value.GameTypes = ConvertGameTypesContractCollection(content.GameTypes);
            }

            // Map item flags
            if (content.Flags != null)
            {
                value.Flags = ConvertItemFlagsContractCollection(content.Flags);
            }

            // Map item restrictions
            if (content.Restrictions != null)
            {
                value.Restrictions = ConvertItemRestrictionsContractCollection(content.Restrictions);
            }

            // Map default skin if item is skinnable
            if (!string.IsNullOrEmpty(content.DefaultSkin))
            {
                ((ISkinnable)value).DefaultSkinId = int.Parse(content.DefaultSkin);
            }

            // Map type-specific item contracts (maximum 1 contract per type)
            if (content.Armor != null)
            {
                ConvertArmorContract((Armor)value, content.Armor);
            }
            else if (content.Backpack != null)
            {
                ConvertBackpackContract((Backpack)value, content.Backpack);
            }
            else if (content.Bag != null)
            {
                ConvertBagContract((Bag)value, content.Bag);
            }
            else if (content.Consumable != null)
            {
                ConvertConsumableContract((Consumable)value, content.Consumable);
            }
            else if (content.Tool != null)
            {
                ConvertToolContract((Tool)value, content.Tool);
            }
            else if (content.Trinket != null)
            {
                ConvertTrinketContract((Trinket)value, content.Trinket);
            }
            else if (content.UpgradeComponent != null)
            {
                ConvertUpgradeComponentContract((UpgradeComponent)value, content.UpgradeComponent);
            }
            else if (content.Weapon != null)
            {
                ConvertWeaponContract((Weapon)value, content.Weapon);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static ItemFlags ConvertItemFlagsContract(string content)
        {
            Contract.Requires(content != null);
            return (ItemFlags)Enum.Parse(typeof(ItemFlags), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static ItemFlags ConvertItemFlagsContractCollection(IEnumerable<string> content)
        {
            Contract.Requires(content != null);
            return content.Aggregate(ItemFlags.None, (flags, flag) => flags | ConvertItemFlagsContract(flag));
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static ItemRarity ConvertItemRarityContract(string content)
        {
            Contract.Requires(content != null);
            return (ItemRarity)Enum.Parse(typeof(ItemRarity), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static ItemRestrictions ConvertItemRestrictionsContract(string content)
        {
            Contract.Requires(content != null);
            return (ItemRestrictions)Enum.Parse(typeof(ItemRestrictions), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static ItemRestrictions ConvertItemRestrictionsContractCollection(IEnumerable<string> content)
        {
            Contract.Requires(content != null);
            return content.Aggregate(ItemRestrictions.None, (flags, flag) => flags | ConvertItemRestrictionsContract(flag));
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertToolContract(Tool item, ToolContract content)
        {
            Contract.Requires(content != null);
            var salvageTool = item as SalvageTool;
            if (salvageTool != null && content.Charges != null)
            {
                salvageTool.Charges = int.Parse(content.Charges);
            }
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertTrinketContract(Trinket item, TrinketContract content)
        {
            Contract.Requires(item != null);
            Contract.Requires(content != null);
            if (content.InfusionSlots != null)
            {
                item.InfusionSlots = ConvertInfusionSlotContractCollection(content.InfusionSlots);
            }

            if (content.InfixUpgrade != null)
            {
                ConvertInfixUpgradeContract(item, content.InfixUpgrade);
            }

            if (!string.IsNullOrEmpty(content.SuffixItemId))
            {
                item.SuffixItemId = int.Parse(content.SuffixItemId);
            }

            if (!string.IsNullOrEmpty(content.SecondarySuffixItemId))
            {
                item.SecondarySuffixItemId = int.Parse(content.SecondarySuffixItemId);
            }
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertUpgradeComponentContract(UpgradeComponent item, UpgradeComponentContract content)
        {
            Contract.Requires(item != null);
            Contract.Requires(content != null);
            if (content.Flags != null)
            {
                item.UpgradeComponentFlags = MapUpgradeComponentFlags(content.Flags);
            }

            if (content.InfusionUpgradeFlags != null)
            {
                item.InfusionUpgradeFlags = MapInfusionSlotFlags(content.InfusionUpgradeFlags);
            }

            if (content.Bonuses != null)
            {
                item.Bonuses = content.Bonuses;
            }

            if (content.InfixUpgrade != null)
            {
                ConvertInfixUpgradeContract(item, content.InfixUpgrade);
            }

            if (content.Suffix != null)
            {
                item.Suffix = content.Suffix;
            }
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertWeaponContract(Weapon item, WeaponContract content)
        {
            Contract.Requires(item != null);
            Contract.Requires(content != null);
            if (content.DamageType != null)
            {
                item.DamageType = ConvertWeaponDamageTypeContract(content.DamageType);
            }

            if (content.MinimumPower != null)
            {
                item.MinimumPower = int.Parse(content.MinimumPower);
            }

            if (content.MaximumPower != null)
            {
                item.MaximumPower = int.Parse(content.MaximumPower);
            }

            if (content.Defense != null)
            {
                item.Defense = int.Parse(content.Defense);
            }

            if (content.InfusionSlots != null)
            {
                item.InfusionSlots = ConvertInfusionSlotContractCollection(content.InfusionSlots);
            }

            if (content.InfixUpgrade != null)
            {
                ConvertInfixUpgradeContract(item, content.InfixUpgrade);
            }

            if (!string.IsNullOrEmpty(content.SuffixItemId))
            {
                item.SuffixItemId = int.Parse(content.SuffixItemId);
            }

            if (!string.IsNullOrEmpty(content.SecondarySuffixItemId))
            {
                item.SecondarySuffixItemId = int.Parse(content.SecondarySuffixItemId);
            }
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static WeaponDamageType ConvertWeaponDamageTypeContract(string content)
        {
            Contract.Requires(content != null);
            return (WeaponDamageType)Enum.Parse(typeof(WeaponDamageType), content, true);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetArmorType(ArmorContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "Boots":
                    return typeof(Boots);
                case "Coat":
                    return typeof(Coat);
                case "Helm":
                    return typeof(Helm);
                case "Shoulders":
                    return typeof(Shoulders);
                case "Gloves":
                    return typeof(Gloves);
                case "Leggings":
                    return typeof(Leggings);
                case "HelmAquatic":
                    return typeof(HelmAquatic);
            }

            return typeof(UnknownArmor);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetConsumableType(ConsumableContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "AppearanceChange":
                    return typeof(AppearanceChanger);
                case "Booze":
                    return typeof(Alcohol);
                case "ContractNpc":
                    return typeof(ContractNpc);
                case "Food":
                    return typeof(Food);
                case "Generic":
                    return typeof(GenericConsumable);
                case "Halloween":
                    return typeof(HalloweenConsumable);
                case "Immediate":
                    return typeof(ImmediateConsumable);
                case "Transmutation":
                    return typeof(Transmutation);
                case "Unlock":
                    return GetUnlockConsumableType(content);
                case "UnTransmutation":
                    return typeof(UnTransmutation);
                case "UpgradeRemoval":
                    return typeof(UpgradeRemoval);
                case "Utility":
                    return typeof(Utility);
            }

            return typeof(UnknownConsumable);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetContainerType(ContainerContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "Default":
                    return typeof(DefaultContainer);
                case "GiftBox":
                    return typeof(GiftBox);
                case "OpenUI":
                    return typeof(OpenUiContainer);
            }

            return typeof(UnknownContainer);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetGatheringToolType(GatheringToolContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "Foraging":
                    return typeof(ForagingTool);
                case "Logging":
                    return typeof(LoggingTool);
                case "Mining":
                    return typeof(MiningTool);
            }

            return typeof(UnknownGatheringTool);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetGizmoType(GizmoContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "Default":
                    return typeof(DefaultGizmo);
                case "ContainerKey":
                    return typeof(ContainerKey);
                case "RentableContractNpc":
                    return typeof(RentableContractNpc);
                case "UnlimitedConsumable":
                    return typeof(UnlimitedConsumable);
            }

            return typeof(UnknownGizmo);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetItemType(ItemContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "Armor":
                    if (content.Armor == null)
                    {
                        return typeof(UnknownArmor);
                    }

                    return GetArmorType(content.Armor);
                case "Back":
                    return typeof(Backpack);
                case "Bag":
                    return typeof(Bag);
                case "Consumable":
                    if (content.Consumable == null)
                    {
                        return typeof(UnknownConsumable);
                    }

                    return GetConsumableType(content.Consumable);
                case "Container":
                    if (content.Container == null)
                    {
                        return typeof(UnknownContainer);
                    }

                    return GetContainerType(content.Container);
                case "CraftingMaterial":
                    return typeof(CraftingMaterial);
                case "Gathering":
                    if (content.GatheringTool == null)
                    {
                        return typeof(UnknownGatheringTool);
                    }

                    return GetGatheringToolType(content.GatheringTool);
                case "Gizmo":
                    if (content.Gizmo == null)
                    {
                        return typeof(UnknownGizmo);
                    }

                    return GetGizmoType(content.Gizmo);
                case "MiniPet":
                    return typeof(MiniPet);
                case "Tool":
                    if (content.Tool == null)
                    {
                        return typeof(UnknownTool);
                    }

                    return GetToolType(content.Tool);
                case "Trait":
                    return typeof(TraitGuide);
                case "Trinket":
                    if (content.Trinket == null)
                    {
                        return typeof(UnknownTrinket);
                    }

                    return GetTrinketType(content.Trinket);
                case "Trophy":
                    return typeof(Trophy);
                case "UpgradeComponent":
                    if (content.UpgradeComponent == null)
                    {
                        return typeof(UnknownUpgradeComponent);
                    }

                    return GetUpgradeComponentType(content.UpgradeComponent);
                case "Weapon":
                    if (content.Weapon == null)
                    {
                        return typeof(UnknownWeapon);
                    }

                    return GetWeaponType(content.Weapon);
            }

            return typeof(UnknownItem);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetToolType(ToolContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "Salvage":
                    return typeof(SalvageTool);
            }

            return typeof(UnknownTool);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetTrinketType(TrinketContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "Amulet":
                    return typeof(Amulet);
                case "Accessory":
                    return typeof(Accessory);
                case "Ring":
                    return typeof(Ring);
            }

            return typeof(UnknownTrinket);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetUnlockConsumableType(ConsumableContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.UnlockType)
            {
                case "BagSlot":
                    return typeof(BagSlotUnlocker);
                case "BankTab":
                    return typeof(BankTabUnlocker);
                case "CollectibleCapacity":
                    return typeof(CollectibleCapacityUnlocker);
                case "Content":
                    return typeof(ContentUnlocker);
                case "CraftingRecipe":
                    return typeof(CraftingRecipeUnlocker);
                case "Dye":
                    return typeof(DyeUnlocker);
            }

            return typeof(UnknownUnlocker);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetUpgradeComponentType(UpgradeComponentContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "Default":
                    return typeof(DefaultUpgradeComponent);
                case "Gem":
                    return typeof(Gem);
                case "Sigil":
                    return typeof(Sigil);
                case "Rune":
                    return typeof(Rune);
            }

            return typeof(UnknownUpgradeComponent);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetWeaponType(WeaponContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "Axe":
                    return typeof(Axe);
                case "Dagger":
                    return typeof(Dagger);
                case "Focus":
                    return typeof(Focus);
                case "Greatsword":
                    return typeof(GreatSword);
                case "Hammer":
                    return typeof(Hammer);
                case "Harpoon":
                    return typeof(Harpoon);
                case "LongBow":
                    return typeof(LongBow);
                case "Mace":
                    return typeof(Mace);
                case "Pistol":
                    return typeof(Pistol);
                case "Rifle":
                    return typeof(Rifle);
                case "Scepter":
                    return typeof(Scepter);
                case "Shield":
                    return typeof(Shield);
                case "ShortBow":
                    return typeof(ShortBow);
                case "Speargun":
                    return typeof(SpearGun);
                case "Sword":
                    return typeof(Sword);
                case "Staff":
                    return typeof(Staff);
                case "Torch":
                    return typeof(Torch);
                case "Trident":
                    return typeof(Trident);
                case "Warhorn":
                    return typeof(WarHorn);
                case "Toy":
                    return typeof(Toy);
                case "TwoHandedToy":
                    return typeof(TwoHandedToy);
                case "SmallBundle":
                    return typeof(SmallBundle);
                case "LargeBundle":
                    return typeof(LargeBundle);
            }

            return typeof(UnknownWeapon);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static InfusionSlotFlags MapInfusionSlotFlag(string content)
        {
            Contract.Requires(content != null);
            return (InfusionSlotFlags)Enum.Parse(typeof(InfusionSlotFlags), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static InfusionSlotFlags MapInfusionSlotFlags(IEnumerable<string> content)
        {
            return content.Aggregate(InfusionSlotFlags.None, (current, flag) => current | MapInfusionSlotFlag(flag));
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static UpgradeComponentFlags MapUpgradeComponentFlag(string content)
        {
            Contract.Requires(content != null);
            return (UpgradeComponentFlags)Enum.Parse(typeof(UpgradeComponentFlags), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static UpgradeComponentFlags MapUpgradeComponentFlags(IEnumerable<string> content)
        {
            Contract.Requires(content != null);
            return content.Aggregate(UpgradeComponentFlags.None, (current, flag) => current | MapUpgradeComponentFlag(flag));
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}