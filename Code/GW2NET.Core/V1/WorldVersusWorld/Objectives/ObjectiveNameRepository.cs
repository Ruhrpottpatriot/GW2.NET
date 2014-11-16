// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveNameRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/wvw/objective_names.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Objectives
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Objectives.Converters;
    using GW2NET.V1.WorldVersusWorld.Objectives.Json;
    using GW2NET.WorldVersusWorld;
    using GW2NET.WorldVersusWorld.Objectives;

    /// <summary>Represents a repository that retrieves data from the /v1/wvw/objective_names.json interface.</summary>
    public class ObjectiveNameRepository : IObjectiveNameRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ObjectiveNameDataContract, ObjectiveName> converterForObjectiveName;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ObjectiveNameRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ObjectiveNameRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForObjectiveName())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ObjectiveNameRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForObjectiveName">The converter <see cref="ObjectiveName"/>.</param>
        internal ObjectiveNameRepository(IServiceClient serviceClient, IConverter<ObjectiveNameDataContract, ObjectiveName> converterForObjectiveName)
        {
            this.serviceClient = serviceClient;
            this.converterForObjectiveName = converterForObjectiveName;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

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
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ObjectiveName IRepository<int, ObjectiveName>.Find(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<int, ObjectiveName> IRepository<int, ObjectiveName>.FindAll()
        {
            IObjectiveNameRepository self = this;
            var request = new ObjectiveNameRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<ObjectiveNameDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, ObjectiveName>(0);
            }

            var values = response.Content.Select(this.converterForObjectiveName.Convert).ToList();
            var objectiveNames = new DictionaryRange<int, ObjectiveName>(values.Count)
            {
                SubtotalCount = values.Count, 
                TotalCount = values.Count
            };

            foreach (var objectiveName in values)
            {
                objectiveName.Culture = request.Culture;
                objectiveNames.Add(objectiveName.ObjectiveId, objectiveName);
            }

            return objectiveNames;
        }

        /// <inheritdoc />
        IDictionaryRange<int, ObjectiveName> IRepository<int, ObjectiveName>.FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ObjectiveName>> IRepository<int, ObjectiveName>.FindAllAsync()
        {
            IObjectiveNameRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ObjectiveName>> IRepository<int, ObjectiveName>.FindAllAsync(CancellationToken cancellationToken)
        {
            IObjectiveNameRepository self = this;
            var request = new ObjectiveNameRequest
            {
                Culture = self.Culture
            };
            return this.serviceClient.SendAsync<ICollection<ObjectiveNameDataContract>>(request, cancellationToken).ContinueWith<IDictionaryRange<int, ObjectiveName>>(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new DictionaryRange<int, ObjectiveName>(0);
                }

                var values = response.Content.Select(this.converterForObjectiveName.Convert).ToList();
                var objectiveNames = new DictionaryRange<int, ObjectiveName>(values.Count)
                {
                    SubtotalCount = values.Count, 
                    TotalCount = values.Count
                };

                foreach (var objectiveName in values)
                {
                    objectiveName.Culture = request.Culture;
                    objectiveNames.Add(objectiveName.ObjectiveId, objectiveName);
                }

                return objectiveNames;
            }, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ObjectiveName>> IRepository<int, ObjectiveName>.FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ObjectiveName>> IRepository<int, ObjectiveName>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ObjectiveName> IRepository<int, ObjectiveName>.FindAsync(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ObjectiveName> IRepository<int, ObjectiveName>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<ObjectiveName> IPaginator<ObjectiveName>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<ObjectiveName> IPaginator<ObjectiveName>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<ObjectiveName>> IPaginator<ObjectiveName>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<ObjectiveName>> IPaginator<ObjectiveName>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<ObjectiveName>> IPaginator<ObjectiveName>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<ObjectiveName>> IPaginator<ObjectiveName>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForObjectiveName != null);
        }
    }
}