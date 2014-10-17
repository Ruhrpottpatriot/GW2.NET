// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the /v2/items service. See the class remarks for important limitations regarding the default implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Items;
    using GW2NET.V2.Common;
    using GW2NET.V2.Items.Json;

    /// <summary>Provides access to the /v2/items service. See the class remarks for important limitations regarding the default implementation.</summary>
    /// <remarks>
    /// This implementation does not retrieve associated entities.
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="Item.BuildId"/>:</term>
    ///         <description>Always <c>0</c>. Retrieve the build number from the build service.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="ISkinnable.DefaultSkin"/> (applies to <see cref="Armor.DefaultSkin"/>, <see cref="Backpack.DefaultSkin"/>, <see cref="GatheringTool.DefaultSkin"/> and <see cref="Weapon.DefaultSkin"/>):</term>
    ///         <description>Always <c>null</c>. Use the value of <see cref="ISkinnable.DefaultSkinId"/> to retrieve the skin.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IUpgradable.SuffixItem"/> (applies to <see cref="Armor.SuffixItem"/>, <see cref="Backpack.SuffixItem"/>, <see cref="Trinket.SuffixItem"/> and <see cref="Weapon.SuffixItem"/>):</term>
    ///         <description>Always <c>null</c>. Use the value of <see cref="IUpgradable.SuffixItemId"/> to retrieve the suffix item.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IUpgradable.SecondarySuffixItem"/> (applies to <see cref="Armor.SecondarySuffixItem"/>, <see cref="Backpack.SecondarySuffixItem"/>, <see cref="Trinket.SecondarySuffixItem"/> and <see cref="Weapon.SecondarySuffixItem"/>):</term>
    ///         <description>Always <c>null</c>. Use the value of <see cref="IUpgradable.SecondarySuffixItemId"/> to retrieve the secondary suffix item.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="InfusionSlot.Item"/>:</term>
    ///         <description>Always <c>null</c>. Use the value of <see cref="InfusionSlot.ItemId"/> to retrieve the infusion item.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="DyeUnlocker.Color"/>:</term>
    ///         <description>Always <c>null</c>. Use the value of <see cref="DyeUnlocker.ColorId"/> to retrieve the color.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="CraftingRecipeUnlocker.Recipe"/>:</term>
    ///         <description>Always <c>null</c>. Use the value of <see cref="CraftingRecipeUnlocker.RecipeId"/> to retrieve the recipe.</description>
    ///     </item>
    /// </list>
    /// See: <a href="http://wiki.guildwars2.com/wiki/API:2/items">wiki</a>
    /// </remarks>
    public class ItemService : IRepository<int, Item>, ILocalizable
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ItemService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ItemService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public ICollection<int> Discover()
        {
            var request = new ItemDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            if (response.Content == null)
            {
                return new int[0];
            }

            return response.Content;
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync()
        {
            return this.DiscoverAsync(CancellationToken.None);
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new ItemDiscoveryRequest();
            return this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new int[0];
                        }

                        return response.Content;
                    }, 
                cancellationToken);
        }

        /// <summary>Finds the <see cref="Item"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Item"/> with the specified identifier.</returns>
        public Item Find(int identifier)
        {
            var request = new ItemDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo), Culture = this.Culture };
            var response = this.serviceClient.Send<ItemDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var value = ConvertItemDataContract(response.Content);
            value.Locale = response.Culture;
            return value;
        }

        /// <summary>Finds every <see cref="Item"/>.</summary>
        /// <returns>A collection of every <see cref="Item"/>.</returns>
        public IDictionaryRange<int, Item> FindAll()
        {
            var request = new ItemBulkRequest { Culture = this.Culture };
            var response = this.serviceClient.Send<ICollection<ItemDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, Item>(0);
            }

            var values = new DictionaryRange<int, Item>(response.Content.Count)
                {
                    SubtotalCount = response.GetResultCount(), 
                    TotalCount = response.GetResultTotal()
                };

            var locale = response.Culture;
            foreach (var value in response.Content.Select(ConvertItemDataContract))
            {
                value.Locale = locale;
                values.Add(value.ItemId, value);
            }

            return values;
        }

        /// <summary>Finds every <see cref="Item"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Item"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<int, Item> FindAll(ICollection<int> identifiers)
        {
            if (identifiers == null)
            {
                throw new ArgumentNullException("identifiers", "Precondition failed: identifiers != null");
            }

            if (identifiers.Count == 0)
            {
                throw new ArgumentOutOfRangeException("identifiers", "Precondition failed: identifiers.Count > 0");
            }

            Contract.EndContractBlock();

            var request = new ItemBulkRequest
                {
                    Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(), 
                    Culture = this.Culture
                };

            var response = this.serviceClient.Send<ICollection<ItemDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, Item>(0);
            }

            var values = new DictionaryRange<int, Item>(response.Content.Count)
                {
                    SubtotalCount = response.GetResultCount(), 
                    TotalCount = response.GetResultTotal()
                };

            var locale = response.Culture;
            foreach (var value in response.Content.Select(ConvertItemDataContract))
            {
                value.Locale = locale;
                values.Add(value.ItemId, value);
            }

            return values;
        }

        /// <summary>Finds every <see cref="Item"/>.</summary>
        /// <returns>A collection of every <see cref="Item"/>.</returns>
        public Task<IDictionaryRange<int, Item>> FindAllAsync()
        {
            return this.FindAllAsync(CancellationToken.None);
        }

        /// <summary>Finds every <see cref="Item"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="Item"/></returns>
        public Task<IDictionaryRange<int, Item>> FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new ItemBulkRequest { Culture = this.Culture };
            return this.serviceClient.SendAsync<ICollection<ItemDataContract>>(request, cancellationToken).ContinueWith<IDictionaryRange<int, Item>>(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new DictionaryRange<int, Item>(0);
                        }

                        var values = new DictionaryRange<int, Item>(response.Content.Count)
                            {
                                SubtotalCount = response.GetResultCount(), 
                                TotalCount = response.GetResultTotal()
                            };

                        var locale = response.Culture;
                        foreach (var value in response.Content.Select(ConvertItemDataContract))
                        {
                            value.Locale = locale;
                            values.Add(value.ItemId, value);
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Finds every <see cref="Item"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Item"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, Item>> FindAllAsync(ICollection<int> identifiers)
        {
            return this.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <summary>Finds every <see cref="Item"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="Item"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, Item>> FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            if (identifiers == null)
            {
                throw new ArgumentNullException("identifiers", "Precondition failed: identifiers != null");
            }

            if (identifiers.Count == 0)
            {
                throw new ArgumentOutOfRangeException("identifiers", "Precondition failed: identifiers.Count > 0");
            }

            Contract.EndContractBlock();

            var request = new ItemBulkRequest
                {
                    Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(), 
                    Culture = this.Culture
                };

            return this.serviceClient.SendAsync<ICollection<ItemDataContract>>(request, cancellationToken).ContinueWith<IDictionaryRange<int, Item>>(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new DictionaryRange<int, Item>(0);
                        }

                        var values = new DictionaryRange<int, Item>(response.Content.Count)
                            {
                                SubtotalCount = response.GetResultCount(), 
                                TotalCount = response.GetResultTotal()
                            };

                        var locale = response.Culture;
                        foreach (var value in response.Content.Select(ConvertItemDataContract))
                        {
                            value.Locale = locale;
                            values.Add(value.ItemId, value);
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Finds the <see cref="Item"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Item"/> with the specified identifier.</returns>
        public Task<Item> FindAsync(int identifier)
        {
            return this.FindAsync(identifier, CancellationToken.None);
        }

        /// <summary>Finds the <see cref="Item"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Item"/> with the specified identifier.</returns>
        public Task<Item> FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new ItemDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo), Culture = this.Culture };
            return this.serviceClient.SendAsync<ItemDataContract>(request, cancellationToken).ContinueWith<Item>(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return null;
                        }

                        var value = ConvertItemDataContract(response.Content);
                        value.Locale = response.Culture;
                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Item> GetPage(int page)
        {
            var request = new ItemPageRequest { Page = page, Culture = this.Culture };
            var response = this.serviceClient.Send<ICollection<ItemDataContract>>(request);
            if (response.Content == null)
            {
                return new CollectionPage<Item>(0);
            }

            var values = new CollectionPage<Item>(response.Content.Count)
                {
                    PageIndex = page, 
                    PageSize = response.GetPageSize(), 
                    PageCount = response.GetPageTotal(), 
                    SubtotalCount = response.GetResultCount(), 
                    TotalCount = response.GetResultTotal()
                };

            if (values.PageCount > 0)
            {
                values.LastPageIndex = values.PageCount - 1;
                if (values.PageIndex < values.LastPageIndex)
                {
                    values.NextPageIndex = values.PageIndex + 1;
                }

                if (values.PageIndex > values.FirstPageIndex)
                {
                    values.PreviousPageIndex = values.PageIndex - 1;
                }
            }

            var locale = response.Culture;
            foreach (var value in response.Content.Select(ConvertItemDataContract))
            {
                value.Locale = locale;
                values.Add(value);
            }

            return values;
        }

        /// <summary>Gets a page with the specified page number and maximum size.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Item> GetPage(int page, int pageSize)
        {
            var request = new ItemPageRequest { Page = page, PageSize = pageSize, Culture = this.Culture };
            var response = this.serviceClient.Send<ICollection<ItemDataContract>>(request);
            if (response.Content == null)
            {
                return new CollectionPage<Item>(0);
            }

            var values = new CollectionPage<Item>(response.Content.Count)
                {
                    PageIndex = page, 
                    PageSize = response.GetPageSize(), 
                    PageCount = response.GetPageTotal(), 
                    SubtotalCount = response.GetResultCount(), 
                    TotalCount = response.GetResultTotal()
                };

            if (values.PageCount > 0)
            {
                values.LastPageIndex = values.PageCount - 1;
                if (values.PageIndex < values.LastPageIndex)
                {
                    values.NextPageIndex = values.PageIndex + 1;
                }

                if (values.PageIndex > values.FirstPageIndex)
                {
                    values.PreviousPageIndex = values.PageIndex - 1;
                }
            }

            var locale = response.Culture;
            foreach (var value in response.Content.Select(ConvertItemDataContract))
            {
                value.Locale = locale;
                values.Add(value);
            }

            return values;
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Item>> GetPageAsync(int page)
        {
            return this.GetPageAsync(page, CancellationToken.None);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Item>> GetPageAsync(int page, CancellationToken cancellationToken)
        {
            var request = new ItemPageRequest { Page = page, Culture = this.Culture };
            return this.serviceClient.SendAsync<ICollection<ItemDataContract>>(request, cancellationToken).ContinueWith<ICollectionPage<Item>>(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new CollectionPage<Item>(0);
                        }

                        var values = new CollectionPage<Item>(response.Content.Count)
                            {
                                PageIndex = page, 
                                PageSize = response.GetPageSize(), 
                                PageCount = response.GetPageTotal(), 
                                SubtotalCount = response.GetResultCount(), 
                                TotalCount = response.GetResultTotal()
                            };

                        if (values.PageCount > 0)
                        {
                            values.LastPageIndex = values.PageCount - 1;
                            if (values.PageIndex < values.LastPageIndex)
                            {
                                values.NextPageIndex = values.PageIndex + 1;
                            }

                            if (values.PageIndex > values.FirstPageIndex)
                            {
                                values.PreviousPageIndex = values.PageIndex - 1;
                            }
                        }

                        var locale = response.Culture;
                        foreach (var value in response.Content.Select(ConvertItemDataContract))
                        {
                            value.Locale = locale;
                            values.Add(value);
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Item>> GetPageAsync(int page, int pageSize)
        {
            return this.GetPageAsync(page, pageSize, CancellationToken.None);
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Item>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            var request = new ItemPageRequest { Page = page, PageSize = pageSize, Culture = this.Culture };

            return this.serviceClient.SendAsync<ICollection<ItemDataContract>>(request, cancellationToken).ContinueWith<ICollectionPage<Item>>(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new CollectionPage<Item>(0);
                        }

                        var values = new CollectionPage<Item>(response.Content.Count)
                            {
                                PageIndex = page, 
                                PageSize = response.GetPageSize(), 
                                PageCount = response.GetPageTotal(), 
                                SubtotalCount = response.GetResultCount(), 
                                TotalCount = response.GetResultTotal()
                            };

                        if (values.PageCount > 0)
                        {
                            values.LastPageIndex = values.PageCount - 1;
                            if (values.PageIndex < values.LastPageIndex)
                            {
                                values.NextPageIndex = values.PageIndex + 1;
                            }

                            if (values.PageIndex > values.FirstPageIndex)
                            {
                                values.PreviousPageIndex = values.PageIndex - 1;
                            }
                        }

                        var locale = response.Culture;
                        foreach (var value in response.Content.Select(ConvertItemDataContract))
                        {
                            value.Locale = locale;
                            values.Add(value);
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertArmorItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            if (content.Details == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.Id);
                return new UnknownArmor();
            }

            Armor value;
            switch (content.Details.Type)
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
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.Id);
                    value = new UnknownArmor();
                    break;
            }

            int defaultSkinId;
            if (!int.TryParse(content.DefaultSkin, out defaultSkinId))
            {
                Debug.WriteLine("Unknown 'DefaultSkin' for item with ID {0}", content.Id);
            }

            value.DefaultSkinId = defaultSkinId;

            // Set the weight class
            ArmorWeightClass weightClass;
            if (!Enum.TryParse(content.Details.WeightClass, true, out weightClass))
            {
                Debug.WriteLine("Unknown 'WeightClass' for item with ID {0}: {1}", content.Id, content.Details.WeightClass);
            }
            else
            {
                value.WeightClass = weightClass;
            }

            // Set the defense rating
            if (content.Details.Defense.HasValue)
            {
                value.Defense = content.Details.Defense.Value;
            }
            else
            {
                Debug.WriteLine("Unknown 'Defense' for item with ID {0}", content.Id);
            }

            // Set the infusion slots
            if (content.Details.InfusionSlots != null)
            {
                value.InfusionSlots = new List<InfusionSlot>(content.Details.InfusionSlots.Count);

                foreach (var infusionSlotContract in content.Details.InfusionSlots)
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
                                Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}: {1}", content.Id, flag);
                            }
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}", content.Id);
                    }

                    // Set the infusion item identifier
                    infusionSlot.ItemId = infusionSlotContract.ItemId;

                    value.InfusionSlots.Add(infusionSlot);
                }
            }

            // Set the infix upgrade
            if (content.Details.InfixUpgrade != null)
            {
                ConvertInfixUpgradeDataContract(value, content.Details.InfixUpgrade);
            }

            // Set the suffix item identifier
            value.SuffixItemId = content.Details.SuffixItemId;

            // Set the secondary suffix item identifier
            int secondarySuffixItemId;
            if (int.TryParse(content.Details.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                value.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="type">The content type.</param>
        /// <returns>An entity.</returns>
        private static int ConvertAttributeDataContract(IEnumerable<AttributeDataContract> content, string type)
        {
            Contract.Requires(content != null);
            Contract.Requires(type != null);
            var attributes = content.Where(attribute => attribute.Attribute == type).ToList();
            return attributes.Any() ? attributes.Sum(attribute => attribute.Modifier) : 0;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertBackpackItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            if (content.Details == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.Id);
                return new Backpack();
            }

            var value = new Backpack();

            int defaultSkinId;
            if (!int.TryParse(content.DefaultSkin, out defaultSkinId))
            {
                Debug.WriteLine("Unknown 'DefaultSkin' for item with ID {0}", content.Id);
            }
            else
            {
                value.DefaultSkinId = defaultSkinId;
            }

            // Set the infusion slots
            if (content.Details.InfusionSlots != null)
            {
                value.InfusionSlots = new List<InfusionSlot>(content.Details.InfusionSlots.Count);

                foreach (var infusionSlotContract in content.Details.InfusionSlots)
                {
                    var infusionSlot = new InfusionSlot();

                    // Set the infusion upgrade flags
                    if (infusionSlotContract.Flags == null)
                    {
                        Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}", content.Id);
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
                                Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}: {1}", content.Id, flag);
                            }
                        }
                    }

                    // Set the infusion item identifier
                    infusionSlot.ItemId = infusionSlotContract.ItemId;

                    value.InfusionSlots.Add(infusionSlot);
                }
            }

            // Set the infix upgrade
            if (content.Details.InfixUpgrade != null)
            {
                ConvertInfixUpgradeDataContract(value, content.Details.InfixUpgrade);
            }

            // Set the suffix item identifier
            value.SuffixItemId = content.Details.SuffixItemId;

            // Set the secondary suffix item identifier
            int secondarySuffixItemId;
            if (int.TryParse(content.Details.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                value.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertBagItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);

            if (content.Details == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.Id);
                return new Bag();
            }

            var value = new Bag();

            // Set the bag visibility flag
            if (content.Details.NoSellOrSort.HasValue)
            {
                value.NoSellOrSort = content.Details.NoSellOrSort.Value;
            }
            else
            {
                Debug.WriteLine("Unknown 'NoSellOrSort' for item with ID {0}", content.Id);
            }

            // Set the bag size
            if (content.Details.Size.HasValue)
            {
                value.Size = content.Details.Size.Value;
            }
            else
            {
                Debug.WriteLine("Unknown 'Size' for item with ID {0}", content.Id);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertConsumableItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            if (content.Details == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.Id);
                return new UnknownConsumable();
            }

            Consumable value;
            switch (content.Details.Type)
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
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.Id);
                    value = new UnknownConsumable();
                    break;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertContainerItemDataDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            if (content.Details == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.Id);
                return new UnknownContainer();
            }

            Container value;
            switch (content.Details.Type)
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
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.Id);
                    value = new UnknownContainer();
                    break;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertCraftingRecipeUnlockConsumableItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Details != null);

            var value = new CraftingRecipeUnlocker();

            if (content.Details.RecipeId.HasValue)
            {
                value.RecipeId = content.Details.RecipeId.Value;
            }
            else
            {
                Debug.WriteLine("Unknown 'RecipeId' for item with ID {0}", content.Id);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertDyeUnlockConsumableItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Details != null);

            var value = new DyeUnlocker();

            if (content.Details.ColorId.HasValue)
            {
                value.ColorId = content.Details.ColorId.Value;
            }
            else
            {
                Debug.WriteLine("Unknown 'ColorId' for item with ID {0}", content.Id);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertFoodConsumableItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Details != null);

            var value = new Food();

            // Set the duration
            if (content.Details.Duration.HasValue)
            {
                value.Duration = TimeSpan.FromMilliseconds(content.Details.Duration.Value);
            }

            // Set the effect description
            if (!string.IsNullOrEmpty(content.Details.Description))
            {
                value.Effect = content.Details.Description;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertGatheringItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            if (content.Details == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.Id);
                return new UnknownGatheringTool();
            }

            GatheringTool value;
            switch (content.Details.Type)
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
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.Id);
                    value = new UnknownGatheringTool();
                    break;
            }

            int defaultSkinId;
            if (!int.TryParse(content.DefaultSkin, out defaultSkinId))
            {
                Debug.WriteLine("Unknown 'DefaultSkin' for item with ID {0}", content.Id);
            }
            else
            {
                value.DefaultSkinId = defaultSkinId;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertGenericConsumableItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Details != null);

            var value = new GenericConsumable();

            // Set the duration
            if (content.Details.Duration.HasValue)
            {
                value.Duration = TimeSpan.FromMilliseconds(content.Details.Duration.Value);
            }

            // Set the effect description
            if (!string.IsNullOrEmpty(content.Details.Description))
            {
                value.Effect = content.Details.Description;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertGizmoItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            if (content.Details == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.Id);
                return new UnknownGizmo();
            }

            Gizmo value;
            switch (content.Details.Type)
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
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.Id);
                    value = new UnknownGizmo();
                    break;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertImmediateConsumableItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Details != null);

            var value = new ImmediateConsumable();

            // Set the duration
            if (content.Details.Duration.HasValue)
            {
                value.Duration = TimeSpan.FromMilliseconds(content.Details.Duration.Value);
            }

            // Set the effect description
            if (!string.IsNullOrEmpty(content.Details.Description))
            {
                value.Effect = content.Details.Description;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="item">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertInfixUpgradeDataContract(IUpgrade item, InfixUpgradeDataContract content)
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
        private static ItemBuff ConvertItemBuffDataContract(BuffDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<ItemBuff>() != null);

            // Create a new buff object
            var value = new ItemBuff();

            // Set the skill identifier
            value.SkillId = content.SkillId;

            // Set the buff description
            if (!string.IsNullOrEmpty(content.Description))
            {
                value.Description = content.Description;
            }

            // Return the buff object
            return value;
        }

        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The data contract's contents.</param>
        /// <returns>The entities.</returns>
        private static Item ConvertItemDataContract(ItemDataContract content)
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
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.Id);
                    value = new UnknownItem();
                    break;
            }

            // Set the item identifier
            value.ItemId = content.Id;

            // Set the item name
            if (content.Name != null)
            {
                value.Name = content.Name;
            }
            else
            {
                Debug.WriteLine("Unknown 'Name' for item with ID {0}", content.Id);
            }

            // Set the item description
            if (!string.IsNullOrEmpty(content.Description))
            {
                value.Description = content.Description;
            }

            // Set the item level
            value.Level = content.Level;

            // Set the item rarity
            ItemRarity rarity;
            if (Enum.TryParse(content.Rarity, true, out rarity))
            {
                value.Rarity = rarity;
            }
            else
            {
                Debug.WriteLine("Unknown 'Level' for item with ID {0}: {1}", content.Id, content.Rarity);
            }

            // Set the vendor value
            value.VendorValue = content.VendorValue;

            // Set the icon file identifier and signature
            Uri icon;
            if (Uri.TryCreate(content.Icon, UriKind.Absolute, out icon))
            {
                // Set the icon file URL
                value.IconFileUrl = icon;

                // Split the path into segments
                // Format: /file/{signature}/{identifier}.{extension}
                var segments = icon.LocalPath.Split('.')[0].Split('/');

                // Set the icon file signature
                var signature = segments[2];
                if (signature != null)
                {
                    value.IconFileSignature = signature;
                }
                else
                {
                    Debug.WriteLine("Unknown 'FileSignature' for item with ID {0}", content.Id);
                }

                // Set the icon file identifier
                var identifier = segments[3];
                int iconFileId;
                if (int.TryParse(identifier, out iconFileId))
                {
                    value.IconFileId = iconFileId;
                }
                else
                {
                    Debug.WriteLine("Unknown 'FileId' for item with ID {0}: {1}", content.Id, identifier);
                }
            }
            else
            {
                Debug.WriteLine("Unknown 'Icon' for item with ID {0}", content.Id);
            }

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
                        Debug.WriteLine("Unknown 'GameTypes' for item with ID {0}: {1}", content.Id, contract);
                    }
                }
            }
            else
            {
                Debug.WriteLine("Unknown 'GameTypes' for item with ID {0}", content.Id);
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
                        Debug.WriteLine("Unknown 'Flags' for item with ID {0}: {1}", content.Id, contract);
                    }
                }
            }
            else
            {
                Debug.WriteLine("Unknown 'Flags' for item with ID {0}", content.Id);
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
                        Debug.WriteLine("Unknown 'Restrictions' for item with ID {0}: {1}", content.Id, contract);
                    }
                }
            }
            else
            {
                Debug.WriteLine("Unknown 'Restrictions' for item with ID {0}", content.Id);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Tool ConvertSalvageToolItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Details != null);

            var value = new SalvageTool();

            // Set the number of charges
            if (content.Details.Charges.HasValue)
            {
                value.Charges = content.Details.Charges.Value;
            }
            else
            {
                Debug.WriteLine("Unknown 'Charges' for item with ID {0}", content.Id);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertToolItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            if (content.Details == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.Id);
                return new UnknownTool();
            }

            Tool value;
            switch (content.Details.Type)
            {
                case "Salvage":
                    value = ConvertSalvageToolItemDataContract(content);
                    break;
                default:
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.Id);
                    value = new UnknownTool();
                    break;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertTrinketItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            if (content.Details == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.Id);
                return new UnknownTrinket();
            }

            Trinket value;
            switch (content.Details.Type)
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
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.Id);
                    value = new UnknownTrinket();
                    break;
            }

            // Set the infusion slots
            if (content.Details.InfusionSlots != null)
            {
                value.InfusionSlots = new List<InfusionSlot>(content.Details.InfusionSlots.Count);

                foreach (var infusionSlotContract in content.Details.InfusionSlots)
                {
                    var infusionSlot = new InfusionSlot();

                    // Set the infusion upgrade flags
                    if (infusionSlotContract.Flags == null)
                    {
                        Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}", content.Id);
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
                                Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}: {1}", content.Id, flag);
                            }
                        }
                    }

                    // Set the infusion item identifier
                    infusionSlot.ItemId = infusionSlotContract.ItemId;

                    value.InfusionSlots.Add(infusionSlot);
                }
            }

            // Set the infix upgrade
            if (content.Details.InfixUpgrade != null)
            {
                ConvertInfixUpgradeDataContract(value, content.Details.InfixUpgrade);
            }

            // Set the suffix item identifier
            value.SuffixItemId = content.Details.SuffixItemId;

            // Set the secondary suffix item identifier
            int secondarySuffixItemId;
            if (int.TryParse(content.Details.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                value.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertUnlockConsumableItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Details != null);

            Consumable value;
            switch (content.Details.UnlockType)
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
                    Debug.WriteLine("Unknown 'unlock_type' for item with ID {0}", content.Id);
                    value = new UnknownUnlocker();
                    break;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Item ConvertUpgradeComponentItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            if (content.Details == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.Id);
                return new UnknownUpgradeComponent();
            }

            UpgradeComponent value;
            switch (content.Details.Type)
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
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.Id);
                    value = new UnknownUpgradeComponent();
                    break;
            }

            // Set the upgrade flags
            if (content.Details.Flags == null)
            {
                Debug.WriteLine("Unknown 'UpgradeComponentFlags' for item with ID {0}", content.Id);
            }
            else
            {
                foreach (var flag in content.Details.Flags)
                {
                    UpgradeComponentFlags upgradeComponentFlags;
                    if (Enum.TryParse(flag, true, out upgradeComponentFlags))
                    {
                        value.UpgradeComponentFlags |= upgradeComponentFlags;
                    }
                    else
                    {
                        Debug.WriteLine("Unknown 'UpgradeComponentFlags' for item with ID {0}: {1}", content.Id, flag);
                    }
                }
            }

            // Set the infusion upgrade flags
            if (content.Details.Flags == null)
            {
                Debug.WriteLine("Unknown 'InfusionUpgradeFlags' for item with ID {0}", content.Id);
            }
            else
            {
                foreach (var flag in content.Details.InfusionUpgradeFlags)
                {
                    InfusionSlotFlags infusionUpgradeFlags;
                    if (Enum.TryParse(flag, true, out infusionUpgradeFlags))
                    {
                        value.InfusionUpgradeFlags |= infusionUpgradeFlags;
                    }
                    else
                    {
                        Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}: {1}", content.Id, flag);
                    }
                }
            }

            // Set the upgrade bonuses
            if (content.Details.Bonuses != null)
            {
                value.Bonuses = content.Details.Bonuses;
            }

            // Set the infix upgrade
            if (content.Details.InfixUpgrade != null)
            {
                ConvertInfixUpgradeDataContract(value, content.Details.InfixUpgrade);
            }

            // Set the localized suffix
            if (!string.IsNullOrEmpty(content.Details.Suffix))
            {
                value.Suffix = content.Details.Suffix;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Consumable ConvertUtilityConsumableItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Details != null);

            var value = new Utility();

            // Set the duration
            if (content.Details.Duration.HasValue)
            {
                value.Duration = TimeSpan.FromMilliseconds(content.Details.Duration.Value);
            }

            // Set the effect description
            if (!string.IsNullOrEmpty(content.Details.Description))
            {
                value.Effect = content.Details.Description;
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Weapon ConvertWeaponItemDataContract(ItemDataContract content)
        {
            Contract.Requires(content != null);
            if (content.Details == null)
            {
                Debug.WriteLine("No details for item with ID {0}", content.Id);
                return new UnknownWeapon();
            }

            Weapon value;
            switch (content.Details.Type)
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
                    Debug.WriteLine("Unknown 'type' for item with ID {0}", content.Id);
                    value = new UnknownWeapon();
                    break;
            }

            // Set the default skin
            int defaultSkinId;
            if (!int.TryParse(content.DefaultSkin, out defaultSkinId))
            {
                Debug.WriteLine("Unknown 'DefaultSkin' for item with ID {0}", content.Id);
            }
            else
            {
                value.DefaultSkinId = defaultSkinId;
            }

            // Set the damage type
            WeaponDamageType damageType;
            if (!Enum.TryParse(content.Details.DamageType, true, out damageType))
            {
                Debug.WriteLine("Unknown 'DamageType' for item with ID {0}", content.Id);
            }
            else
            {
                value.DamageType = damageType;
            }

            // Set the minimum power rating
            if (content.Details.MinimumPower.HasValue)
            {
                value.MinimumPower = content.Details.MinimumPower.Value;
            }
            else
            {
                Debug.WriteLine("Unknown 'MinimumPower' for item with ID {0}", content.Id);
            }

            // Set the maximum power rating
            if (content.Details.MaximumPower.HasValue)
            {
                value.MaximumPower = content.Details.MaximumPower.Value;
            }
            else
            {
                Debug.WriteLine("Unknown 'MaximumPower' for item with ID {0}", content.Id);
            }

            // Set the defense rating
            if (content.Details.Defense.HasValue)
            {
                value.Defense = content.Details.Defense.Value;
            }
            else
            {
                Debug.WriteLine("Unknown 'Defense' for item with ID {0}", content.Id);
            }

            // Set the infusion slots
            if (content.Details.InfusionSlots != null)
            {
                value.InfusionSlots = new List<InfusionSlot>(content.Details.InfusionSlots.Count);

                foreach (var infusionSlotContract in content.Details.InfusionSlots)
                {
                    var infusionSlot = new InfusionSlot();

                    // Set the infusion upgrade flags
                    if (infusionSlotContract.Flags == null)
                    {
                        Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}", content.Id);
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
                                Debug.WriteLine("Unknown 'InfusionSlotFlags' for item with ID {0}: {1}", content.Id, flag);
                            }
                        }
                    }

                    // Set the infusion item identifier
                    infusionSlot.ItemId = infusionSlotContract.ItemId;

                    value.InfusionSlots.Add(infusionSlot);
                }
            }

            // Set the infix upgrade
            if (content.Details.InfixUpgrade != null)
            {
                ConvertInfixUpgradeDataContract(value, content.Details.InfixUpgrade);
            }

            // Set the suffix item identifier
            value.SuffixItemId = content.Details.SuffixItemId;

            // Set the secondary suffix item identifier
            int secondarySuffixItemId;
            if (int.TryParse(content.Details.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                value.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return value;
        }
    }
}