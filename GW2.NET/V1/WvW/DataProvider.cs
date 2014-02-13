// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataProvider.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Infrastructure.Extensions;
using GW2DotNET.V1.WvW.Models;

namespace GW2DotNET.V1.WvW
{
    /// <summary>The data manager for the pvp part of the api.</summary>
    public class DataProvider
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>The api manger.</summary>
        private readonly IDataManager dataManager;

        /// <summary>The matches.</summary>
        private readonly List<WvWMatch> matches;

        /// <summary>The match list.</summary>
        private MatchList matchList;

        /// <summary>The objective names.</summary>
        private IEnumerable<WvWMatch.WvWMap.Objective> objectiveNames;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors and Destructors
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="DataProvider"/> class.</summary>
        /// <param name="dataManger">The api manger which stores some references for later use.</param>
        /// <remarks>When calling this method the cache is bypassed by default.</remarks>
        internal DataProvider(IDataManager dataManger)
            : this(dataManger, true)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DataProvider"/> class.</summary>
        /// <param name="dataManager">The api manger which stores some references for later use.</param>
        /// <param name="bypassCache">Set this to true if you want to bypass the cache and always query the server.</param>
        internal DataProvider(IDataManager dataManager, bool bypassCache)
        {
            this.dataManager = dataManager;
            this.BypassCache = bypassCache;
            this.matches = new List<WvWMatch>();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets or sets a value indicating whether the user is bypassing the cache and querying the server directly.</summary>
        public bool BypassCache { get; set; }

        /// <summary>Gets the matches.</summary>
        public MatchList MatchList
        {
            get
            {
                return this.matchList;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets all currently running world versus world matches.</summary>
        /// <returns>The <see cref="Models.MatchList" />.</returns>
        public MatchList GetMatchList()
        {
            if (this.BypassCache)
            {
                return ApiCall.GetContent<MatchList>("matches.json", null, ApiCall.Categories.WvW);
            }

            MatchList returnContent = ApiCall.GetContent<MatchList>("matches.json", null, ApiCall.Categories.WvW);
            this.matchList = returnContent;

            return returnContent;
        }

        /// ReSharper disable CSharpWarnings::CS1574
        /// <summary>Gets all currently running world versus world matches asynchronously.</summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task{TResult}" />
        ///     containing the match list as result.</returns>
        /// ReSharper restore CSharpWarnings::CS1574
        public async Task<MatchList> GetMatchListAsync()
        {
            if (this.BypassCache)
            {
                MatchList returnList = await ApiCall.GetContentAsync<MatchList>("matches.json", null, ApiCall.Categories.WvW);
                return returnList;
            }

            MatchList returnContent = await ApiCall.GetContentAsync<MatchList>("matches.json", null, ApiCall.Categories.WvW);
            this.matchList = returnContent;

            return returnContent;
        }

        /// <summary>Gets a single match from the api. </summary>
        /// <param name="matchId">The match id.</param>
        /// <returns>The <see cref="WvWMatch"/>.</returns>
        public WvWMatch GetSingleMatch(string matchId)
        {
            if (this.BypassCache)
            {
                return this.GetMatch(matchId);
            }

            WvWMatch matchToReturn = this.matches.SingleOrDefault(match => match.MatchId == matchId);

            if (matchToReturn == null)
            {
                matchToReturn = this.GetMatch(matchId);

                this.matches.Add(matchToReturn);
            }

            return matchToReturn;
        }

        /// <summary>Gets a single match from the api asynchronously.</summary>
        /// <param name="matchId">The match id.</param>
        /// <returns>The <see cref="System.Threading.Tasks.Task{TResult}"/> containing the match as result.</returns>
        public async Task<WvWMatch> GetSingleMatchAsync(string matchId)
        {
            if (this.BypassCache)
            {
                return await this.GetMatchAsync(matchId);
            }

            WvWMatch matchToReturn = this.matches.SingleOrDefault(match => match.MatchId == matchId);

            if (matchToReturn == null)
            {
                matchToReturn = await this.GetMatchAsync(matchId);

                this.matches.Add(matchToReturn);
            }

            return matchToReturn;
        }

        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public void WriteCacheToDisk()
        {
            throw new NotImplementedException("This function has not yet been implemented");
        }

        /// <summary>Writes the complete cache to the disk asynchronously using the specified serializer</summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task" />.</returns>
        public async Task WriteCacheToDiskAsync()
        {
            throw new NotImplementedException("This function has not yet been implemented");
        }

        /// <summary>Synchronously gets a match from the server.</summary>
        /// <param name="matchId">The match id.</param>
        /// <returns>The <see cref="WvWMatch"/>.</returns>
        private WvWMatch GetMatch(string matchId)
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("match_id", matchId)
            };

            WvWMatch returnMatch = ApiCall.GetContent<WvWMatch>("match_details.json", args, ApiCall.Categories.WvW);

            // Get the objective names. No need to write a log message here, as the method already does it.
            this.GetObjectiveNames();

            // resolve the objective names.
            foreach (WvWMatch.WvWMap.Objective objective in returnMatch.Maps.SelectMany(map => map.Objectives))
            {
                objective.ResolveObjectiveNames(this.objectiveNames.Single(obje => obje.Id == objective.Id));
            }

            if (this.matchList.IsNullOrEmpty())
            {
                this.matchList = this.GetMatchList();
            }

            WvWMatch returnContent = returnMatch.ResolveInfos(this.matchList.Single(m => m.MatchId == matchId));

            return returnContent;
        }

        /// <summary>Asynchronously gets a match from the server .</summary>
        /// <param name="matchId">The match id.</param>
        /// <returns>The <see cref="Task"/> containing the <see cref="WvWMatch"/>.</returns>
        private async Task<WvWMatch> GetMatchAsync(string matchId)
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("match_id", matchId)
            };

            WvWMatch returnMatch = await ApiCall.GetContentAsync<WvWMatch>("match_details.json", args, ApiCall.Categories.WvW);

            await this.GetObjectiveNamesAsync();

            foreach (WvWMatch.WvWMap.Objective objective in returnMatch.Maps.SelectMany(map => map.Objectives))
            {
                objective.ResolveObjectiveNames(this.objectiveNames.Single(obje => obje.Id == objective.Id));
            }

            if (this.matchList.IsNullOrEmpty())
            {
                this.matchList = await this.GetMatchListAsync();
            }

            returnMatch = returnMatch.ResolveInfos(this.matchList.Single(m => m.MatchId == matchId));

            return returnMatch;
        }

        /// <summary>Gets a collection with all objective names from the server.</summary>
        private void GetObjectiveNames()
        {
            if (this.objectiveNames.IsNullOrEmpty())
            {
                this.objectiveNames = ApiCall.GetContent<IEnumerable<WvWMatch.WvWMap.Objective>>("objective_names.json", null, ApiCall.Categories.WvW);
            }
        }

        /// <summary>Gets a collection with all objective names from the server asynchronously.</summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task" />.</returns>
        private async Task GetObjectiveNamesAsync()
        {
            if (this.objectiveNames.IsNullOrEmpty())
            {
                this.objectiveNames = await ApiCall.GetContentAsync<IEnumerable<WvWMatch.WvWMap.Objective>>("objective_names.json", null, ApiCall.Categories.WvW);
            }
        }
    }
}