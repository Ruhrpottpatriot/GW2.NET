// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownLocation.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an unknown location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEventsDetails.Types.Locations.LocationTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents an unknown location.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class UnknownLocation : Location
    {
        /// <summary>Initializes a new instance of the <see cref="UnknownLocation" /> class.</summary>
        public UnknownLocation()
            : base(LocationType.Unknown)
        {
        }
    }
}