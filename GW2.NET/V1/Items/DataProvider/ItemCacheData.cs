using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GW2DotNET.V1.Items.Models.Items;

namespace GW2DotNET.V1.Items.DataProvider
{
    [Serializable]
    class ItemCacheData : CacheDataBase
    {
        public IEnumerable<Item> Items;
    }
}
