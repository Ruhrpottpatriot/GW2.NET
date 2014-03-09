// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoatDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about chest protection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors.Coats
{
    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about chest protection.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class CoatDetails : ArmorDetails
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="CoatDetails" /> class
        /// </summary>
        public CoatDetails()
            : base(ArmorType.Coat)
        {
        }

        #endregion
    }
}