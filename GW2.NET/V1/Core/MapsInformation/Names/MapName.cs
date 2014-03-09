// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapName.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map and its localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.MapsInformation.Names
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a map and its localized name.
    /// </summary>
    public class MapName : JsonObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the map's ID.
        /// </summary>
        [JsonProperty("ID", Order = 0)]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the map's name.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }

        #endregion
    }
}