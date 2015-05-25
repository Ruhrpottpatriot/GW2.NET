// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForV2Commerce.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to commerce data sources.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;

    using GW2NET.V2.Commerce.Exchange;
    using GW2NET.V2.Commerce.Listings;
    using GW2NET.V2.Commerce.Prices;

    using GW2NET.Commerce;
    using GW2NET.Common;

    /// <summary>Provides access to commerce data sources.</summary>
    public class FactoryForV2Commerce : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForV2Commerce"/> class. Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV2Commerce(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Provides access to the gem exchange data source.</summary>
        public ExchangeBrokerFactory Exchange
        {
            get
            {
                Contract.Ensures(Contract.Result<ExchangeBrokerFactory>() != null);
                return new ExchangeBrokerFactory(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the listings data source.</summary>
        public IListingRepository Listings
        {
            get
            {
                Contract.Ensures(Contract.Result<IListingRepository>() != null);
                return new ListingRepository(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the aggregate listings data source.</summary>
        public IAggregateListingRepository Prices
        {
            get
            {
                Contract.Ensures(Contract.Result<IAggregateListingRepository>() != null);
                return new AggregateListingRepository(this.ServiceClient);
            }
        }
    }
}