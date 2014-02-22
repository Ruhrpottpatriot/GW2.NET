// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trophy.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Trophies
{
    /// <summary>
    /// Represents a trophy.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class Trophy : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trophy"/> class.
        /// </summary>
        public Trophy()
            : base(ItemType.Trophy)
        {
        }
    }
}