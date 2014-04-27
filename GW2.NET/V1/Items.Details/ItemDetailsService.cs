// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDetailsService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the item details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Items.Details.Contracts;

    /// <summary>Provides the default implementation of the item details service.</summary>
    public class ItemDetailsService : ServiceBase, IItemDetailsService
    {
        /// <summary>Initializes a new instance of the <see cref="ItemDetailsService" /> class.</summary>
        public ItemDetailsService()
            : this(new ServiceClient(new Uri(Services.DataServiceUrl)))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemDetailsService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ItemDetailsService(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int itemId)
        {
            return this.GetItemDetails(itemId, ServiceBase.DefaultLanguage);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(int itemId, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new ItemDetailsServiceRequest { ItemId = itemId, Language = language };
            var result = this.Request<Item>(serviceRequest);

            // patch missing language information
            result.Language = language;

            return result;
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId)
        {
            return this.GetItemDetailsAsync(itemId, CancellationToken.None);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CultureInfo language)
        {
            return this.GetItemDetailsAsync(itemId, language, CancellationToken.None);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CancellationToken cancellationToken)
        {
            return this.GetItemDetailsAsync(itemId, ServiceBase.DefaultLanguage, cancellationToken);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(int itemId, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new ItemDetailsServiceRequest { ItemId = itemId, Language = language };
            var t1 = this.RequestAsync<Item>(serviceRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        // patch missing language information
                        task.Result.Language = language;

                        return task.Result;
                    }, 
                cancellationToken);

            return t1;
        }
    }
}