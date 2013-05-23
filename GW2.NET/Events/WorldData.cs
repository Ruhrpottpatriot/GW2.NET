// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods to get basic world data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using GW2DotNET.Events.Models;
using GW2DotNET.Infrastructure;

using Newtonsoft.Json.Linq;

namespace GW2DotNET.Events
{
    /// <summary>
    /// Provides methods to get basic world data.
    /// </summary>
    public class WorldData
    {
        /// <summary>
        /// Keep a single instance of the class here.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Upper case letter would conflict with a property defined below.")]
        // ReSharper disable InconsistentNaming
        private static readonly WorldData instance = new WorldData();
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// Cache the list of worlds here.
        /// </summary>
        private List<World> worldList;

        /// <summary>
        /// Cache a dictionary for resolving world IDs to names.
        /// </summary>
        private Dictionary<int, string> worldDictionary;

        /// <summary>
        /// Cache the list of maps here.
        /// </summary>
        private List<Map> mapList;

        /// <summary>
        /// Cache a dictionary for resolving map IDs to names.
        /// </summary>
        private Dictionary<int, string> mapDictionary;

        /// <summary>
        /// Language is "en" by default.
        /// </summary>
        private string language = "en";

        /// <summary>
        /// Prevents a default instance of the <see cref="WorldData"/> class from being created. 
        /// They must request an instance. This ensures that the cached data is used efficiently.
        /// </summary>
        private WorldData()
        {
        }

        /// <summary>
        /// Gets a WorldData instance.
        /// </summary>
        public static WorldData Instance
        {
            get
            {
                return WorldData.instance;
            }
        }

        /// <summary>
        /// Gets or sets the language.
        /// Note that changing the language clears the cached world data.
        /// </summary>
        public string Language
        {
            get
            {
                return this.language;
            }

            set
            {
                this.language = value;

                // Whatever we had cached is no longer valid due to the
                // language change.
                this.worldList = null;
                this.worldDictionary = null;
                this.mapList = null;
                this.mapDictionary = null;
            }
        }

        /// <summary>
        /// Gets all available worlds.
        /// </summary>
        public List<World> Worlds
        {
            get
            {
                if (this.worldList == null)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>("lang", this.language)
                    };

                    string jsonString = ApiCall.CallApi("world_names.json", arguments);

                    var worlds = JArray.Parse(jsonString);

                    this.worldList = new List<World>(worlds.Select(world => new World(int.Parse((string)world["id"]), (string)world["name"])));
                }

                return this.worldList;
            }
        }

        /// <summary>
        /// Gets a world name from a world ID.
        /// </summary>
        public Dictionary<int, string> WorldDictionary
        {
            get
            {
                if (this.worldDictionary == null)
                {
                    this.worldDictionary = new Dictionary<int, string>();
                    foreach (var world in this.Worlds)
                    {
                        this.worldDictionary.Add(world.Id, world.Name);
                    }
                }

                return this.worldDictionary;
            }
        }

        /// <summary>
        /// Gets all the available maps.
        /// </summary>
        public List<Map> Maps
        {
            get
            {
                if (this.mapList == null)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>("lang", this.language)
                    };

                    string jsonString = ApiCall.CallApi("map_names.json", arguments);

                    var maps = JArray.Parse(jsonString);

                    this.mapList = new List<Map>(maps.Select(map => new Map(int.Parse((string)map["id"]), (string)map["name"])));
                }

                return this.mapList;
            }
        }

        /// <summary>
        /// Gets a map name from a map ID.
        /// </summary>
        public Dictionary<int, string> MapDictionary
        {
            get
            {
                if (this.mapDictionary == null)
                {
                    this.mapDictionary = new Dictionary<int, string>();

                    foreach (var map in this.Maps)
                    {
                        this.mapDictionary.Add(map.Id, map.Name);
                    }
                }

                return this.mapDictionary;
            }
        }
    }
}