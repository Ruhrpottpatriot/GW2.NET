// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trophy.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a trophy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Trophies
{
    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a trophy.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Trophy : Item
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Trophy" /> class.
        /// </summary>
        public Trophy()
            : base(ItemType.Trophy)
        {
        }

        #endregion
    }
}