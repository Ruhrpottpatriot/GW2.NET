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
    using System.Diagnostics;
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
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition failed: serviceClient != null");
            }

            Contract.Ensures(this.serviceClient != null && object.ReferenceEquals(this.serviceClient, serviceClient));

            this.serviceClient = serviceClient;
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int item)
        {
            var culture = new CultureInfo("en");
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
                throw new ArgumentNullException("language", "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new ItemDetailsRequest { ItemId = item, Culture = language };
            var response = this.serviceClient.Send<ItemContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var value = ConvertItemDataContract(response.Content);
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
                throw new ArgumentNullException("language", "Precondition failed: language != null");
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

                    var value = ConvertItemDataContract(response.Content);
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

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertArmorItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            if (content.Armor == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.ItemId);
                return new UnknownArmor();
            }

            Armor value;
            switch (content.Armor.Type)
            {
                case "Boots":
                    value = new Boots();
                    break;
                case "Coat":
                    value = new Coat();
                    break;
                case "Helm":
                    value = new Helm();
                    break;
                case "Shoulders":
                    value = new Shoulders();
                    break;
                case "Gloves":
                    value = new Gloves();
                    break;
                case "Leggings":
                    value = new Leggings();
                    break;
                case "HelmAquatic":
                    value = new HelmAquatic();
                    break;
                default:
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.ItemId);
                    value = new UnknownArmor();
                    break;
            }

            int defaultSkinId;
            if (int.TryParse(content.DefaultSkin, out defaultSkinId))
            {
                value.DefaultSkinId = defaultSkinId;
            }
            else
            {
                Debug.WriteLine("Unknown 'DefaultSkin' for item with ID {0}: {1}", content.ItemId, content.DefaultSkin);
            }

            // Set the weight class
            ArmorWeightClass weightClass;
            if (!Enum.TryParse(content.Armor.WeightClass, true, out weightClass))
            {
                Debug.WriteLine("Unknown 'WeightClass' for item with ID {0}: {1}", content.ItemId, content.Armor.WeightClass);
            }
            else
            {
                value.WeightClass = weightClass;
            }

            // Set the defense rating
            int defense;
            if (!int.TryParse(content.Armor.Defense, out defense))
            {
                Debug.WriteLine("Unknown 'Defense' for item with ID {0}: {1}", content.ItemId, content.Armor.Defense);
            }
            else
            {
                value.Defense = defense;
            }

            // Set the infusion slots
            if (content.Armor.InfusionSlots != null)
            {
                value.InfusionSlots = new List<InfusionSlot>(content.Armor.InfusionSlots.Count);

                foreach (var infusionSlotContract in content.Armor.InfusionSlots)
                {
                    var infusionSlot = new InfusionSlot();

                    // Set the infusion upgrade flags
                    if (infusionSlotContract.Flags == null)
                    {
                        Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}", content.ItemId);
                    }
                    else
                    {
                        foreach (var flag in infusionSlotContract.Flags)
                        {
                            InfusionSlotFlags infusionSlotFlags;
                            if (Enum.TryParse(flag, true, out infusionSlotFlags))
                            {
                                infusionSlot.Flags |= infusionSlotFlags;
                            }
                            else
                            {
                                Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}: {1}", content.ItemId, flag);
                            }
                        }
                    }

                    // Set the infusion item identifier
                    int itemId;
                    if (int.TryParse(infusionSlotContract.ItemId, out itemId))
                    {
                        infusionSlot.ItemId = itemId;
                    }

                    value.InfusionSlots.Add(infusionSlot);
                }
            }

            // Set the infix upgrade
            if (content.Armor.InfixUpgrade != null)
            {
                ConvertInfixUpgradeDataContract(value, content.Armor.InfixUpgrade);
            }

            // Set the suffix item identifier
            int suffixItemId;
            if (int.TryParse(content.Armor.SuffixItemId, out suffixItemId))
            {
                value.SuffixItemId = suffixItemId;
            }

            // Set the secondary suffix item identifier
            int secondarySuffixItemId;
            if (int.TryParse(content.Armor.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                value.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="type">The content type.</param>
        /// <returns>An entity.</returns>
        private static int ConvertAttributeDataContract(IEnumerable<ItemAttributeContract> content, string type)
        {
            Contract.Requires(content != null);
            Contract.Requires(type != null);
            var attributes = content.Where(attribute => attribute.Attribute == type).ToList();
            return attributes.Any() ? attributes.Sum(attribute => int.Parse(attribute.Modifier)) : 0;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertBackpackItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            if (content.Backpack == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.ItemId);
                return new Backpack();
            }

            var value = new Backpack();

            int defaultSkinId;
            if (int.TryParse(content.DefaultSkin, out defaultSkinId))
            {
                value.DefaultSkinId = defaultSkinId;
            }
            else
            {
                Debug.WriteLine("Unknown 'DefaultSkin' for item with ID {0}: {1}", content.ItemId, content.DefaultSkin);
            }

            // Set the infusion slots
            if (content.Backpack.InfusionSlots != null)
            {
                value.InfusionSlots = new List<InfusionSlot>(content.Backpack.InfusionSlots.Count);

                foreach (var infusionSlotContract in content.Backpack.InfusionSlots)
                {
                    var infusionSlot = new InfusionSlot();

                    // Set the infusion upgrade flags
                    if (infusionSlotContract.Flags == null)
                    {
                        Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}", content.ItemId);
                    }
                    else
                    {
                        foreach (var flag in infusionSlotContract.Flags)
                        {
                            InfusionSlotFlags infusionSlotFlags;
                            if (Enum.TryParse(flag, true, out infusionSlotFlags))
                            {
                                infusionSlot.Flags |= infusionSlotFlags;
                            }
                            else
                            {
                                Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}: {1}", content.ItemId, flag);
                            }
                        }
                    }

                    // Set the infusion item identifier
                    int itemId;
                    if (int.TryParse(infusionSlotContract.ItemId, out itemId))
                    {
                        infusionSlot.ItemId = itemId;
                    }

                    value.InfusionSlots.Add(infusionSlot);
                }
            }

            // Set the infix upgrade
            if (content.Backpack.InfixUpgrade != null)
            {
                ConvertInfixUpgradeDataContract(value, content.Backpack.InfixUpgrade);
            }

            // Set the suffix item identifier
            int suffixItemId;
            if (int.TryParse(content.Backpack.SuffixItemId, out suffixItemId))
            {
                value.SuffixItemId = suffixItemId;
            }

            // Set the secondary suffix item identifier
            int secondarySuffixItemId;
            if (int.TryParse(content.Backpack.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                value.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertBagItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);

            if (content.Bag == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.ItemId);
                return new Bag();
            }

            var value = new Bag();

            // Set the bag visibility flag
            int noSellOrSort;
            if (!int.TryParse(content.Bag.NoSellOrSort, out noSellOrSort))
            {
                Debug.WriteLine("Unknown 'NoSellOrSort' for item with ID {0}", content.ItemId);
            }
            else
            {
                value.NoSellOrSort = noSellOrSort == 1;
            }

            // Set the bag size
            int size;
            if (!int.TryParse(content.Bag.Size, out size))
            {
                Debug.WriteLine("Unknown 'Size' for item with ID {0}", content.ItemId);
            }
            else
            {
                value.Size = size;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertConsumableItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            if (content.Consumable == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.ItemId);
                return new UnknownConsumable();
            }

            Consumable value;
            switch (content.Consumable.Type)
            {
                case "AppearanceChange":
                    value = new AppearanceChanger();
                    break;
                case "Booze":
                    value = new Alcohol();
                    break;
                case "ContractNpc":
                    value = new ContractNpc();
                    break;
                case "Food":
                    value = ConvertFoodConsumableItemDataContract(content);
                    break;
                case "Generic":
                    value = ConvertGenericConsumableItemDataContract(content);
                    break;
                case "Halloween":
                    value = new HalloweenConsumable();
                    break;
                case "Immediate":
                    value = ConvertImmediateConsumableItemDataContract(content);
                    break;
                case "Transmutation":
                    value = new Transmutation();
                    break;
                case "Unlock":
                    value = ConvertUnlockConsumableItemDataContract(content);
                    break;
                case "UnTransmutation":
                    value = new UnTransmutation();
                    break;
                case "UpgradeRemoval":
                    value = new UpgradeRemoval();
                    break;
                case "Utility":
                    value = ConvertUtilityConsumableItemDataContract(content);
                    break;
                default:
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.ItemId);
                    value = new UnknownConsumable();
                    break;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertContainerItemDataDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            if (content.Container == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.ItemId);
                return new UnknownContainer();
            }

            Container value;
            switch (content.Container.Type)
            {
                case "Default":
                    value = new DefaultContainer();
                    break;
                case "GiftBox":
                    value = new GiftBox();
                    break;
                case "OpenUI":
                    value = new OpenUiContainer();
                    break;
                default:
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.ItemId);
                    value = new UnknownContainer();
                    break;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertCraftingRecipeUnlockConsumableItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Consumable != null);

            var value = new CraftingRecipeUnlocker();

            int recipeId;
            if (!int.TryParse(content.Consumable.RecipeId, out recipeId))
            {
                Debug.WriteLine("Unknown 'RecipeId' for item with ID {0}", content.ItemId);
            }
            else
            {
                value.RecipeId = recipeId;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertDyeUnlockConsumableItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Consumable != null);

            var value = new DyeUnlocker();

            int colorId;
            if (!int.TryParse(content.Consumable.ColorId, out colorId))
            {
                Debug.WriteLine("Unknown 'ColorId' for item with ID {0}", content.ItemId);
            }
            else
            {
                value.ColorId = colorId;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertFoodConsumableItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Consumable != null);

            var value = new Food();

            // Set the duration
            double duration;
            if (double.TryParse(content.Consumable.Duration, out duration))
            {
                value.Duration = TimeSpan.FromMilliseconds(duration);
            }

            // Set the effect description
            if (!string.IsNullOrEmpty(content.Consumable.Description))
            {
                value.Effect = content.Consumable.Description;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertGatheringItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            if (content.GatheringTool == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.ItemId);
                return new UnknownGatheringTool();
            }

            GatheringTool value;
            switch (content.GatheringTool.Type)
            {
                case "Foraging":
                    value = new ForagingTool();
                    break;
                case "Logging":
                    value = new LoggingTool();
                    break;
                case "Mining":
                    value = new MiningTool();
                    break;
                default:
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.ItemId);
                    value = new UnknownGatheringTool();
                    break;
            }

            int defaultSkinId;
            if (int.TryParse(content.DefaultSkin, out defaultSkinId))
            {
                value.DefaultSkinId = defaultSkinId;
            }
            else
            {
                Debug.WriteLine("Unknown 'DefaultSkin' for item with ID {0}: {1}", content.ItemId, content.DefaultSkin);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertGenericConsumableItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Consumable != null);

            var value = new GenericConsumable();

            // Set the duration
            double duration;
            if (double.TryParse(content.Consumable.Duration, out duration))
            {
                value.Duration = TimeSpan.FromMilliseconds(duration);
            }

            // Set the effect description
            if (!string.IsNullOrEmpty(content.Consumable.Description))
            {
                value.Effect = content.Consumable.Description;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertGizmoItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            if (content.Gizmo == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.ItemId);
                return new UnknownGizmo();
            }

            Gizmo value;
            switch (content.Gizmo.Type)
            {
                case "Default":
                    value = new DefaultGizmo();
                    break;
                case "ContainerKey":
                    value = new ContainerKey();
                    break;
                case "RentableContractNpc":
                    value = new RentableContractNpc();
                    break;
                case "UnlimitedConsumable":
                    value = new UnlimitedConsumable();
                    break;
                default:
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.ItemId);
                    value = new UnknownGizmo();
                    break;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertImmediateConsumableItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Consumable != null);

            var value = new ImmediateConsumable();

            // Set the duration
            double duration;
            if (double.TryParse(content.Consumable.Duration, out duration))
            {
                value.Duration = TimeSpan.FromMilliseconds(duration);
            }

            // Set the effect description
            if (!string.IsNullOrEmpty(content.Consumable.Description))
            {
                value.Effect = content.Consumable.Description;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertInfixUpgradeDataContract(IUpgrade item, InfixUpgradeContract content)
        {
            Contract.Requires(item != null);
            Contract.Requires(content != null);
            if (content.Buff != null)
            {
                item.Buff = ConvertItemBuffDataContract(content.Buff);
            }

            if (content.Attributes != null)
            {
                item.ConditionDamage = ConvertAttributeDataContract(content.Attributes, "ConditionDamage");
                item.Ferocity = ConvertAttributeDataContract(content.Attributes, "CritDamage");
                item.Healing = ConvertAttributeDataContract(content.Attributes, "Healing");
                item.Power = ConvertAttributeDataContract(content.Attributes, "Power");
                item.Precision = ConvertAttributeDataContract(content.Attributes, "Precision");
                item.Toughness = ConvertAttributeDataContract(content.Attributes, "Toughness");
                item.Vitality = ConvertAttributeDataContract(content.Attributes, "Vitality");
            }
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static ItemBuff ConvertItemBuffDataContract(ItemBuffContract content)
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

            // Set the buff description
            if (!string.IsNullOrEmpty(content.Description))
            {
                value.Description = content.Description;
            }

            // Return the buff object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Item>() != null);

            Item value;

            // Convert type discriminators to .NET types
            switch (content.Type)
            {
                case "Armor":
                    value = ConvertArmorItemDataContract(content);
                    break;
                case "Back":
                    value = ConvertBackpackItemDataContract(content);
                    break;
                case "Bag":
                    value = ConvertBagItemDataContract(content);
                    break;
                case "Consumable":
                    value = ConvertConsumableItemDataContract(content);
                    break;
                case "Container":
                    value = ConvertContainerItemDataDataContract(content);
                    break;
                case "CraftingMaterial":
                    value = new CraftingMaterial();
                    break;
                case "Gathering":
                    value = ConvertGatheringItemDataContract(content);
                    break;
                case "Gizmo":
                    value = ConvertGizmoItemDataContract(content);
                    break;
                case "MiniPet":
                    value = new MiniPet();
                    break;
                case "Tool":
                    value = ConvertToolItemDataContract(content);
                    break;
                case "Trait":
                    value = new TraitGuide();
                    break;
                case "Trinket":
                    value = ConvertTrinketItemDataContract(content);
                    break;
                case "Trophy":
                    value = new Trophy();
                    break;
                case "UpgradeComponent":
                    value = ConvertUpgradeComponentItemDataContract(content);
                    break;
                case "Weapon":
                    value = ConvertWeaponItemDataContract(content);
                    break;
                default:
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.ItemId);
                    value = new UnknownItem();
                    break;
            }

            // Set the item identifier
            int itemId;
            if (int.TryParse(content.ItemId, out itemId))
            {
                value.ItemId = itemId;
            }
            else
            {
                Debug.WriteLine("Unknown 'ItemId'");
            }

            // Set the item name
            if (content.Name != null)
            {
                value.Name = content.Name;
            }
            else
            {
                Debug.WriteLine("Unknown 'Name' for item with ID {0}", content.ItemId);
            }

            // Set the item description
            if (!string.IsNullOrEmpty(content.Description))
            {
                value.Description = content.Description;
            }

            // Set the item level
            int level;
            if (int.TryParse(content.Level, out level))
            {
                value.Level = level;
            }
            else
            {
                Debug.WriteLine("Unknown 'Level' for item with ID {0}: {1}", content.ItemId, content.Level);
            }

            // Set the item rarity
            ItemRarity rarity;
            if (Enum.TryParse(content.Rarity, true, out rarity))
            {
                value.Rarity = rarity;
            }
            else
            {
                Debug.WriteLine("Unknown 'Rarity' for item with ID {0}: {1}", content.ItemId, content.Rarity);
            }

            // Set the vendor value
            int vendorValue;
            if (int.TryParse(content.VendorValue, out vendorValue))
            {
                value.VendorValue = vendorValue;
            }
            else
            {
                Debug.WriteLine("Unknown 'VendorValue' for item with ID {0}: {1}", content.ItemId, content.VendorValue);
            }

            // Set the icon file identifier
            int iconFileId;
            if (int.TryParse(content.IconFileId, out iconFileId))
            {
                value.IconFileId = iconFileId;
            }
            else
            {
                Debug.WriteLine("Unknown 'FileId' for item with ID {0}: {1}", content.ItemId, content.IconFileId);
            }

            // Set the icon file signature
            if (content.IconFileSignature != null)
            {
                value.IconFileSignature = content.IconFileSignature;
            }
            else
            {
                Debug.WriteLine("Unknown 'FileSignature' for item with ID {0}", content.ItemId);
            }

            // Set the icon file URL
            const string IconUrlTemplate = @"https://render.guildwars2.com/file/{0}/{1}.{2}";
            var icon = value as IRenderable;
            var iconUrl = string.Format(IconUrlTemplate, icon.FileSignature, iconFileId, "png");
            value.IconFileUrl = new Uri(iconUrl, UriKind.Absolute);

            // Set the item game types
            if (content.GameTypes != null)
            {
                foreach (var contract in content.GameTypes)
                {
                    GameTypes gameType;
                    if (Enum.TryParse(contract, true, out gameType))
                    {
                        value.GameTypes |= gameType;
                    }
                    else
                    {
                        Debug.WriteLine("Unknown 'GameTypes' for item with ID {0}: {1}", content.ItemId, contract);
                    }
                }
            }
            else
            {
                Debug.WriteLine("Unknown 'GameTypes' for item with ID {0}", content.ItemId);
            }

            // Set the item flags
            if (content.Flags != null)
            {
                foreach (var contract in content.Flags)
                {
                    ItemFlags flag;
                    if (Enum.TryParse(contract, true, out flag))
                    {
                        value.Flags |= flag;
                    }
                    else
                    {
                        Debug.WriteLine("Unknown 'Flags' for item with ID {0}: {1}", content.ItemId, contract);
                    }
                }
            }
            else
            {
                Debug.WriteLine("Unknown 'Flags' for item with ID {0}", content.ItemId);
            }

            // Set the item restrictions
            if (content.Restrictions != null)
            {
                foreach (var contract in content.Restrictions)
                {
                    ItemRestrictions restriction;
                    if (Enum.TryParse(contract, true, out restriction))
                    {
                        value.Restrictions |= restriction;
                    }
                    else
                    {
                        Debug.WriteLine("Unknown 'Restrictions' for item with ID {0}: {1}", content.ItemId, contract);
                    }
                }
            }
            else
            {
                Debug.WriteLine("Unknown 'Restrictions' for item with ID {0}", content.ItemId);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Tool ConvertSalvageToolItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Tool != null);

            var value = new SalvageTool();

            // Set the number of charges
            int charges;
            if (!int.TryParse(content.Tool.Charges, out charges))
            {
                Debug.WriteLine("Unknown 'Charges' for item with ID {0}", content.ItemId);
            }
            else
            {
                value.Charges = charges;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertToolItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            if (content.Tool == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.ItemId);
                return new UnknownTool();
            }

            Tool value;
            switch (content.Tool.Type)
            {
                case "Salvage":
                    value = ConvertSalvageToolItemDataContract(content);
                    break;
                default:
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.ItemId);
                    value = new UnknownTool();
                    break;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertTrinketItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            if (content.Trinket == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.ItemId);
                return new UnknownTrinket();
            }

            Trinket value;
            switch (content.Trinket.Type)
            {
                case "Amulet":
                    value = new Amulet();
                    break;
                case "Accessory":
                    value = new Accessory();
                    break;
                case "Ring":
                    value = new Ring();
                    break;
                default:
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.ItemId);
                    value = new UnknownTrinket();
                    break;
            }

            // Set the infusion slots
            if (content.Trinket.InfusionSlots != null)
            {
                value.InfusionSlots = new List<InfusionSlot>(content.Trinket.InfusionSlots.Count);

                foreach (var infusionSlotContract in content.Trinket.InfusionSlots)
                {
                    var infusionSlot = new InfusionSlot();

                    // Set the infusion upgrade flags
                    if (infusionSlotContract.Flags == null)
                    {
                        Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}", content.ItemId);
                    }
                    else
                    {
                        foreach (var flag in infusionSlotContract.Flags)
                        {
                            InfusionSlotFlags infusionSlotFlags;
                            if (Enum.TryParse(flag, true, out infusionSlotFlags))
                            {
                                infusionSlot.Flags |= infusionSlotFlags;
                            }
                            else
                            {
                                Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}: {1}", content.ItemId, flag);
                            }
                        }
                    }

                    // Set the infusion item identifier
                    int itemId;
                    if (int.TryParse(infusionSlotContract.ItemId, out itemId))
                    {
                        infusionSlot.ItemId = itemId;
                    }

                    value.InfusionSlots.Add(infusionSlot);
                }
            }

            // Set the infix upgrade
            if (content.Trinket.InfixUpgrade != null)
            {
                ConvertInfixUpgradeDataContract(value, content.Trinket.InfixUpgrade);
            }

            // Set the suffix item identifier
            int suffixItemId;
            if (int.TryParse(content.Trinket.SuffixItemId, out suffixItemId))
            {
                value.SuffixItemId = suffixItemId;
            }

            // Set the secondary suffix item identifier
            int secondarySuffixItemId;
            if (int.TryParse(content.Trinket.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                value.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertUnlockConsumableItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Consumable != null);

            Consumable value;
            switch (content.Consumable.UnlockType)
            {
                case "BagSlot":
                    value = new BagSlotUnlocker();
                    break;
                case "BankTab":
                    value = new BankTabUnlocker();
                    break;
                case "CollectibleCapacity":
                    value = new CollectibleCapacityUnlocker();
                    break;
                case "Content":
                    value = new ContentUnlocker();
                    break;
                case "CraftingRecipe":
                    value = ConvertCraftingRecipeUnlockConsumableItemDataContract(content);
                    break;
                case "Dye":
                    value = ConvertDyeUnlockConsumableItemDataContract(content);
                    break;
                default:
                    Debug.WriteLine("Unknown 'unlock_type' for item with ID {0}", content.ItemId);
                    value = new UnknownUnlocker();
                    break;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertUpgradeComponentItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            if (content.UpgradeComponent == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.ItemId);
                return new UnknownUpgradeComponent();
            }

            UpgradeComponent value;
            switch (content.UpgradeComponent.Type)
            {
                case "Default":
                    value = new DefaultUpgradeComponent();
                    break;
                case "Gem":
                    value = new Gem();
                    break;
                case "Sigil":
                    value = new Sigil();
                    break;
                case "Rune":
                    value = new Rune();
                    break;
                default:
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.ItemId);
                    value = new UnknownUpgradeComponent();
                    break;
            }

            // Set the upgrade flags
            if (content.UpgradeComponent.Flags == null)
            {
                Debug.WriteLine("Unknown 'UpgradeComponentFlags' for item with ID {0}", content.ItemId);
            }
            else
            {
                foreach (var flag in content.UpgradeComponent.Flags)
                {
                    UpgradeComponentFlags upgradeComponentFlags;
                    if (Enum.TryParse(flag, true, out upgradeComponentFlags))
                    {
                        value.UpgradeComponentFlags |= upgradeComponentFlags;
                    }
                    else
                    {
                        Debug.WriteLine("Unknown 'UpgradeComponentFlags' for item with ID {0}: {1}", content.ItemId, flag);
                    }
                }
            }

            // Set the infusion upgrade flags
            if (content.UpgradeComponent.Flags == null)
            {
                Debug.WriteLine("Unknown 'InfusionUpgradeFlags' for item with ID {0}", content.ItemId);
            }
            else
            {
                foreach (var flag in content.UpgradeComponent.InfusionUpgradeFlags)
                {
                    InfusionSlotFlags infusionUpgradeFlags;
                    if (Enum.TryParse(flag, true, out infusionUpgradeFlags))
                    {
                        value.InfusionUpgradeFlags |= infusionUpgradeFlags;
                    }
                    else
                    {
                        Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}: {1}", content.ItemId, flag);
                    }
                }
            }

            // Set the upgrade bonuses
            if (content.UpgradeComponent.Bonuses != null)
            {
                value.Bonuses = content.UpgradeComponent.Bonuses;
            }

            // Set the infix upgrade
            if (content.UpgradeComponent.InfixUpgrade != null)
            {
                ConvertInfixUpgradeDataContract(value, content.UpgradeComponent.InfixUpgrade);
            }

            // Set the localized suffix
            if (!string.IsNullOrEmpty(content.UpgradeComponent.Suffix))
            {
                value.Suffix = content.UpgradeComponent.Suffix;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertUtilityConsumableItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Consumable != null);

            var value = new Utility();

            // Set the duration
            double duration;
            if (double.TryParse(content.Consumable.Duration, out duration))
            {
                value.Duration = TimeSpan.FromMilliseconds(duration);
            }

            // Set the effect description
            if (!string.IsNullOrEmpty(content.Consumable.Description))
            {
                value.Effect = content.Consumable.Description;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Weapon ConvertWeaponItemDataContract(ItemContract content)
        {
            Contract.Requires(content != null);
            if (content.Weapon == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.ItemId);
                return new UnknownWeapon();
            }

            Weapon value;
            switch (content.Weapon.Type)
            {
                case "Axe":
                    value = new Axe();
                    break;
                case "Dagger":
                    value = new Dagger();
                    break;
                case "Focus":
                    value = new Focus();
                    break;
                case "Greatsword":
                    value = new GreatSword();
                    break;
                case "Hammer":
                    value = new Hammer();
                    break;
                case "Harpoon":
                    value = new Harpoon();
                    break;
                case "LongBow":
                    value = new LongBow();
                    break;
                case "Mace":
                    value = new Mace();
                    break;
                case "Pistol":
                    value = new Pistol();
                    break;
                case "Rifle":
                    value = new Rifle();
                    break;
                case "Scepter":
                    value = new Scepter();
                    break;
                case "Shield":
                    value = new Shield();
                    break;
                case "ShortBow":
                    value = new ShortBow();
                    break;
                case "Speargun":
                    value = new SpearGun();
                    break;
                case "Sword":
                    value = new Sword();
                    break;
                case "Staff":
                    value = new Staff();
                    break;
                case "Torch":
                    value = new Torch();
                    break;
                case "Trident":
                    value = new Trident();
                    break;
                case "Warhorn":
                    value = new WarHorn();
                    break;
                case "Toy":
                    value = new Toy();
                    break;
                case "TwoHandedToy":
                    value = new TwoHandedToy();
                    break;
                case "SmallBundle":
                    value = new SmallBundle();
                    break;
                case "LargeBundle":
                    value = new LargeBundle();
                    break;
                default:
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.ItemId);
                    value = new UnknownWeapon();
                    break;
            }

            // Set the default skin
            int defaultSkinId;
            if (int.TryParse(content.DefaultSkin, out defaultSkinId))
            {
                value.DefaultSkinId = defaultSkinId;
            }
            else
            {
                Debug.WriteLine("Unknown 'DefaultSkin' for item with ID {0}: {1}", content.ItemId, content.DefaultSkin);
            }

            // Set the damage type
            WeaponDamageType damageType;
            if (Enum.TryParse(content.Weapon.DamageType, true, out damageType))
            {
                value.DamageType = damageType;
            }
            else
            {
                Debug.WriteLine("Unknown 'DamageType' for item with ID {0}", content.ItemId);
            }

            // Set the minimum power rating
            int minimumPower;
            if (int.TryParse(content.Weapon.MinimumPower, out minimumPower))
            {
                value.MinimumPower = minimumPower;
            }
            else
            {
                Debug.WriteLine("Unknown 'MinimumPower' for item with ID {0}", content.ItemId);
            }

            // Set the maximum power rating
            int maximumPower;
            if (int.TryParse(content.Weapon.MaximumPower, out maximumPower))
            {
                value.MaximumPower = maximumPower;
            }
            else
            {
                Debug.WriteLine("Unknown 'MaximumPower' for item with ID {0}", content.ItemId);
            }

            // Set the defense rating
            int defense;
            if (int.TryParse(content.Weapon.Defense, out defense))
            {
                value.Defense = defense;
            }
            else
            {
                Debug.WriteLine("Unknown 'Defense' for item with ID {0}", content.ItemId);
            }

            // Set the infusion slots
            if (content.Weapon.InfusionSlots != null)
            {
                value.InfusionSlots = new List<InfusionSlot>(content.Weapon.InfusionSlots.Count);

                foreach (var infusionSlotContract in content.Weapon.InfusionSlots)
                {
                    var infusionSlot = new InfusionSlot();

                    // Set the infusion upgrade flags
                    if (infusionSlotContract.Flags != null)
                    {
                        foreach (var flag in infusionSlotContract.Flags)
                        {
                            InfusionSlotFlags infusionSlotFlags;
                            if (Enum.TryParse(flag, true, out infusionSlotFlags))
                            {
                                infusionSlot.Flags |= infusionSlotFlags;
                            }
                            else
                            {
                                Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}: {1}", content.ItemId, flag);
                            }
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}", content.ItemId);
                    }

                    // Set the infusion item identifier
                    int itemId;
                    if (int.TryParse(infusionSlotContract.ItemId, out itemId))
                    {
                        infusionSlot.ItemId = itemId;
                    }

                    value.InfusionSlots.Add(infusionSlot);
                }
            }

            // Set the infix upgrade
            if (content.Weapon.InfixUpgrade != null)
            {
                ConvertInfixUpgradeDataContract(value, content.Weapon.InfixUpgrade);
            }

            // Set the suffix item identifier
            int suffixItemId;
            if (int.TryParse(content.Weapon.SuffixItemId, out suffixItemId))
            {
                value.SuffixItemId = suffixItemId;
            }

            // Set the secondary suffix item identifier
            int secondarySuffixItemId;
            if (int.TryParse(content.Weapon.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                value.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return value;
        }
    }
}