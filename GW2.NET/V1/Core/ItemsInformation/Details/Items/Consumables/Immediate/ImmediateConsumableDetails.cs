// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImmediateConsumableDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Immediate
{
    /// <summary>
    ///     Represents detailed information about an immediate consumable item.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class ImmediateConsumableDetails : ConsumableDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImmediateConsumableDetails" /> class.
        /// </summary>
        public ImmediateConsumableDetails()
            : base(ConsumableType.Immediate)
        {
        }
    }
}