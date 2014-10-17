using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET
{
    using GW2NET.Common;
    using GW2NET.Entities.Items;
    using GW2NET.Entities.Quaggans;
    using GW2NET.V2.Common;
    using GW2NET.V2.Items;
    using GW2NET.V2.Quaggans;

    public static partial class GW2
    {
        public partial class Factory2
        {
            public IRepository<int, Item> Items
            {
                get
                {
                    return new ItemService(this.ServiceClient);
                }
            }

            public IRepository<string, Quaggan> Quaggans
            {
                get
                {
                    return new QuagganService(this.ServiceClient);
                }
            }

            public CommerceFactory2 Commerce
            {
                get
                {
                    return new CommerceFactory2(this.ServiceClient);
                }
            }
        }
    }
}