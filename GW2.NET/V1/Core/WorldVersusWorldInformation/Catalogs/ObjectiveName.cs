// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveName.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Catalogs
{
    /// <summary>
    ///     Represents an objective and its localized name.
    /// </summary>
    public class ObjectiveName : JsonObject
    {
        /// <summary>
        ///     Gets or sets the objective's ID.
        /// </summary>
        [JsonProperty("ID", Order = 0)]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the objective's name.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }
    }
}