// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RingDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a ring.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Trinkets.TrinketTypes
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a ring.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class RingDetails : TrinketDetails
    {
        /// <summary>Initializes a new instance of the <see cref="RingDetails" /> class.</summary>
        public RingDetails()
            : base(TrinketType.Ring)
        {
        }
    }
}