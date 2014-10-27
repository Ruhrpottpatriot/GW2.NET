// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/wvw/matches.json and /v1/wvw/match_details.json interfaces.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Matches
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.WorldVersusWorld;
    using GW2NET.V1.WorldVersusWorld.Matches.Json;
    using GW2NET.V1.WorldVersusWorld.Matches.Json.Converters;

    /// <summary>Represents a repository that retrieves data from the /v1/wvw/matches.json and /v1/wvw/match_details.json interfaces.</summary>
    public class MatchRepository : IRepository<Matchup, Match>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<MatchDataContract, Match> converterForMatch;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<MatchupDataContract, Matchup> converterForMatchup;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MatchRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MatchRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForMatchup(), new ConverterForMatch())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MatchRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForMatchup">The converter <see cref="Matchup"/>.</param>
        /// <param name="converterForMatch">The converter <see cref="Match"/>.</param>
        internal MatchRepository(IServiceClient serviceClient, IConverter<MatchupDataContract, Matchup> converterForMatchup, IConverter<MatchDataContract, Match> converterForMatch)
        {
            this.serviceClient = serviceClient;
            this.converterForMatchup = converterForMatchup;
            this.converterForMatch = converterForMatch;
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public ICollection<Matchup> Discover()
        {
            var request = new MatchDiscoveryRequest();
            var response = this.serviceClient.Send<MatchupCollectionDataContract>(request);
            if (response.Content == null || response.Content.Matchups == null)
            {
                return new Matchup[0];
            }

            var values = new List<Matchup>(response.Content.Matchups.Count);
            values.AddRange(response.Content.Matchups.Select(this.converterForMatchup.Convert));
            return values;
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<Matchup>> DiscoverAsync()
        {
            return this.DiscoverAsync(CancellationToken.None);
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<Matchup>> DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new MatchDiscoveryRequest();
            return this.serviceClient.SendAsync<MatchupCollectionDataContract>(request, cancellationToken).ContinueWith<ICollection<Matchup>>(task =>
            {
                var response = task.Result;
                if (response.Content == null || response.Content.Matchups == null)
                {
                    return new Matchup[0];
                }

                var values = new List<Matchup>(response.Content.Matchups.Count);
                values.AddRange(response.Content.Matchups.Select(this.converterForMatchup.Convert));
                return values;
            }, cancellationToken);
        }

        /// <summary>Finds the <see cref="Match"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Match"/> with the specified identifier.</returns>
        public Match Find(Matchup identifier)
        {
            string matchId = identifier != null ? identifier.MatchId : null;
            var request = new MatchDetailsRequest { MatchId = matchId };
            var response = this.serviceClient.Send<MatchDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return this.converterForMatch.Convert(response.Content);
        }

        /// <summary>Finds every <see cref="Match"/>.</summary>
        /// <returns>A collection of every <see cref="Match"/>.</returns>
        public IDictionaryRange<Matchup, Match> FindAll()
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Match"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Match"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<Matchup, Match> FindAll(ICollection<Matchup> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Match"/>.</summary>
        /// <returns>A collection of every <see cref="Match"/>.</returns>
        public Task<IDictionaryRange<Matchup, Match>> FindAllAsync()
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Match"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="Match"/></returns>
        public Task<IDictionaryRange<Matchup, Match>> FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Match"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Match"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<Matchup, Match>> FindAllAsync(ICollection<Matchup> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Match"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="Match"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<Matchup, Match>> FindAllAsync(ICollection<Matchup> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="Match"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Match"/> with the specified identifier.</returns>
        public Task<Match> FindAsync(Matchup identifier)
        {
            return this.FindAsync(identifier, CancellationToken.None);
        }

        /// <summary>Finds the <see cref="Match"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Match"/> with the specified identifier.</returns>
        public Task<Match> FindAsync(Matchup identifier, CancellationToken cancellationToken)
        {
            string matchId = identifier != null ? identifier.MatchId : null;
            var request = new MatchDetailsRequest { MatchId = matchId };
            return this.serviceClient.SendAsync<MatchDataContract>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return null;
                }

                return this.converterForMatch.Convert(response.Content);
            }, cancellationToken);
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Match> FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page number and maximum size.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Match> FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Match>> FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Match>> FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Match>> FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Match>> FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}