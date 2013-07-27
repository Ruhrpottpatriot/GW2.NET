using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.V1.Items.DataProvider
{
    [Serializable]
    class ItemIdCacheData : CacheDataBase
    {
        public IEnumerable<int> ItemIds;
    }
}
