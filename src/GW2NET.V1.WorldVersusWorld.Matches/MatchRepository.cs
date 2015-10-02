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
    using GW2NET.V1.WorldVersusWorld.Matches.Json;
    using GW2NET.WorldVersusWorld;

    /// <summary>Represents a repository that retrieves data from the /v1/wvw/matches.json and /v1/wvw/match_details.json interfaces.</summary>
    public class MatchRepository : IMatchRepository
    {
        private readonly IConverter<MatchDTO, Match> matchConverter;

        private readonly IConverter<MatchupDTO, Matchup> matchupConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MatchRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="matchupConverter">The converter <see cref="Matchup"/>.</param>
        /// <param name="matchConverter">The converter <see cref="Match"/>.</param>
        public MatchRepository(IServiceClient serviceClient, IConverter<MatchupDTO, Matchup> matchupConverter, IConverter<MatchDTO, Match> matchConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (matchupConverter == null)
            {
                throw new ArgumentNullException("matchupConverter");
            }

            if (matchConverter == null)
            {
                throw new ArgumentNullException("matchConverter");
            }

            this.serviceClient = serviceClient;
            this.matchupConverter = matchupConverter;
            this.matchConverter = matchConverter;
        }

        /// <inheritdoc />
        ICollection<Matchup> IDiscoverable<Matchup>.Discover()
        {
            var request = new MatchDiscoveryRequest();
            var response = this.serviceClient.Send<MatchupCollectionDTO>(request);
            if (response.Content == null || response.Content.Matchups == null)
            {
                return new Matchup[0];
            }

            var values = new List<Matchup>(response.Content.Matchups.Count);
            values.AddRange(response.Content.Matchups.Select(value => this.matchupConverter.Convert(value, null)));
            return values;
        }

        /// <inheritdoc />
        Task<ICollection<Matchup>> IDiscoverable<Matchup>.DiscoverAsync()
        {
            IMatchRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<Matchup>> IDiscoverable<Matchup>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new MatchDiscoveryRequest();
            return this.serviceClient.SendAsync<MatchupCollectionDTO>(request, cancellationToken).ContinueWith<ICollection<Matchup>>(task =>
            {
                var response = task.Result;
                if (response.Content == null || response.Content.Matchups == null)
                {
                    return new Matchup[0];
                }

                var values = new List<Matchup>(response.Content.Matchups.Count);
                values.AddRange(response.Content.Matchups.Select(value => this.matchupConverter.Convert(value, null)));
                return values;
            }, cancellationToken);
        }

        /// <inheritdoc />
        Match IRepository<Matchup, Match>.Find(Matchup identifier)
        {
            string matchId = identifier != null ? identifier.MatchId : null;
            var request = new MatchDetailsRequest
            {
                MatchId = matchId
            };
            var response = this.serviceClient.Send<MatchDTO>(request);
            if (response.Content == null)
            {
                return null;
            }

            return this.matchConverter.Convert(response.Content, null);
        }

        /// <inheritdoc />
        IDictionaryRange<Matchup, Match> IRepository<Matchup, Match>.FindAll()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<Matchup, Match> IRepository<Matchup, Match>.FindAll(ICollection<Matchup> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Matchup, Match>> IRepository<Matchup, Match>.FindAllAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Matchup, Match>> IRepository<Matchup, Match>.FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Matchup, Match>> IRepository<Matchup, Match>.FindAllAsync(ICollection<Matchup> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Matchup, Match>> IRepository<Matchup, Match>.FindAllAsync(ICollection<Matchup> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<Match> IRepository<Matchup, Match>.FindAsync(Matchup identifier)
        {
            IMatchRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Match> IRepository<Matchup, Match>.FindAsync(Matchup identifier, CancellationToken cancellationToken)
        {
            string matchId = identifier != null ? identifier.MatchId : null;
            var request = new MatchDetailsRequest
            {
                MatchId = matchId
            };
            return this.serviceClient.SendAsync<MatchDTO>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return null;
                }

                return this.matchConverter.Convert(response.Content, null);
            }, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Match> IPaginator<Match>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<Match> IPaginator<Match>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Match>> IPaginator<Match>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Match>> IPaginator<Match>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Match>> IPaginator<Match>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Match>> IPaginator<Match>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}