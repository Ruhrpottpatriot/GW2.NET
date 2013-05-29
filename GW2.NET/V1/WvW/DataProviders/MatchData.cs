// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDataProvider.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MatchDataProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.WvW.DataProviders
{
    using System.Collections.Generic;
    using System.Linq;

    using GW2DotNET.V1.Infrastructure;
    using GW2DotNET.V1.WvW.Models;

    public class MatchData
    {
        private IEnumerable<WvWMatch> matches;

        private IEnumerable<WvWMatch> matchDictionary;


        public IEnumerable<WvWMatch> MatchDictionary
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

        public IEnumerable<WvWMatch> Matches
        {
            get
            {
                return this.matches ?? this.GetMatches();
            }
        }

        public IEnumerable<WvWMatch> GetMatches()
        {
            IList<WvWMatch> matchesReturn = new List<WvWMatch>();


            foreach (var wvWMatch in MatchDictionary)
            {
                var arguments = new List<KeyValuePair<string, object>>
                                    {
                                        new KeyValuePair<string, object>(
                                            "match_id", wvWMatch.MatchId)
                                    };
                matchesReturn.Add(ApiCall.GetContent<WvWMatch>("match_details.json", arguments, ApiCall.Categories.WvW));
            }

            return matchesReturn;
        }
    }
}
