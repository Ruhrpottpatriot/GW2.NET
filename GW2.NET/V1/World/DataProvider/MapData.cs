// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.World.Models;

namespace GW2DotNET.V1.World.DataProvider
{
    /// <summary>
    /// Contains methods to get or modify the map data.
    /// </summary>
    public class MapData : IEnumerable<GwMap>
    {
        /// <summary>
        /// Retrieve the maps in this language
        /// </summary>
        private readonly Language language;

        /// <summary>
        /// Cache the map_names data here
        /// </summary>
        private List<GwMap> gwMapCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapData"/> class.
        /// This should only be called by WorldManager.
        /// </summary>
        /// <param name="language">The language in which to return names</param>
        internal MapData(Language language)
        {
            this.language = language;
        }

        /// <summary>
        /// Gets the maps from the API.
        /// This field is private and is not directly exposed.
        /// Instead, we implement IEnumerable on the parent class and
        /// pass the calls through to this object.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/> of maps.</returns>
        private IEnumerable<GwMap> Maps
        {
            get
            {
                if (this.gwMapCache == null)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>("lang", this.language.ToString())
                    };

                    this.gwMapCache = ApiCall.GetContent<List<GwMap>>("map_names.json", arguments, ApiCall.Categories.World);
                }

                return this.gwMapCache;
            }
        }

        /// <summary>
        /// Gets a map by ID
        /// </summary>
        /// <param name="mapId">The id of the map.</param>
        /// <returns>A single <see cref="GwMap"/> with the specified id.</returns>
        public GwMap this[int mapId]
        {
            get
            {
                return (from n in this.Maps where n.Id == mapId select n).Single();
            }
        }

        /// <summary>
        /// Gets a map by name
        /// </summary>
        /// <param name="name">The name of the map.</param>
        /// <returns>A single <see cref="GwMap"/> with the specified name.</returns>
        public GwMap this[string name]
        {
            get
            {
                return (from n in this.Maps where n.Name == name select n).Single();
            }
        }

        /// <summary>
        /// Gets an enumerator for the collection
        /// </summary>
        /// <returns>An enumerator</returns>
        public IEnumerator<GwMap> GetEnumerator()
        {
            return this.Maps.GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator for the collection
        /// </summary>
        /// <returns>An enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Maps.GetEnumerator();
        }
    }
}
