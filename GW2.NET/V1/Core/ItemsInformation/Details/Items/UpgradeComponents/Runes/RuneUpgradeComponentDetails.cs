// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuneUpgradeComponentDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.UpgradeComponents.Runes
{
    /// <summary>
    ///     Represents detailed information about a rune upgrade component.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class RuneUpgradeComponentDetails : UpgradeComponentDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RuneUpgradeComponentDetails" /> class.
        /// </summary>
        public RuneUpgradeComponentDetails()
            : base(UpgradeComponentType.Rune)
        {
        }
    }
}