// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the matches service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.V1.WorldVersusWorld.Contracts;
    using GW2DotNET.WorldVersusWorld;

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
            var response = this.serviceClient.Send(request, new JsonSerializer<MatchContract>());
            if (response.Content == null)
            {
                return null;
            }

            return MapMatchContract(response.Content);
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
            return this.serviceClient.SendAsync(request, new JsonSerializer<MatchContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapMatchContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public IDictionary<string, Matchup> GetMatches()
        {
            var request = new MatchRequest();
            var response = this.serviceClient.Send(request, new JsonSerializer<MatchupCollectionContract>());
            if (response.Content == null || response.Content.Matchups == null)
            {
                return new Dictionary<string, Matchup>(0);
            }

            return MapMatchupCollectionContract(response.Content);
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
            return this.serviceClient.SendAsync(new MatchRequest(), new JsonSerializer<MatchupCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapMatchupCollectionContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IDictionary<int, ObjectiveName> GetObjectiveNames()
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetObjectiveNames(culture);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IDictionary<int, ObjectiveName> GetObjectiveNames(CultureInfo language)
        {
            var request = new ObjectiveNameRequest { Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<ICollection<ObjectiveNameContract>>());
            if (response.Content == null)
            {
                return new Dictionary<int, ObjectiveName>(0);
            }

            return MapObjectiveNameContracts(response.Content, language);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync()
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetObjectiveNamesAsync(culture, CancellationToken.None);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CancellationToken cancellationToken)
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetObjectiveNamesAsync(culture, cancellationToken);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language)
        {
            return this.GetObjectiveNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            var request = new ObjectiveNameRequest { Culture = language };
            return this.serviceClient.SendAsync(request, new JsonSerializer<ICollection<ObjectiveNameContract>>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapObjectiveNameContracts(response.Content, language);
                    }, 
                cancellationToken);
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

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static CompetitiveMap MapCompetitiveMapContract(CompetitiveMapContract content)
        {
            Contract.Requires(content != null);

            // Create a new map object
            var value = (CompetitiveMap)Activator.CreateInstance(GetCompetitiveMapType(content.Type));

            // Set the scoreboard
            if (content.Scores != null && content.Scores.Length == 3)
            {
                value.Scores = MapScoreboardContract(content.Scores);
            }

            // Set the status of each objective
            if (content.Objectives != null)
            {
                value.Objectives = MapObjectiveContracts(content.Objectives);
            }

            // Set the status of each map bonus
            if (content.Bonuses != null)
            {
                value.Bonuses = MapMapBonusContracts(content.Bonuses);
            }

            // Return the map object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<CompetitiveMap> MapCompetitiveMapContracts(ICollection<CompetitiveMapContract> content)
        {
            Contract.Requires(content != null);

            // Create a new collection of maps
            var values = new List<CompetitiveMap>(content.Count);

            // Add each map and its status
            values.AddRange(content.Select(MapCompetitiveMapContract));

            // Return the collection
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static MapBonus MapMapBonusContract(MapBonusContract content)
        {
            Contract.Requires(content != null);

            // Create a new bonus object
            var value = (MapBonus)Activator.CreateInstance(GetMapBonusType(content.Type));

            // Set its status
            value.Owner = MapTeamColorContract(content.Owner);

            // Return the bonus object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<MapBonus> MapMapBonusContracts(ICollection<MapBonusContract> content)
        {
            Contract.Requires(content != null);

            // Create a new collection of map bonuses
            var values = new List<MapBonus>(content.Count);

            // Add each bonus and its status
            values.AddRange(content.Select(MapMapBonusContract));

            // Return the collection
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Match MapMatchContract(MatchContract content)
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
                value.Scores = MapScoreboardContract(content.Scores);
            }

            // Set a collection of maps and their status
            if (content.Maps != null)
            {
                value.Maps = MapCompetitiveMapContracts(content.Maps);
            }

            // Return the match object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<string, Matchup> MapMatchupCollectionContract(MatchupCollectionContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<string, Matchup>>() != null);

            // Create a new collection of matchup objects
            var values = new Dictionary<string, Matchup>(content.Matchups.Count);

            // Add each matchup and its status
            foreach (var value in content.Matchups.Select(MapMatchupContract))
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
        private static Matchup MapMatchupContract(MatchupContract content)
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
        private static Objective MapObjectiveContract(ObjectiveContract content)
        {
            Contract.Requires(content != null);

            // Create a new objective object
            var value = new Objective();

            // Set the objective identifier
            value.ObjectiveId = content.Id;

            // Set the status
            if (content.Owner != null)
            {
                value.Owner = MapTeamColorContract(content.Owner);
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
        private static ICollection<Objective> MapObjectiveContracts(ICollection<ObjectiveContract> content)
        {
            Contract.Requires(content != null);

            // Create a new collection of objectives
            var values = new List<Objective>(content.Count);

            // Add each objective and its status
            values.AddRange(content.Select(MapObjectiveContract));

            // Return the collection
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static ObjectiveName MapObjectiveNameContract(ObjectiveNameContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<ObjectiveName>() != null);

            // Create a new objective object
            var value = new ObjectiveName();

            // Set the objective identifier
            if (content.Id != null)
            {
                value.ObjectiveId = int.Parse(content.Id);
            }

            // Set the name of the objective
            if (content.Name != null)
            {
                value.Name = content.Name;
            }

            // Return the objective object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, ObjectiveName> MapObjectiveNameContracts(ICollection<ObjectiveNameContract> content, CultureInfo culture)
        {
            Contract.Requires(content != null);
            Contract.Requires(culture != null);
            Contract.Ensures(Contract.Result<IDictionary<int, ObjectiveName>>() != null);

            // Create a new collection of objectives
            var values = new Dictionary<int, ObjectiveName>(content.Count);

            // Add each objective
            foreach (var value in content.Select(MapObjectiveNameContract))
            {
                Contract.Assume(value != null);
                value.Language = culture.TwoLetterISOLanguageName;
                values.Add(value.ObjectiveId, value);
            }

            // Return the collection
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Scoreboard MapScoreboardContract(int[] content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Length == 3);
            return new Scoreboard { Red = content[0], Blue = content[1], Green = content[2] };
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static TeamColor MapTeamColorContract(string content)
        {
            Contract.Requires(content != null);
            return (TeamColor)Enum.Parse(typeof(TeamColor), content, true);
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}