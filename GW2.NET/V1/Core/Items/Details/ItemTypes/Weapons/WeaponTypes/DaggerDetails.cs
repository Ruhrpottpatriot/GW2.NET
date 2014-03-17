// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DaggerDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a focus.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Weapons.WeaponTypes
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a focus.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class DaggerDetails : WeaponDetails
    {
        /// <summary>Initializes a new instance of the <see cref="DaggerDetails" /> class.</summary>
        public DaggerDetails()
            : base(WeaponType.Dagger)
        {
        }
    }
}