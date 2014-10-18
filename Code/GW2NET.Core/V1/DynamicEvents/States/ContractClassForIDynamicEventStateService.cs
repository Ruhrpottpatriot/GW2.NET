// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIDynamicEventStateService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIDynamicEventStateService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.DynamicEvents;

    [ContractClassFor(typeof(IDynamicEventStateService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIDynamicEventStateService : IDynamicEventStateService
    {
        public DynamicEventState GetDynamicEvent(Guid eventId, int worldId)
        {
            throw new NotImplementedException();
        }

        public Task<DynamicEventState> GetDynamicEventAsync(Guid eventId, int worldId)
        {
            Contract.Ensures(Contract.Result<Task<DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        public Task<DynamicEventState> GetDynamicEventAsync(Guid eventId, int worldId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        public IDictionary<Guid, DynamicEventState> GetDynamicEvents()
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        public IDictionary<Guid, DynamicEventState> GetDynamicEventsById(Guid eventId)
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByIdAsync(Guid eventId)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByMap(int mapId)
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByMap(int mapId, int worldId)
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, int worldId)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByWorld(int worldId)
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventState>>() != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByWorldAsync(int worldId)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByWorldAsync(int worldId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEventState>>>().Result != null);
            throw new NotImplementedException();
        }
    }
}