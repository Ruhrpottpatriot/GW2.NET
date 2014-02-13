using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GW2DotNET.V1.Items.Models.Items;

namespace GW2DotNET.V1.Items.DataProvider
{
    /// <summary>The item cache data.</summary>
    [Serializable]
    public class ItemCacheData : CacheDataBase
    {
 /// <summary>The items.</summary>
               public IEnumerable<Item> Items;
    }
}
