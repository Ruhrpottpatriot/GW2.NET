// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataProvider.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the DataProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.World.Models;

namespace GW2DotNET.V1.World
{
    /// <summary>The data provider for the event api.</summary>
    public class DataProvider
    {
        /// <summary>The api manager.</summary>
        private readonly ApiManager apiManager;

        /// <summary>A list of all worlds.</summary>
        private List<GwWorld> worlds;

        /// <summary>The event names.</summary>
        private WorldEventNamesList eventNames;

        /// <summary>Initializes a new instance of the <see cref="DataProvider"/> class.</summary>
        /// <param name="apiManager">The api manager.</param>
        internal DataProvider(ApiManager apiManager)
        {
            this.apiManager = apiManager;
            this.BypassCaching = false;
        }

        /// <summary>
        /// Gets a value indicating whether bypass caching.
        /// </summary>
        public bool BypassCaching
        {
            get;
            private set;
        }

        /// <summary>Gets all worlds.</summary>
        public IEnumerable<GwWorld> Worlds
        {
            get
            {
                return this.worlds ?? (this.worlds = this.GetWorlds());
            }
        }

        /// <summary>Gets a world by its world id.</summary>
        /// <param name="worldId">The world id.</param>
        /// <returns>The <see cref="GwWorld"/>.</returns>
        public GwWorld GetWorld(int worldId)
        {
            return this.Worlds.Single(w => w.Id == worldId);
        }

        /// <summary>Gets a single world by its world name.</summary>
        /// <param name="worldName">The world name.</param>
        /// <returns>The <see cref="GwWorld"/>.</returns>
        public GwWorld GetWorld(string worldName)
        {
            return this.Worlds.Single(w => w.Name == worldName);
        }

        /// <summary>Makes a call to the api and retrieves all worlds.</summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        private List<GwWorld> GetWorlds()
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", this.apiManager.ToString())
            };

            return ApiCall.GetContent<List<GwWorld>>("world_names.json", arguments, ApiCall.Categories.World);
        }
    }
}
