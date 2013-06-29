// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColourData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The colour data provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.Models;

namespace GW2DotNET.V1.Items.DataProvider
{
    /// <summary>
    /// The colour data provider.
    /// </summary>
    public partial class ColourData : System.ComponentModel.Component, IEnumerable<GwColour>
    {
        /// <summary>
        /// The language.
        /// </summary>
        private readonly ApiManager apiManager;

        /// <summary>
        /// The colours cache.
        /// </summary>
        private IEnumerable<GwColour> coloursCache;

        /// <summary>
        /// Sync object for thread safety. You MUST lock this
        /// object before touching the private coloursCache object.
        /// </summary>
        private readonly object coloursCacheSyncObject = new object();

        /// <summary>
        ///     Tracks the state of any async tasks.
        /// </summary>
        private readonly HybridDictionary userStateToLifetime = new HybridDictionary();

        /// <summary>
        /// Initializes a new instance of the <see cref="ColourData"/> class.
        /// </summary>
        /// <param name="apiManager">The API manager.</param>
        internal ColourData(ApiManager apiManager)
        {
            this.apiManager = apiManager;

            InitializeDelegates();
        }

        /// <summary>
        ///     Initialize the delegates. This is called by the constructor.
        /// </summary>
        protected virtual void InitializeDelegates()
        {
            onGetColourFromIdCompletedDelegate = GetColourFromIdCompletedCallback;

            onGetColourFromIdProgressReportDelegate = GetColourFromIdReportProgressCallback;

            onGetColourFromNameCompletedDelegate = GetColourFromNameCompletedCallback;

            onGetColourFromNameProgressReportDelegate = GetColourFromNameReportProgressCallback;

            onGetAllColoursCompletedDelegate = GetAllColoursCompletedCallback;

            onGetAllColoursProgressReportDelegate = GetAllColoursReportProgressCallback;
        }

        // Utility method for determining if a task has been canceled.
        private bool TaskCanceled(object taskId)
        {
            return (userStateToLifetime[taskId] == null);
        }

        /// <summary>
        /// Gets the colours.
        /// </summary>
        private IEnumerable<GwColour> Colours
        {
            get
            {
                lock (coloursCacheSyncObject)
                {
                return this.coloursCache ?? (this.coloursCache = this.GetColours());
            }
        }
        }

        /// <summary>
        /// Gets a single colour from the colours cache.
        /// </summary>
        /// <param name="id">
        /// The id of the colour.
        /// </param>
        /// <returns>
        /// The <see cref="GwColour"/>.
        /// </returns>
        public GwColour this[int id]
        {
            get
            {
                return this.Colours.Single(colour => colour.Id == id);
            }
        }

        /// <summary>
        ///  Gets a single colour from the colours cache.
        /// </summary>
        /// <param name="name">
        /// The name of the colour.
        /// </param>
        /// <returns>
        /// The <see cref="GwColour"/>.
        /// </returns>
        public GwColour this[string name]
        {
            get
            {
                return this.Colours.Single(colour => colour.Name == name);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<GwColour> GetEnumerator()
        {
            return this.Colours.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Colours.GetEnumerator();
        }
        
        /// <summary>
        /// Gets all colours from the api server.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private IEnumerable<GwColour> GetColours()
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", this.apiManager.Language)
            };

            var returnColours = ApiCall.GetContent<Dictionary<string, Dictionary<int, GwColour>>>(
                "colors.json", arguments, ApiCall.Categories.Miscellaneous)["colors"].Select(returnColour => new GwColour(returnColour.Key, returnColour.Value.Name, returnColour.Value.BaseRgb, returnColour.Value.Cloth, returnColour.Value.Leather, returnColour.Value.Metal)).ToList();

            return returnColours;
        }
    }
}