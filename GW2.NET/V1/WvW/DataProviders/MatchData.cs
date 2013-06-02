// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MatchDataProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;

namespace GW2DotNET.V1.WvW.DataProviders
{
    using System.Collections.Generic;
    using System.Linq;

    using GW2DotNET.V1.Infrastructure;
    using GW2DotNET.V1.WvW.Models;

    /// <summary>
    /// The match data provider.
    /// </summary>
    public class MatchData : IEnumerable<WvWMatch>
    {
        /// <summary>
        /// The matches.
        /// </summary>
        private IEnumerable<WvWMatch> matches;

        /// <summary>
        /// The match dictionary.
        /// </summary>
        private IEnumerable<WvWMatch> matchDictionary;

        /// <summary>
        /// Gets the match dictionary.
        /// </summary>
        internal IEnumerable<WvWMatch> MatchDictionary
        {
            get
            {
                if (this.matchDictionary == null)
                {
                    var response = ApiCall.GetContent<Dictionary<string, IEnumerable<WvWMatch>>>(
                        "matches.json", null, ApiCall.Categories.WvW).Values.ToList()[0];

                    this.matchDictionary = response;

                    return this.matchDictionary;
                }

                return this.matchDictionary;
            }
        }

        /// <summary>
        /// Gets the matches.
        /// </summary>
        internal IEnumerable<WvWMatch> Matches
        {
            get
            {
                return this.matches ?? (this.matches = this.GetMatches());
            }
        }

        /// <summary>
        /// Gets a single match from the server.
        /// </summary>
        /// <param name="id">
        /// The match id.
        /// </param>
        /// <returns>
        /// The <see cref="WvWMatch"/>.
        /// </returns>
        public WvWMatch this[string id]
        {
            get
            {
                return this.Matches.Single(m => m.MatchId == id);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<WvWMatch> GetEnumerator()
        {
            return this.Matches.GetEnumerator();
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
            return this.Matches.GetEnumerator();
        }

        /// <summary>
        /// Calls the api to get all matches from the api server.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        internal IEnumerable<WvWMatch> GetMatches()
        {
            return (from wvWMatch in this.MatchDictionary
                    let arguments = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>("match_id", wvWMatch.MatchId)
                    }
                    let returnMatch = ApiCall.GetContent<WvWMatch>("match_details.json", arguments, ApiCall.Categories.WvW)
                    select new WvWMatch(wvWMatch.MatchId, wvWMatch.RedWorld, wvWMatch.BlueWorld, wvWMatch.GreenWorld, wvWMatch.StartTime, wvWMatch.EndTime, returnMatch.Scores, returnMatch.Maps)).ToList();
        }
    }
}
