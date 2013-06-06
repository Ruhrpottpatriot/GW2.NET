using GW2DotNET.V1.Guilds.DataProvider;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.DataProvider;
using GW2DotNET.V1.World.DataProvider;
using GW2DotNET.V1.WvW.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.V1
{
    /// <summary>
    /// This is the one and only class that is directly instantiated
    /// by the caller. All functionality is accessed through the
    /// properties of this object.
    /// </summary>
    public class GW2ApiManager
    {
        /// <summary>
        /// Backing field for Colours property
        /// </summary>
        private ColourData colourData = null;

        /// <summary>
        /// Backing field for Events property
        /// </summary>
        private EventData eventData = null;

        /// <summary>
        /// Backing field for Guilds property
        /// </summary>
        private GuildData guildData = null;

        /// <summary>
        /// Backing field for Items property
        /// </summary>
        private ItemData itemData = null;

        /// <summary>
        /// Backing field for Maps property
        /// </summary>
        private MapData mapData = null;

        /// <summary>
        /// Backing field for WvWMatches property
        /// </summary>
        private MatchData matchData = null;

        /// <summary>
        /// Backing field for Recipes property
        /// </summary>
        private RecipeData recipeData = null;

        /// <summary>
        /// Backing field for Worlds property
        /// </summary>
        private WorldData worldData = null;

        /// <summary>
        /// Stores the language set by the constructor
        /// </summary>
        private Language language;

        /// <summary>
        /// Initializes a new instance of the <see cref="GW2ApiManager"/> class.
        /// </summary>
        /// <param name="language">The language for things such as World names</param>
        public GW2ApiManager(Language language)
        {
            this.language = language;
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
    }
}
