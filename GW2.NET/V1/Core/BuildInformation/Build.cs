// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Build.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the current build of the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.BuildInformation
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents the current build of the game.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/build" /> for more information.
    /// </remarks>
    public class Build : JsonObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the current build ID of the game.
        /// </summary>
        [JsonProperty("build_id", Order = 0)]
        public int BuildId { get; set; }

        #endregion
    }
}