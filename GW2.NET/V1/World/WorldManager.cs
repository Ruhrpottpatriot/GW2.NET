// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Language type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.World.Models;

namespace GW2DotNET.V1.World
{
    /// <summary>
    /// Contains methods and properties to get and modify the world content of the api.
    /// </summary>
    public class WorldManager
    {
        /// <summary>
        /// The world data class.
        /// </summary>
        private readonly WorldData worldData;

        /// <summary>
        /// The map data class.
        /// </summary>
        private readonly MapData mapData;

        /// <summary>
        /// The event data class.
        /// </summary>
        private readonly EventData eventData;

        /// <summary>
        /// The list of worlds.
        /// </summary>
        private IList<GwWorld> worlds;

        /// <summary>
        /// The list of maps.
        /// </summary>
        private IList<GwMap> maps;

        /// <summary>
        /// The chosen language
        /// </summary>
        private Language language;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldManager"/> class.
        /// </summary>
        public WorldManager()
        {
            this.eventData = new EventData();
            this.mapData = new MapData();
            this.worldData = new WorldData();
            this.language = Infrastructure.Language.En;
        }

        /// <summary>
        /// Gets the maps.
        /// </summary>
        public IList<GwMap> Maps
        {
            get
            {
                if (this.maps == null)
                {
                    var apiResponse = this.mapData.GetMaps(this.Language);

                    this.maps = apiResponse;

                    return this.maps;
                }

                return this.maps;
            }
        }

        /// <summary>
        /// Gets the worlds.
        /// </summary>
        public IList<GwWorld> Worlds
        {
            get
            {
                if (this.worlds == null)
                {
                    var apiResponse = this.worldData.GetWorlds(this.Language);

                    this.worlds = apiResponse;

                    return this.worlds;
                }

                return this.worlds;
            }
        }

        /// <summary>
        /// Gets or sets the language of the content.
        /// </summary>
        public Language Language
        {
            get
            {
                return this.language;
            }

            // ToDo: Clear cache if language changed.
            set
            {
                this.worlds = null;
                this.maps = null;
                this.eventData.EventNames = null;
            }
        }
    }
}
