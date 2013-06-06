using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.V1.Items.DataProvider
{
    [Serializable]
    public class ItemDataCache
    {
        public int build;
        public List<int> itemIds;
        public List<Item> itemsList;
    }
}
