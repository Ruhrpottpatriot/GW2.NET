// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Type for (de-)serializing the cache into.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Infrastructure
{
    /// <summary>Type for (de-)serializing the cache into.</summary>
    /// <typeparam name="T">The type of the cached data.</typeparam>
    public class GameCache<T>
    {
        /// <summary>Gets or sets the build of the game.</summary>
        [JsonProperty("build")]
        public int Build { get; set; }

        /// <summary>Gets or sets the cached data.</summary>
        [JsonProperty("cache_data")]
        public T CacheData { get; set; }
    }
}