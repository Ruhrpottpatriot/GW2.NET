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

        private Lazy<Guilds.DataProvider> guildsData;

        private Lazy<WvW.DataProvider> worldVersusWorldData;

        private Language language;

        private Lazy<Items.DataProviders.ColourData> colourData;

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
            this.StoragePath = string.Format("{0}\\GW2.NET", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }

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
        public string StoragePath { get; private set; }

        /// <summary>Gets the dynamic events data. This property is lazy-initialized.</summary>
        public DynamicEvents.DataProvider DynamicEventsData
        {
            get
            {
                return this.dynamicEventsData.Value;
            }
        }

        public Items.DataProviders.ColourData ColourData
        {
            get
            {
                return this.colourData.Value;
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

        /// <summary>Initializes the lazy fields.</summary>
        private void InitializeLazy()
        {
            // ToDo: Init Lazy fields
            this.dynamicEventsData = new Lazy<DynamicEvents.DataProvider>(() => new DynamicEvents.DataProvider(this));
            this.colourData = new Lazy<Items.DataProviders.ColourData>(() => new Items.DataProviders.ColourData(this));
            //this.guildsData = new Lazy<Guilds.DataProvider>(() => new Guilds.DataProvider(this));
            //this.worldVersusWorldData = new Lazy<WvW.DataProvider>(() => new WvW.DataProvider(this));
        }

        /// <summary>Completely clears the cache. There is no undo!</summary>
        public void ClearCache()
        {
            // throw new NotImplementedException("Clearing the cache was not implemented yet.");
        }
    }
}
