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
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Items;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Items.Contracts;

    /// <summary>Provides the default implementation of the items service.</summary>
    public class ItemService : IItemService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ItemService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ItemService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int item)
        {
            return this.GetItemDetails(item, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int item, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new ItemDetailsRequest { ItemId = item, Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<ItemContract>());
            var value = MapItemContract(response.Content);
            value.Language = language.TwoLetterISOLanguageName;
            return value;
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int item)
        {
            return this.GetItemDetailsAsync(item, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
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
            return this.GetItemDetailsAsync(item, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int item, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new ItemDetailsRequest { ItemId = item, Culture = language };
            return this.serviceClient.SendAsync(request, new JsonSerializer<ItemContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        var value = MapItemContract(response.Content);
                        value.Language = language.TwoLetterISOLanguageName;
                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public ICollection<int> GetItems()
        {
            var request = new ItemRequest();
            var response = this.serviceClient.Send(request, new JsonSerializer<ItemCollectionContract>());
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
            var request = new ItemRequest();
            return this.serviceClient.SendAsync(request, new JsonSerializer<ItemCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return response.Content.Items;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetArmorType(ArmorContract content)
        {
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
                default:
                    return typeof(UnknownArmor);
            }
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetConsumableType(ConsumableContract content)
        {
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
                default:
                    return typeof(UnknownConsumable);
            }
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetContainerType(ContainerContract content)
        {
            switch (content.Type)
            {
                case "Default":
                    return typeof(DefaultContainer);
                case "GiftBox":
                    return typeof(GiftBox);
                case "OpenUI":
                    return typeof(OpenUiContainer);
                default:
                    return typeof(UnknownContainer);
            }
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetGatheringToolType(GatheringToolContract content)
        {
            switch (content.Type)
            {
                case "Foraging":
                    return typeof(ForagingTool);
                case "Logging":
                    return typeof(LoggingTool);
                case "Mining":
                    return typeof(MiningTool);
                default:
                    return typeof(UnknownGatheringTool);
            }
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetGizmoType(GizmoContract content)
        {
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
                default:
                    return typeof(UnknownGizmo);
            }
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetItemType(ItemContract content)
        {
            switch (content.Type)
            {
                case "Armor":
                    return GetArmorType(content.Armor);
                case "Back":
                    return typeof(Backpack);
                case "Bag":
                    return typeof(Bag);
                case "Consumable":
                    return GetConsumableType(content.Consumable);
                case "Container":
                    return GetContainerType(content.Container);
                case "CraftingMaterial":
                    return typeof(CraftingMaterial);
                case "Gathering":
                    return GetGatheringToolType(content.GatheringTool);
                case "Gizmo":
                    return GetGizmoType(content.Gizmo);
                case "MiniPet":
                    return typeof(MiniPet);
                case "Tool":
                    return GetToolType(content.Tool);
                case "Trait":
                    return typeof(TraitGuide);
                case "Trinket":
                    return GetTrinketType(content.Trinket);
                case "Trophy":
                    return typeof(Trophy);
                case "UpgradeComponent":
                    return GetUpgradeComponentType(content.UpgradeComponent);
                case "Weapon":
                    return GetWeaponType(content.Weapon);
                default:
                    return typeof(UnknownItem);
            }
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetToolType(ToolContract content)
        {
            switch (content.Type)
            {
                case "Salvage":
                    return typeof(SalvageTool);
                default:
                    return typeof(UnknownTool);
            }
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetTrinketType(TrinketContract content)
        {
            switch (content.Type)
            {
                case "Amulet":
                    return typeof(Amulet);
                case "Accessory":
                    return typeof(Accessory);
                case "Ring":
                    return typeof(Ring);
                default:
                    return typeof(UnknownTrinket);
            }
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetUnlockConsumableType(ConsumableContract content)
        {
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
                default:
                    return typeof(UnknownUnlocker);
            }
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetUpgradeComponentType(UpgradeComponentContract content)
        {
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
                default:
                    return typeof(UnknownUpgradeComponent);
            }
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetWeaponType(WeaponContract content)
        {
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
                default:
                    return typeof(UnknownWeapon);
            }
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void MapArmorContract(Armor item, ArmorContract content)
        {
            item.WeightClass = (ArmorWeightClass)Enum.Parse(typeof(ArmorWeightClass), content.WeightClass, true);
            item.Defense = int.Parse(content.Defense);
            item.InfusionSlots = MapInfusionSlotContracts(content.InfusionSlots);
            if (content.InfixUpgrade != null)
            {
                MapInfixUpgradeContract(item, content.InfixUpgrade);
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

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="type">The content type.</param>
        /// <returns>An entity.</returns>
        private static int MapAttributeContract(InfixUpgradeContract content, string type)
        {
            return content.Attributes.Where(attribute => attribute.Attribute == type).Sum(attribute => int.Parse(attribute.Modifier));
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void MapBackpackContract(Backpack item, BackpackContract content)
        {
            item.InfusionSlots = MapInfusionSlotContracts(content.InfusionSlots);
            if (content.InfixUpgrade != null)
            {
                MapInfixUpgradeContract(item, content.InfixUpgrade);
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
        private static void MapBagContract(Bag item, BagContract content)
        {
            item.NoSellOrSort = content.NoSellOrSort == "1";
            item.Size = int.Parse(content.Size);
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void MapConsumableContract(Consumable item, ConsumableContract content)
        {
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
            if (dye != null)
            {
                dye.ColorId = int.Parse(content.ColorId);
            }

            var recipe = item as CraftingRecipeUnlocker;
            if (recipe != null)
            {
                recipe.RecipeId = int.Parse(content.RecipeId);
            }
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void MapInfixUpgradeContract(IUpgrade item, InfixUpgradeContract content)
        {
            item.Buff = MapItemBuffContract(content.Buff);
            item.ConditionDamage = MapAttributeContract(content, "ConditionDamage");
            item.Ferocity = MapAttributeContract(content, "CritDamage");
            item.Healing = MapAttributeContract(content, "Healing");
            item.Power = MapAttributeContract(content, "Power");
            item.Precision = MapAttributeContract(content, "Precision");
            item.Toughness = MapAttributeContract(content, "Toughness");
            item.Vitality = MapAttributeContract(content, "Vitality");
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static InfusionSlot MapInfusionSlotContract(InfusionSlotContract content)
        {
            return new InfusionSlot
                       {
                           Flags = MapInfusionSlotFlags(content.Flags), 
                           ItemId = string.IsNullOrEmpty(content.ItemId) ? (int?)null : int.Parse(content.ItemId)
                       };
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<InfusionSlot> MapInfusionSlotContracts(ICollection<InfusionSlotContract> content)
        {
            var values = new List<InfusionSlot>(content.Count);
            values.AddRange(content.Select(MapInfusionSlotContract));
            return values;
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static InfusionSlotFlags MapInfusionSlotFlag(string content)
        {
            return (InfusionSlotFlags)Enum.Parse(typeof(InfusionSlotFlags), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static InfusionSlotFlags MapInfusionSlotFlags(IEnumerable<string> content)
        {
            return content.Aggregate(InfusionSlotFlags.None, (current, flag) => current | MapInfusionSlotFlag(flag));
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static ItemBuff MapItemBuffContract(ItemBuffContract content)
        {
            if (content == null)
            {
                return null;
            }

            return new ItemBuff { SkillId = int.Parse(content.SkillId), Description = string.IsNullOrEmpty(content.Description) ? null : content.Description };
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item MapItemContract(ItemContract content)
        {
            // Map type discriminators to .NET types
            var value = (Item)Activator.CreateInstance(GetItemType(content));

            // Map item identifier
            value.ItemId = int.Parse(content.ItemId);

            // Map item name
            value.Name = content.Name;

            // Map item description
            value.Description = string.IsNullOrEmpty(content.Description) ? null : content.Description;

            // Map item level
            value.Level = int.Parse(content.Level);

            // Map item rarity
            value.Rarity = (ItemRarity)Enum.Parse(typeof(ItemRarity), content.Rarity, true);

            // Map vendor value
            value.VendorValue = int.Parse(content.VendorValue);

            // Map icon file identifier
            value.FileId = int.Parse(content.IconFileId);

            // Map icon file signature
            value.FileSignature = content.IconFileSignature;

            // Map item game types
            foreach (var gameType in content.GameTypes)
            {
                value.GameTypes |= (GameRestrictions)Enum.Parse(typeof(GameRestrictions), gameType, true);
            }

            // Map item flags
            foreach (var flag in content.Flags)
            {
                value.Flags |= (ItemFlags)Enum.Parse(typeof(ItemFlags), flag, true);
            }

            // Map item restrictions
            foreach (var restriction in content.Restrictions)
            {
                value.Restrictions |= (ItemRestrictions)Enum.Parse(typeof(ItemRestrictions), restriction, true);
            }

            // Map default skin if item is skinnable
            if (!string.IsNullOrEmpty(content.DefaultSkin))
            {
                ((ISkinnable)value).DefaultSkinId = int.Parse(content.DefaultSkin);
            }

            // Map type-specific item contracts (maximum 1 contract per type)
            if (content.Armor != null)
            {
                MapArmorContract((Armor)value, content.Armor);
            }
            else if (content.Backpack != null)
            {
                MapBackpackContract((Backpack)value, content.Backpack);
            }
            else if (content.Bag != null)
            {
                MapBagContract((Bag)value, content.Bag);
            }
            else if (content.Consumable != null)
            {
                MapConsumableContract((Consumable)value, content.Consumable);
            }
            else if (content.Tool != null)
            {
                MapToolContract((Tool)value, content.Tool);
            }
            else if (content.Trinket != null)
            {
                MapTrinketContract((Trinket)value, content.Trinket);
            }
            else if (content.UpgradeComponent != null)
            {
                MapUpgradeComponentContract((UpgradeComponent)value, content.UpgradeComponent);
            }
            else if (content.Weapon != null)
            {
                MapWeaponContract((Weapon)value, content.Weapon);
            }

            return value;
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void MapToolContract(Tool item, ToolContract content)
        {
            var salvageTool = item as SalvageTool;
            if (salvageTool != null)
            {
                salvageTool.Charges = int.Parse(content.Charges);
            }
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void MapTrinketContract(Trinket item, TrinketContract content)
        {
            item.InfusionSlots = MapInfusionSlotContracts(content.InfusionSlots);
            if (content.InfixUpgrade != null)
            {
                MapInfixUpgradeContract(item, content.InfixUpgrade);
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
        private static void MapUpgradeComponentContract(UpgradeComponent item, UpgradeComponentContract content)
        {
            item.UpgradeComponentFlags = MapUpgradeComponentFlags(content.Flags);
            item.InfusionUpgradeFlags = MapInfusionSlotFlags(content.InfusionUpgradeFlags);
            item.Bonuses = content.Bonuses;
            MapInfixUpgradeContract(item, content.InfixUpgrade);
            item.Suffix = content.Suffix;
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static UpgradeComponentFlags MapUpgradeComponentFlag(string content)
        {
            return (UpgradeComponentFlags)Enum.Parse(typeof(UpgradeComponentFlags), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static UpgradeComponentFlags MapUpgradeComponentFlags(IEnumerable<string> content)
        {
            return content.Aggregate(UpgradeComponentFlags.None, (current, flag) => current | MapUpgradeComponentFlag(flag));
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void MapWeaponContract(Weapon item, WeaponContract content)
        {
            item.DamageType = (WeaponDamageType)Enum.Parse(typeof(WeaponDamageType), content.DamageType, true);
            item.MinimumPower = int.Parse(content.MinimumPower);
            item.MaximumPower = int.Parse(content.MaximumPower);
            item.Defense = int.Parse(content.Defense);
            item.InfusionSlots = MapInfusionSlotContracts(content.InfusionSlots);
            if (content.InfixUpgrade != null)
            {
                MapInfixUpgradeContract(item, content.InfixUpgrade);
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
    }
}