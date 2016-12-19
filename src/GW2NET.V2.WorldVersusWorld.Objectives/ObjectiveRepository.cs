// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveNameRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/wvw/objectives interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.WorldVersusWorld.Objectives
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.V2.WorldVersusWorld.Objectives.Json;
    using GW2NET.WorldVersusWorld;

    public class ObjectiveRepository : IObjectiveRepository
    {
        private readonly IConverter<ObjectiveDTO, Objective> objectiveConverter;

        private readonly IConverter<IResponse<ICollection<string>>, ICollection<string>> discoverConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ObjectiveRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="objectiveConverter">The converter <see cref="Objective"/>.</param>
        public ObjectiveRepository(IServiceClient serviceClient, IConverter<ObjectiveDTO, Objective> objectiveConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (objectiveConverter == null)
            {
                throw new ArgumentNullException("objectiveConverter");
            }

            this.serviceClient = serviceClient;
            this.objectiveConverter = objectiveConverter;
            this.discoverConverter = new ResponseConverter<ICollection<string>, ICollection<string>>(new ConverterAdapter<ICollection<string>>());
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<string> IDiscoverable<string>.Discover()
        {
            var request = new ObjectiveDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            return this.discoverConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync()
        {
            IObjectiveRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new ObjectiveDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken).ConfigureAwait(false);
            return this.discoverConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Objective IRepository<string, Objective>.Find(string identifier)
        {
            IObjectiveRepository self = this;
            var request = new ObjectiveDetailsRequest
            {
                Culture = self.Culture,
                Identifier = identifier
            };
            var response = this.serviceClient.Send<ObjectiveDTO>(request);
            if (response.Content == null)
            {
                return null;
            }

            var result = this.objectiveConverter.Convert(response.Content, null);
            result.Culture = self.Culture;
            return result;
        }

        /// <inheritdoc />
        IDictionaryRange<string, Objective> IRepository<string, Objective>.FindAll()
        {
            IObjectiveRepository self = this;
            return self.FindAll(null);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Objective> IRepository<string, Objective>.FindAll(ICollection<string> identifiers)
        {
            IObjectiveRepository self = this;
            var request = new ObjectiveBulkRequest
            {
                Culture = self.Culture,
                Identifiers = identifiers
            };
            var response = this.serviceClient.Send<ICollection<ObjectiveDTO>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<string, Objective>(0);
            }

            var values = response.Content.Select(value => this.objectiveConverter.Convert(value, null)).ToList();
            var objectives = new DictionaryRange<string, Objective>(values.Count)
            {
                SubtotalCount = values.Count,
                TotalCount = values.Count
            };

            foreach (var objective in values)
            {
                objective.Culture = request.Culture;
                objectives.Add(objective.ObjectiveId, objective);
            }

            return objectives;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Objective>> IRepository<string, Objective>.FindAllAsync()
        {
            IObjectiveRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Objective>> IRepository<string, Objective>.FindAllAsync(CancellationToken cancellationToken)
        {
            IObjectiveRepository self = this;
            return self.FindAllAsync(null, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Objective>> IRepository<string, Objective>.FindAllAsync(ICollection<string> identifiers)
        {
            IObjectiveRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<string, Objective>> IRepository<string, Objective>.FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
        {
            IObjectiveRepository self = this;
            var request = new ObjectiveBulkRequest
            {
                Culture = self.Culture,
                Identifiers = identifiers
            };
            var response = await this.serviceClient.SendAsync<ICollection<ObjectiveDTO>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<string, Objective>(0);
            }

            var values = response.Content.Select(value => this.objectiveConverter.Convert(value, null)).ToList();
            var objectives = new DictionaryRange<string, Objective>(values.Count)
            {
                SubtotalCount = values.Count,
                TotalCount = values.Count
            };

            foreach (var objective in values)
            {
                objective.Culture = request.Culture;
                objectives.Add(objective.ObjectiveId, objective);
            }

            return objectives;
        }

        /// <inheritdoc />
        Task<Objective> IRepository<string, Objective>.FindAsync(string identifier)
        {
            IObjectiveRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Objective> IRepository<string, Objective>.FindAsync(string identifier, CancellationToken cancellationToken)
        {
            IObjectiveRepository self = this;
            var request = new ObjectiveDetailsRequest
            {
                Culture = self.Culture,
                Identifier = identifier
            };
            var response = await this.serviceClient.SendAsync<ObjectiveDTO>(request, cancellationToken);
            if (response.Content == null)
            {
                return null;
            }

            var result = this.objectiveConverter.Convert(response.Content, null);
            result.Culture = self.Culture;
            return result;
        }

        /// <inheritdoc />
        ICollectionPage<Objective> IPaginator<Objective>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<Objective> IPaginator<Objective>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Objective>> IPaginator<Objective>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Objective>> IPaginator<Objective>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Objective>> IPaginator<Objective>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Objective>> IPaginator<Objective>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}
