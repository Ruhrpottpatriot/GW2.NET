// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/wvw/matches.json and /v1/wvw/match_details.json interfaces.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.WorldVersusWorld.Matches
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.V2.WorldVersusWorld.Matches.Json;
    using GW2NET.WorldVersusWorld;

    /// <summary>Represents a repository that retrieves data from the /v1/wvw/matches.json and /v1/wvw/match_details.json interfaces.</summary>
    public class MatchRepository : IMatchIdRepository, IMatchWorldRepository
    {
        private readonly IConverter<MatchDTO, Match> matchConverter;

        private readonly IConverter<IResponse<ICollection<string>>, ICollection<string>> matchupConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MatchRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="matchConverter">The converter <see cref="Match"/>.</param>
        public MatchRepository(IServiceClient serviceClient, IConverter<MatchDTO, Match> matchConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException(nameof(serviceClient));
            }

            if (matchConverter == null)
            {
                throw new ArgumentNullException(nameof(matchConverter));
            }

            this.serviceClient = serviceClient;
            this.matchConverter = matchConverter;
            this.matchupConverter = new ResponseConverter<ICollection<string>, ICollection<string>>(new ConverterAdapter<ICollection<string>>());
        }

        /// <inheritdoc />
        ICollection<string> IDiscoverable<string>.Discover()
        {
            var request = new MatchDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            return this.matchupConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync()
        {
            IMatchIdRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new MatchDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken).ConfigureAwait(false);
            return this.matchupConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Match IRepository<string, Match>.Find(string identifier)
        {
            var request = new MatchDetailsRequest
            {
                Identifier = identifier
            };
            var response = this.serviceClient.Send<MatchDTO>(request);
            if (response.Content == null)
            {
                return null;
            }

            return this.matchConverter.Convert(response.Content, null);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Match> IRepository<string, Match>.FindAll()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<string, Match> IRepository<string, Match>.FindAll(ICollection<string> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Match>> IRepository<string, Match>.FindAllAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Match>> IRepository<string, Match>.FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Match>> IRepository<string, Match>.FindAllAsync(ICollection<string> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Match>> IRepository<string, Match>.FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<Match> IRepository<string, Match>.FindAsync(string identifier)
        {
            IMatchIdRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Match> IRepository<string, Match>.FindAsync(string identifier, CancellationToken cancellationToken)
        {
            var request = new MatchDetailsRequest
            {
                Identifier = identifier
            };
            var response = await this.serviceClient.SendAsync<MatchDTO>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return null;
            }

            return this.matchConverter.Convert(response.Content, response);
        }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        async Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Match IRepository<int, Match>.Find(int identifier)
        {
            var request = new MatchDetailsRequest
            {
                WorldId = identifier
            };
            var response = this.serviceClient.Send<MatchDTO>(request);
            if (response.Content == null)
            {
                return null;
            }

            return this.matchConverter.Convert(response.Content, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Match> IRepository<int, Match>.FindAll()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<int, Match> IRepository<int, Match>.FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Match>> IRepository<int, Match>.FindAllAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Match>> IRepository<int, Match>.FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Match>> IRepository<int, Match>.FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Match>> IRepository<int, Match>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<Match> IRepository<int, Match>.FindAsync(int identifier)
        {
            IMatchWorldRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Match> IRepository<int, Match>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new MatchDetailsRequest
            {
                WorldId = identifier
            };
            var response = await this.serviceClient.SendAsync<MatchDTO>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return null;
            }

            return this.matchConverter.Convert(response.Content, response);
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