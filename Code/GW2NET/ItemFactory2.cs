using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET
{
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Runtime.CompilerServices;

    using GW2NET.Common;
    using GW2NET.Entities.Items;
    using GW2NET.Entities.Quaggans;
    using GW2NET.V2.Items;
    using GW2NET.V2.Quaggans;

    public class ItemFactory2 : ServiceFactory
    {
        /// <summary>Initializes a new instance of the <see cref="ServiceFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ItemFactory2(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        [IndexerName("Language")]
        public IRepository<int, Item> this[string language]
        {
            get
            {
                return new ItemService(this.ServiceClient) { Culture = new CultureInfo(language) };
            }
        }

        public IRepository<int, Item> Default
        {
            get
            {
                return new ItemService(this.ServiceClient);
            }
        }

        public IRepository<int, Item> ForCurrentCulture
        {
            get
            {
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IRepository<int, Item> ForCurrentUICulture
        {
            get
            {
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
