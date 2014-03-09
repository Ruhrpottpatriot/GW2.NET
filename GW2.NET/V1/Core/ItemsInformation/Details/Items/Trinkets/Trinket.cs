// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trinket.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a trinket.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Trinkets
{
    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a trinket.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Trinket : Item
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Trinket" /> class.
        /// </summary>
        public Trinket()
            : base(ItemType.Trinket)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the trinket's details.
        /// </summary>
        [JsonProperty("trinket", Order = 100)]
        public TrinketDetails TrinketDetails { get; set; }

        #endregion
    }
}