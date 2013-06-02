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
using System.Linq;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.Models;

namespace GW2DotNET.V1.Items.DataProvider
{
    /// <summary>
    /// The colour data provider.
    /// </summary>
    public class ColourData : IEnumerable<GwColour>
    {
        /// <summary>
        /// The colours cache.
        /// </summary>
        private IEnumerable<GwColour> coloursCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColourData"/> class.
        /// </summary>
        internal ColourData()
        {
        }

        /// <summary>
        /// Gets the colours.
        /// </summary>
        private IEnumerable<GwColour> Colours
        {
            get
            {
                return this.coloursCache ?? (this.coloursCache = this.GetColours());
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
                if (this.coloursCache == null)
                {
                    this.coloursCache = this.GetColours();
                }

                return this.coloursCache.Single(c => c.Id == id);
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
            var response = ApiCall.GetContent<Dictionary<string, Dictionary<int, GwColour>>>(
                "colors.json", null, ApiCall.Categories.Miscellaneous)["colors"];

            return response.Select(keyvaluepair => new GwColour(keyvaluepair.Key, keyvaluepair.Value.Name, keyvaluepair.Value.Default, keyvaluepair.Value.Cloth, keyvaluepair.Value.Leather, keyvaluepair.Value.Metal)).ToList();
        }
    }
}