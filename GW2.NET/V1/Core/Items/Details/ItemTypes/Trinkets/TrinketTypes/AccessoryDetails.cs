﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccessoryDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an accessory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Trinkets.TrinketTypes
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about an accessory.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class AccessoryDetails : TrinketDetails
    {
        /// <summary>Initializes a new instance of the <see cref="AccessoryDetails" /> class.</summary>
        public AccessoryDetails()
            : base(TrinketType.Accessory)
        {
        }
    }
}