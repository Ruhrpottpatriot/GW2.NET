// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataProvider.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The data provider for the .
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.WvW.Models;

namespace GW2DotNET.V1.WvW
{
    /// <summary>
    /// The data provider for the world vs world api.
    /// </summary>
    /// <remarks>
    /// This class will call the api server for a list of matches,
    /// which can be accessed by the <see cref="All"/> property.
    /// If the users wants a single match he can call the <see cref="GetSingleMatch(string)"/>
    /// method which will return a single match.
    /// Please note, that except the match list there is no cache and every call to GetSingleMatch method
    /// will cause an api call. This is a deliberate design choice as matches usually change rater fast
    /// and caching them is counter productive and wastes resources.
    /// </remarks>
    public class DataProvider
    {
        /// <summary>A internal list </summary>
        private Lazy<MatchList> matchList;

        /// <summary>The internal list of objective names.</summary>
        private Lazy<IEnumerable<WvWMatch.WvWMap.Objective>> objectiveNames;

        /// <summary>Initializes a new instance of the <see cref="DataProvider"/> class.</summary>
        internal DataProvider()
        {
            this.matchList = new Lazy<MatchList>(this.GetMatchList);

            this.objectiveNames = new Lazy<IEnumerable<WvWMatch.WvWMap.Objective>>(this.GetObjectiveNames);
        }

        /// <summary>Gets a collection of all matches.</summary>
        public MatchList All
        {
            get
            {
                return this.matchList.Value;
            }
        }

        /// <summary>Gets the objective names.</summary>
        internal IEnumerable<WvWMatch.WvWMap.Objective> ObjectiveNames
        {
            get
            {
                return this.objectiveNames.Value;
            }
        }

        /// <summary>Gets a single match from the api server.</summary>
        /// <param name="matchId">The match id.</param>
        /// <returns>The <see cref="WvWMatch"/>.</returns>
        public WvWMatch GetSingleMatch(string matchId)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("match_id", matchId)
            };

            var singleMatch = ApiCall.GetContent<WvWMatch>("match_details.json", arguments, ApiCall.Categories.WvW);

            foreach (WvWMatch.WvWMap.Objective objective in singleMatch.Maps.SelectMany(map => map.Objectives))
            {
                objective.ResolveObjectiveNames(this.ObjectiveNames.Single(o => o.Id == objective.Id));
            }

            var newMatch = singleMatch.ResolveInfos(this.All.Single(match => match.MatchId == matchId));

            return newMatch;
        }

        /// <summary>
        /// Gets a single match from the api server asynchronously.
        /// </summary>
        /// <param name="matchId">The match id.</param>
        /// <param name="cancellationToken">Propagates notification that the operation should be cancelled.</param>
        /// <returns>The <see cref="WvWMatch"/>.</returns>
        public Task<WvWMatch> GetSingleMatchAsync(string matchId, CancellationToken cancellationToken)
        {
            Func<WvWMatch> methodCall = () => this.GetSingleMatch(matchId);

            return Task.Factory.StartNew(methodCall, cancellationToken);
        }

        /// <summary>
        /// Clears the map list cache. 
        /// </summary>
        /// <remarks>
        /// This method will clear the cache and force a re-download of the match list
        /// the next time the user requests it via the <see cref="All"/> property.
        /// </remarks>
        public void ClearCache()
        {
            this.matchList = new Lazy<MatchList>();
        }

        /// <summary>Gets the list of all matches from the api server.</summary>
        /// <returns>A <see cref="IEnumerable{T}"/> containing all matches.</returns>
        private MatchList GetMatchList()
        {
            return ApiCall.GetContent<MatchList>("matches.json", null, ApiCall.Categories.WvW);
        }

        /// <summary>The get objective names.</summary>
        /// <returns>A <see cref="IEnumerable{T}"/> of all objective names.</returns>
        private IEnumerable<WvWMatch.WvWMap.Objective> GetObjectiveNames()
        {
            return ApiCall.GetContent<IEnumerable<WvWMatch.WvWMap.Objective>>("objective_names.json", null, ApiCall.Categories.WvW);
        }
    }
}
