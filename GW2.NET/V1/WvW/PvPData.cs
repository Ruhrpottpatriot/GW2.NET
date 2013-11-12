// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PvPData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;

namespace GW2DotNET.V1.WvW
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Infrastructure;
    using GW2DotNET.V1.Infrastructure.Exceptions;
    using GW2DotNET.V1.Infrastructure.Extensions;
    using GW2DotNET.V1.WvW.Models;

    /// <summary>The data manager for the pvp part of the api.</summary>
    public class PvPData
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>The api manger.</summary>
        private readonly ApiManager apiManger;

        /// <summary>The matches.</summary>
        private readonly List<WvWMatch> matches;

        /// <summary>The api request.</summary>
        private ANetApiRequest apiRequest;

        /// <summary>The match list.</summary>
        private MatchList matchList;

        /// <summary>The objective names.</summary>
        private IEnumerable<WvWMatch.WvWMap.Objective> objectiveNames;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors and Destructors
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="PvPData"/> class.</summary>
        /// <param name="apiManger">The api manger which stores some references for later use.</param>
        /// <remarks>When calling this method the cache is bypassed by default.</remarks>
        internal PvPData(ApiManager apiManger)
            : this(apiManger, true)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PvPData"/> class.</summary>
        /// <param name="apiManager">The api manger which stores some references for later use.</param>
        /// <param name="bypassCache">Set this to true if you want to bypass the cache and always query the server.</param>
        internal PvPData(ApiManager apiManager, bool bypassCache)
        {
            this.apiManger = apiManager;
            this.BypassCache = bypassCache;
            this.matches = new List<WvWMatch>();
        }

        /// <summary>Gets a collection of all matches.</summary>
        public IEnumerable<WvWMatch> All
        {
            get
            {
                if (this.matches.IsNullOrEmpty())
                {
                    throw new NoDataDownloadedException("Call the appropriate data fetching method first.");
                }

                return this.matches;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets or sets a value indicating whether the user is bypassing the cache and querying the server directly.</summary>
        public bool BypassCache { get; set; }

        /// <summary>Gets the matches.</summary>
        /// <exception cref="NoDataDownloadedException">Thrown when the user tries to access the property before calling the data fetching method.</exception>
        public MatchList MatchList
        {
            get
            {
                if (this.matchList.IsNullOrEmpty())
                {
                    throw new NoDataDownloadedException("Call the appropriate data fetching method first.");
                }

                return this.matchList;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Clears the map list cache.</summary>
        /// <remarks>This method will clear the cache of all matches. The next time the user will have to download the match list again via the appropriate methods.</remarks>
        /// <seealso cref="GetMatchList" />
        /// <seealso cref="GetMatchListAsync" />
        /// <seealso cref="GetSingleMatch" />
        /// <seealso cref="GetSingleMatchAsync" />
        public void ClearCache()
        {
            this.apiManger.Logger.WriteToLog("Clearing match list cache.", TraceEventType.Information);
            this.matchList = new MatchList(null);
        }

        /// <summary>Gets all currently running world versus world matches.</summary>
        /// <returns>The <see cref="Models.MatchList" />.</returns>
        public MatchList GetMatchList()
        {
            this.apiRequest = new ANetApiRequest();

            this.apiManger.Logger.WriteToLog("Calling GW2 API to get the list of matches.", TraceEventType.Information);

            if (this.BypassCache)
            {
                return this.apiRequest.GetContent<MatchList>("matches.json", ANetApiRequest.Categories.WvW);
            }

            var returnContent = this.apiRequest.GetContent<MatchList>("matches.json", ANetApiRequest.Categories.WvW);
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
            this.apiRequest = new ANetApiRequest();

            this.apiManger.Logger.WriteToLog(
                "Beginning call to the GW2 API to get the list of matches.",
                TraceEventType.Start);

            if (this.BypassCache)
            {
                MatchList returnList =
                    await this.apiRequest.GetContentAsync<MatchList>("matches.json", ANetApiRequest.Categories.WvW);

                this.apiManger.Logger.WriteToLog(
                    "Finishing call to the GW2 API to get the list of matches.",
                    TraceEventType.Stop);

                return returnList;
            }

            MatchList returnContent =
                await this.apiRequest.GetContentAsync<MatchList>("matches.json", ANetApiRequest.Categories.WvW);

            this.matchList = returnContent;

            this.apiManger.Logger.WriteToLog(
                "Finishing call to the GW2 API to get the list of matches.",
                TraceEventType.Stop);

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
        public Task WriteCacheToDiskAsync()
        {
            throw new NotImplementedException("This function has not yet been implemented");
        }

        /// <summary>Synchronously gets a match from the server.</summary>
        /// <param name="matchId">The match id.</param>
        /// <returns>The <see cref="WvWMatch"/>.</returns>
        private WvWMatch GetMatch(string matchId)
        {
            this.apiRequest = new ANetApiRequest();

            this.apiRequest.AddParameter("match_id", matchId);

            this.apiManger.Logger.WriteToLog("Calling GW2 API to get a single match.", TraceEventType.Information);

            var returnMatch = this.apiRequest.GetContent<WvWMatch>("match_details.json", ANetApiRequest.Categories.WvW);

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

            var returnContent = returnMatch.ResolveInfos(this.matchList.Single(m => m.MatchId == matchId));

            return returnContent;
        }

        /// <summary>Asynchronously gets a match from the server .</summary>
        /// <param name="matchId">The match id.</param>
        /// <returns>The <see cref="Task"/> containing the <see cref="WvWMatch"/>.</returns>
        private async Task<WvWMatch> GetMatchAsync(string matchId)
        {
            this.apiRequest = new ANetApiRequest();

            this.apiManger.Logger.WriteToLog(
                "Beginning Call to the GW2 API to get a single match.",
                TraceEventType.Start);

            this.apiRequest.AddParameter("match_id", matchId);

            WvWMatch returnMatch =
                await this.apiRequest.GetContentAsync<WvWMatch>("match_details.json", ANetApiRequest.Categories.WvW);

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

            this.apiManger.Logger.WriteToLog(
                "Finishing Call to the GW2 API to get a single match.",
                TraceEventType.Stop);

            return returnMatch;
        }

        /// <summary>Gets a collection with all objective names from the server.</summary>
        private void GetObjectiveNames()
        {
            this.apiManger.Logger.WriteToLog(
                "Calling the GW2 API to fetch the objective names.",
                TraceEventType.Information);

            if (this.objectiveNames.IsNullOrEmpty())
            {
                this.objectiveNames =
                    this.apiRequest.GetContent<IEnumerable<WvWMatch.WvWMap.Objective>>(
                        "objective_names.json",
                        ANetApiRequest.Categories.WvW);
            }
        }

        /// <summary>Gets a collection with all objective names from the server asynchronously.</summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task" />.</returns>
        private async Task GetObjectiveNamesAsync()
        {
            if (this.objectiveNames.IsNullOrEmpty())
            {
                this.apiManger.Logger.WriteToLog(
                    "Beginning Call to the GW2 API to fetch the objective names.",
                    TraceEventType.Information);

                this.objectiveNames =
                    await
                    this.apiRequest.GetContentAsync<IEnumerable<WvWMatch.WvWMap.Objective>>(
                        "objective_names.json",
                        ANetApiRequest.Categories.WvW);

                this.apiManger.Logger.WriteToLog(
                    "Finishing Call to the GW2 API to get a single match.",
                    TraceEventType.Start);
            }
        }
    }
}