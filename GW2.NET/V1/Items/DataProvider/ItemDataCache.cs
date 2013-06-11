// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDataCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemDataCache type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using GW2DotNET.V1.Items.Models.Items;

namespace GW2DotNET.V1.Items.DataProvider
{
    /// <summary>The item data cache.</summary>
    [Serializable]
    public class ItemDataCache
    {
        /// <summary>Gets or sets the build.</summary>
        public int Build { get; set; }

        /// <summary>Gets or sets the item ids.</summary>
        public IEnumerable<int> ItemIds { get; set; }

        /// <summary>Gets or sets the items list.</summary>
        public IEnumerable<Item> ItemsList { get; set; }
    }
}
