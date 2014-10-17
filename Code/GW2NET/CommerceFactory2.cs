using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET
{
    using GW2NET.Common;
    using GW2NET.Entities.Commerce;
    using GW2NET.V2.Commerce;
    using GW2NET.V2.Common;

    public static partial class GW2
    {
        public partial class Factory2
        {
            public partial class CommerceFactory2
            {
                public IRepository<int, Listing> Listings
                {
                    get
                    {
                        return new ListingService(this.ServiceClient);
                    }
                }

                public IRepository<int, AggregateListing> Prices
                {
                    get
                    {
                        return new PriceService(this.ServiceClient);
                    }
                }

                public IBroker<string, ExchangeQuote> Exchange
                {
                    get
                    {
                        return new ExchangeService(this.ServiceClient);
                    }
                }
            }
        }
    }
}
