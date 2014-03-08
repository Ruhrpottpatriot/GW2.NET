// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FocusDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Weapons.Focuses
{
    /// <summary>
    ///     Represents detailed information about a focus.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class FocusDetails : WeaponDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FocusDetails" /> class.
        /// </summary>
        public FocusDetails()
            : base(WeaponType.Focus)
        {
        }
    }
}