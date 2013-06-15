// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GW2ApiManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   This is the one and only class that is directly instantiated
//   by the caller. All functionality is accessed through the
//   properties of this object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using GW2DotNET.V1.Guilds.DataProvider;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.DataProvider;
using GW2DotNET.V1.World.DataProvider;
using GW2DotNET.V1.WvW.DataProviders;

namespace GW2DotNET.V1
{
    /// <summary>
    /// This is the one and only class that is directly instantiated
    /// by the caller. All functionality is accessed through the
    /// properties of this object.
    /// </summary>
    public class Gw2ApiManager
    {
        /// <summary>
        /// Backing field for Colours property
        /// </summary>
        private ColourData colourData;

        /// <summary>
        /// Backing field for Events property
        /// </summary>
        private EventData eventData;

        /// <summary>
        /// Backing field for Guilds property
        /// </summary>
        private GuildData guildData;

        /// <summary>
        /// Backing field for Items property
        /// </summary>
        private ItemData itemData;

        /// <summary>
        /// Backing field for Maps property
        /// </summary>
        private MapData mapData;

        /// <summary>
        /// Backing field for wvwMatches property
        /// </summary>
        private MatchData matchData;

        /// <summary>
        /// Backing field for Recipes property
        /// </summary>
        private RecipeData recipeData;

        /// <summary>
        /// Backing field for Worlds property
        /// </summary>
        private WorldData worldData;

        /// <summary>
        /// Stores the language set by the constructor
        /// </summary>
        private Language language;

        /// <summary>The build.</summary>
        private int build = -1;

        /// <summary>Initializes a new instance of the <see cref="Gw2ApiManager"/> class.</summary>
        public Gw2ApiManager()
        {
            this.language = Language.En;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Gw2ApiManager"/> class.
        /// </summary>
        /// <param name="language">The language for things such as World names</param>
        public Gw2ApiManager(Language language)
        {
            this.language = language;
        }

        /// <summary>Gets the build.</summary>
        public int Build
        {
            get
            {
                if (this.build < 0)
                {
                    this.build = this.GetLatestBuild();
                }

                return this.build;
            }
        }

        /// <summary>Gets or sets the language.</summary>
        /// <remarks>This property sets the language.
        /// This will also clear the complete cache
        /// so the user will get the data from the api in the set language.</remarks>
        public Language Language
        {
            get
            {
                return this.language;
            }

            set
            {
                this.colourData = null;
                this.eventData = null;
                this.guildData = null;
                this.itemData = null;
                this.mapData = null;
                this.matchData = null;
                this.recipeData = null;
                this.worldData = null;

                this.language = value;
            }
        }

        /// <summary>
        /// Gets the ColourData object.
        /// </summary>
        public ColourData Colours
        {
            get
            {
                return this.colourData ?? (this.colourData = new ColourData(this.language));
            }
        }

        /// <summary>
        /// Gets the EventData object.
        /// </summary>
        public EventData Events
        {
            get
            {
                return this.eventData ?? (this.eventData = new EventData(this.language, this));
            }
        }

        /// <summary>
        /// Gets the GuildData object.
        /// </summary>
        public GuildData Guilds
        {
            get
            {
                return this.guildData ?? (this.guildData = new GuildData(this));
            }
        }

        /// <summary>
        /// Gets the ItemData object.
        /// </summary>
        public ItemData Items
        {
            get
            {
                return this.itemData ?? (this.itemData = new ItemData(this.language));
            }
        }

        /// <summary>
        /// Gets the MapData object.
        /// </summary>
        public MapData Maps
        {
            get
            {
                return this.mapData ?? (this.mapData = new MapData(this.language));
            }
        }

        /// <summary>
        /// Gets the RecipeData object.
        /// </summary>
        public RecipeData Recipes
        {
            get
            {
                return this.recipeData ?? (this.recipeData = new RecipeData());
            }
        }

        /// <summary>
        /// Gets the MatchData object.
        /// </summary>
        public MatchData WvWMatches
        {
            get
            {
                return this.matchData ?? (this.matchData = new MatchData());
            }
        }

        /// <summary>
        /// Gets the WorldData object.
        /// </summary>
        public WorldData Worlds
        {
            get
            {
                return this.worldData ?? (this.worldData = new WorldData(this.language));
            }
        }

        /// <summary>Gets the latest build from the server and storey it in the cache.</summary>
        /// <returns>The latest build.</returns>
        public int GetLatestBuild()
        {
            int latestBuild = ApiCall.GetContent<Dictionary<string, int>>("build.json", null, ApiCall.Categories.Miscellaneous).Values.Single();

            this.build = latestBuild;

            return latestBuild;
        }

        /// <summary>Clears the cache.
        /// WARNING! there is  no undo!</summary>
        public void ClearCache()
        {
            this.colourData = null;
            this.eventData = null;
            this.guildData = null;
            this.itemData = null;
            this.mapData = null;
            this.matchData = null;
            this.recipeData = null;
            this.worldData = null;
        }
    }
}
