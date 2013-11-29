// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemIdCacheData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemIdCacheData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.V1.Items.DataProvider
{
    /// <summary>The item id cache data.</summary>
    [Serializable]
    public class ItemIdCacheData : CacheDataBase
    {
        /// <summary>The item ids.</summary>
        public IEnumerable<int> ItemIds;
    }
}
