// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the matches service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.WorldVersusWorld;
    using GW2NET.V1.WorldVersusWorld.Json;

    /// <summary>Provides the default implementation of the matches service.</summary>
    public class MatchService : IMatchService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MatchService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MatchService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Match GetMatchDetails(string match)
        {
            var request = new MatchDetailsRequest { MatchId = match };
            var response = this.serviceClient.Send<MatchDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return ConvertMatchContract(response.Content);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<Match> GetMatchDetailsAsync(string match)
        {
            return this.GetMatchDetailsAsync(match, CancellationToken.None);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<Match> GetMatchDetailsAsync(string match, CancellationToken cancellationToken)
        {
            var request = new MatchDetailsRequest { MatchId = match };
            return this.serviceClient.SendAsync<MatchDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return null;
                        }

                        return ConvertMatchContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public IDictionary<string, Matchup> GetMatches()
        {
            var request = new MatchDiscoveryRequest();
            var response = this.serviceClient.Send<MatchupCollectionDataContract>(request);
            if (response.Content == null || response.Content.Matchups == null)
            {
                return new Dictionary<string, Matchup>(0);
            }

            return ConvertMatchupCollectionContract(response.Content);
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public Task<IDictionary<string, Matchup>> GetMatchesAsync()
        {
            return this.GetMatchesAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public Task<IDictionary<string, Matchup>> GetMatchesAsync(CancellationToken cancellationToken)
        {
            return this.serviceClient.SendAsync<MatchupCollectionDataContract>(new MatchDiscoveryRequest(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Matchups == null)
                        {
                            return new Dictionary<string, Matchup>(0);
                        }

                        return ConvertMatchupCollectionContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static CompetitiveMap ConvertCompetitiveMapContract(CompetitiveMapDataContract content)
        {
            Contract.Requires(content != null);

            // Create a new map object
            var value = (CompetitiveMap)Activator.CreateInstance(GetCompetitiveMapType(content.Type));

            // Set the scoreboard
            if (content.Scores != null && content.Scores.Length == 3)
            {
                value.Scores = ConvertScoreboardContract(content.Scores);
            }

            // Set the status of each objective
            if (content.Objectives != null)
            {
                value.Objectives = ConvertObjectiveContractCollection(content.Objectives);
            }

            // Set the status of each map bonus
            if (content.Bonuses != null)
            {
                value.Bonuses = ConvertMapBonusContractCollection(content.Bonuses);
            }

            // Return the map object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<CompetitiveMap> ConvertCompetitiveMapContractCollection(ICollection<CompetitiveMapDataContract> content)
        {
            Contract.Requires(content != null);

            // Create a new collection of maps
            var values = new List<CompetitiveMap>(content.Count);

            // Add each map and its status
            values.AddRange(content.Select(ConvertCompetitiveMapContract));

            // Return the collection
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static MapBonus ConvertMapBonusContract(MapBonusDataContract content)
        {
            Contract.Requires(content != null);

            // Create a new bonus object
            var value = (MapBonus)Activator.CreateInstance(GetMapBonusType(content.Type));

            // Set its status
            if (content.Owner != null)
            {
                value.Owner = ConvertTeamColorContract(content.Owner);
            }

            // Return the bonus object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<MapBonus> ConvertMapBonusContractCollection(ICollection<MapBonusDataContract> content)
        {
            Contract.Requires(content != null);

            // Create a new collection of map bonuses
            var values = new List<MapBonus>(content.Count);

            // Add each bonus and its status
            values.AddRange(content.Select(ConvertMapBonusContract));

            // Return the collection
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Match ConvertMatchContract(MatchDataContract content)
        {
            Contract.Requires(content != null);

            // Create a new match object
            var value = new Match();

            // Set the match identfieier
            if (content.MatchId != null)
            {
                value.MatchId = content.MatchId;
            }

            // Set the scoreboard
            if (content.Scores != null && content.Scores.Length == 3)
            {
                value.Scores = ConvertScoreboardContract(content.Scores);
            }

            // Set a collection of maps and their status
            if (content.Maps != null)
            {
                value.Maps = ConvertCompetitiveMapContractCollection(content.Maps);
            }

            // Return the match object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<string, Matchup> ConvertMatchupCollectionContract(MatchupCollectionDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Matchups != null);
            Contract.Ensures(Contract.Result<IDictionary<string, Matchup>>() != null);

            // Create a new collection of matchup objects
            var values = new Dictionary<string, Matchup>(content.Matchups.Count);

            // Add each matchup and its status
            foreach (var value in content.Matchups.Select(ConvertMatchupContract))
            {
                Contract.Assume(value != null);
                values.Add(value.MatchId, value);
            }

            // Return the collection
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Matchup ConvertMatchupContract(MatchupDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Matchup>() != null);

            // Create a new matchup object
            var value = new Matchup();

            // Set the match identifier
            if (content.MatchId != null)
            {
                value.MatchId = content.MatchId;
            }

            // Set the red world identifier
            value.RedWorldId = content.RedWorldId;

            // Set the blue world identifier
            value.BlueWorldId = content.BlueWorldId;

            // Set the green world identifier
            value.GreenWorldId = content.GreenWorldId;

            // Set the start time
            if (content.StartTime != null)
            {
                value.StartTime = DateTimeOffset.Parse(content.StartTime);
            }

            // Set the end time
            if (content.EndTime != null)
            {
                value.EndTime = DateTimeOffset.Parse(content.EndTime);
            }

            // Return the matchup object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Objective ConvertObjectiveContract(ObjectiveDataContract content)
        {
            Contract.Requires(content != null);

            // Create a new objective object
            var value = new Objective();

            // Set the objective identifier
            value.ObjectiveId = content.Id;

            // Set the status
            if (content.Owner != null)
            {
                value.Owner = ConvertTeamColorContract(content.Owner);
            }

            // Set the guild identifier of the guild that claimed the objective
            if (content.OwnerGuild != null)
            {
                value.OwnerGuildId = Guid.Parse(content.OwnerGuild);
            }

            // Return the objective object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<Objective> ConvertObjectiveContractCollection(ICollection<ObjectiveDataContract> content)
        {
            Contract.Requires(content != null);

            // Create a new collection of objectives
            var values = new List<Objective>(content.Count);

            // Add each objective and its status
            values.AddRange(content.Select(ConvertObjectiveContract));

            // Return the collection
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Scoreboard ConvertScoreboardContract(int[] content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Length == 3);
            return new Scoreboard { Red = content[0], Blue = content[1], Green = content[2] };
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static TeamColor ConvertTeamColorContract(string content)
        {
            Contract.Requires(content != null);
            return (TeamColor)Enum.Parse(typeof(TeamColor), content, true);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="type">The type discriminator.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        /// <exception cref="NotSupportedException">The exception that is thrown when the specified type is not supported.</exception>
        private static Type GetCompetitiveMapType(string type)
        {
            switch (type)
            {
                case "RedHome":
                    return typeof(RedBorderlands);
                case "GreenHome":
                    return typeof(GreenBorderlands);
                case "BlueHome":
                    return typeof(BlueBorderlands);
                case "Center":
                    return typeof(EternalBattlegrounds);
                default:
                    throw new NotSupportedException(string.Format("Map type '{0}' is not supported.", type));
            }
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="type">The type discriminator.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetMapBonusType(string type)
        {
            switch (type)
            {
                case "bloodlust":
                    return typeof(Bloodlust);
                default:
                    return typeof(UnknownMapBonus);
            }
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}