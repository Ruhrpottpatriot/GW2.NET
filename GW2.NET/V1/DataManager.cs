// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the DataProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using GW2DotNET.V1.Infrastructure;

namespace GW2DotNET.V1
{
    /// <summary>The data manager for the api.</summary>
    public class DataManager : IDataManager
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>The game build.</summary>
        private int build = -1;

        /// <summary>Backing field for the dynamic events data.</summary>
        private Lazy<DynamicEvents.DataProvider> dynamicEventsData;

        /// <summary>The guilds data.</summary>
        private Lazy<Guilds.DataProvider> guildsData;

        /// <summary>The world versus world data.</summary>
        private Lazy<WvW.DataProvider> worldVersusWorldData;

        /// <summary>The language.</summary>
        private Language language;

        /// <summary>The colour data.</summary>
        private Lazy<Items.DataProviders.ColourData> colourData;

        /// <summary>The item data.</summary>
        private Lazy<Items.DataProviders.ItemData> itemData;

        /// <summary>The recipe data.</summary>
        private Lazy<Items.DataProviders.RecipeData> recipeData;

        /// <summary>The continent data.</summary>
        private Lazy<MapInformation.DataProvider.ContinentData> continentData;

        /// <summary>The map floor data.</summary>
        private Lazy<MapInformation.DataProvider.MapFloorData> mapFloorData;

        /// <summary>The maps data.</summary>
        private Lazy<MapInformation.DataProvider.MapsData> mapsData;

        /// <summary>The wvw data.</summary>
        private Lazy<WvW.DataProvider> wvwData;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors & Destructors
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="DataManager"/> class, with the default language set to english.</summary>
        public DataManager()
            : this(Language.En)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DataManager"/> class.</summary>
        /// <param name="language">The language to query the api.</param>
        public DataManager(Language language)
        {
            this.Language = language;
            this.InitializeLazy();
            this.SavePath = string.Format("{0}\\GW2.NET", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets or sets the language.</summary>
        public Language Language
        {
            get
            {
                return this.language;
            }

            set
            {
                this.ClearCache();
                this.language = value;
            }
        }

        /// <summary>Gets the current build of the game.</summary>
        public int Build
        {
            get
            {
                if (this.build <= 0)
                {
                    this.GetLatestBuild();
                }

                return this.build;
            }
        }

        /// <summary>
        /// Gets the path to the cache.
        /// </summary>
        public string SavePath { get; private set; }

        /// <summary>Gets the dynamic events data. This property is lazy-initialized.</summary>
        public DynamicEvents.DataProvider DynamicEventsData
        {
            get
            {
                return this.dynamicEventsData.Value;
            }
        }

        /// <summary>Gets the guilds data. This property is lazy-initialized.</summary>
        public Guilds.DataProvider GuildsData
        {
            get
            {
                return this.guildsData.Value;
            }
        }

        /// <summary>Gets the colour data. This property is lazy-initialized.</summary>
        public Items.DataProviders.ColourData ColourData
        {
            get
            {
                return this.colourData.Value;
            }
        }

        /// <summary>Gets the item dara data. This property is lazy-initialized.</summary>
        public Items.DataProviders.ItemData ItemData
        {
            get
            {
                return this.itemData.Value;
            }
        }

        /// <summary>Gets the recipe data. This property is lazy-initialized.</summary>
        public Items.DataProviders.RecipeData RecipeData
        {
            get
            {
                return this.recipeData.Value;
            }
        }

        /// <summary>Gets the continent data. This property is lazy-initialized.</summary>
        public MapInformation.DataProvider.ContinentData ContinentData
        {
            get
            {
                return this.continentData.Value;
            }
        }

        /// <summary>Gets the map floor data. This property is lazy-initialized.</summary>
        public MapInformation.DataProvider.MapFloorData MapFloorData
        {
            get
            {
                return this.mapFloorData.Value;
            }
        }

        /// <summary>Gets the maps data. This property is lazy-initialized.</summary>
        public MapInformation.DataProvider.MapsData MapsData
        {
            get
            {
                return this.mapsData.Value;
            }
        }

        /// <summary>Gets the wvw data. This property is lazy-initialized.</summary>
        public WvW.DataProvider WvWData
        {
            get
            {
                return this.wvwData.Value;
            }
        }

        /// <summary>Gets the latest build from the server.</summary>
        /// <remarks>
        /// This function will query the server for the current build. 
        /// After a query this method will return the current build to the user.
        /// It will also store the new build in the <see cref="Build"/> property and therefore cache it.
        /// </remarks>
        /// <returns>
        /// An <see cref="T:System.Int32"/> containing the latest build.
        /// </returns>
        public int GetLatestBuild()
        {
            this.build =
                ApiCall.GetContent<Dictionary<string, int>>("build.json", null, ApiCall.Categories.Miscellaneous)
                    .Values.Single();
            return this.build;
        }

        /// <summary>Completely clears the cache. There is no undo!</summary>
        public void ClearCache()
        {
            // throw new NotImplementedException("Clearing the cache was not implemented yet.");
        }

        /// <summary>Initializes the lazy fields.</summary>
        private void InitializeLazy()
        {
            this.dynamicEventsData = new Lazy<DynamicEvents.DataProvider>(() => new DynamicEvents.DataProvider(this));
            
            this.guildsData = new Lazy<Guilds.DataProvider>(() => new Guilds.DataProvider(this));
           
            this.colourData = new Lazy<Items.DataProviders.ColourData>(() => new Items.DataProviders.ColourData(this));
            this.itemData = new Lazy<Items.DataProviders.ItemData>(() => new Items.DataProviders.ItemData(this));
            this.recipeData = new Lazy<Items.DataProviders.RecipeData>(() => new Items.DataProviders.RecipeData(this));
            
            this.continentData = new Lazy<MapInformation.DataProvider.ContinentData>(() => new MapInformation.DataProvider.ContinentData(this));
            this.mapFloorData = new Lazy<MapInformation.DataProvider.MapFloorData>(() => new MapInformation.DataProvider.MapFloorData(this));
            this.mapsData = new Lazy<MapInformation.DataProvider.MapsData>(() => new MapInformation.DataProvider.MapsData(this));

            this.worldVersusWorldData = new Lazy<WvW.DataProvider>(() => new WvW.DataProvider(this));
        }
    }
}
