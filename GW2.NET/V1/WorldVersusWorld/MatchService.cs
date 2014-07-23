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
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Utilities;
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
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Match GetMatchDetails(string match)
        {
            Preconditions.EnsureNotNull(paramName: "match", value: match);
            var request = new MatchDetailsRequest { MatchId = match };
            var response = this.serviceClient.Send(request, new JsonSerializer<MatchContract>());
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
            Preconditions.EnsureNotNull(paramName: "match", value: match);
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
            return this.GetObjectiveNames(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IDictionary<int, ObjectiveName> GetObjectiveNames(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new ObjectiveNameRequest { Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<ICollection<ObjectiveNameContract>>());
            return MapObjectiveNameContracts(response.Content, language);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync()
        {
            return this.GetObjectiveNamesAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CancellationToken cancellationToken)
        {
            return this.GetObjectiveNamesAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
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
            Preconditions.EnsureNotNull(paramName: "language", value: language);
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
            var value = (CompetitiveMap)Activator.CreateInstance(GetCompetitiveMapType(content.Type));
            value.Scores = MapScoreboardContract(content.Scores);
            value.Objectives = MapObjectiveContracts(content.Objectives);
            value.Bonuses = MapMapBonusContracts(content.Bonuses);
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<CompetitiveMap> MapCompetitiveMapContracts(ICollection<CompetitiveMapContract> content)
        {
            var values = new List<CompetitiveMap>(content.Count);
            values.AddRange(content.Select(MapCompetitiveMapContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static MapBonus MapMapBonusContract(MapBonusContract content)
        {
            var value = (MapBonus)Activator.CreateInstance(GetMapBonusType(content.Type));
            value.Owner = MapTeamColorContract(content.Owner);
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<MapBonus> MapMapBonusContracts(ICollection<MapBonusContract> content)
        {
            var values = new List<MapBonus>(content.Count);
            values.AddRange(content.Select(MapMapBonusContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Match MapMatchContract(MatchContract content)
        {
            return new Match { MatchId = content.MatchId, Scores = MapScoreboardContract(content.Scores), Maps = MapCompetitiveMapContracts(content.Maps) };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<string, Matchup> MapMatchupCollectionContract(MatchupCollectionContract content)
        {
            var values = new Dictionary<string, Matchup>(content.Matchups.Count);
            foreach (var value in content.Matchups.Select(MapMatchupContract))
            {
                values.Add(value.MatchId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Matchup MapMatchupContract(MatchupContract content)
        {
            return new Matchup
                       {
                           MatchId = content.MatchId, 
                           RedWorldId = content.RedWorldId, 
                           BlueWorldId = content.BlueWorldId, 
                           GreenWorldId = content.GreenWorldId, 
                           StartTime = DateTimeOffset.Parse(content.StartTime), 
                           EndTime = DateTimeOffset.Parse(content.EndTime)
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Objective MapObjectiveContract(ObjectiveContract content)
        {
            return new Objective
                       {
                           ObjectiveId = content.Id, 
                           Owner = MapTeamColorContract(content.Owner), 
                           OwnerGuildId = string.IsNullOrEmpty(content.OwnerGuild) ? (Guid?)null : Guid.Parse(content.OwnerGuild)
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<Objective> MapObjectiveContracts(ICollection<ObjectiveContract> content)
        {
            var values = new List<Objective>(content.Count);
            values.AddRange(content.Select(MapObjectiveContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static ObjectiveName MapObjectiveNameContract(ObjectiveNameContract content)
        {
            return new ObjectiveName { ObjectiveId = int.Parse(content.Id), Name = content.Name };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, ObjectiveName> MapObjectiveNameContracts(ICollection<ObjectiveNameContract> content, CultureInfo culture)
        {
            var values = new Dictionary<int, ObjectiveName>(content.Count);
            foreach (var value in content.Select(MapObjectiveNameContract))
            {
                value.Language = culture.TwoLetterISOLanguageName;
                values.Add(value.ObjectiveId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Scoreboard MapScoreboardContract(int[] content)
        {
            return new Scoreboard { Red = content[0], Blue = content[1], Green = content[2] };
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static TeamColor MapTeamColorContract(string content)
        {
            return (TeamColor)Enum.Parse(typeof(TeamColor), content, true);
        }
    }
}