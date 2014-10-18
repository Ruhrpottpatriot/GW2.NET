// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIDynamicEventDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIDynamicEventDetailsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.DynamicEvents;

    [ContractClassFor(typeof(IDynamicEventDetailsService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIDynamicEventDetailsService : IDynamicEventDetailsService
    {
        public IDictionary<Guid, DynamicEvent> GetDynamicEventDetails()
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEvent>>() != null);
            throw new NotImplementedException();
        }

        public IDictionary<Guid, DynamicEvent> GetDynamicEventDetails(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEvent>>() != null);
            throw new NotImplementedException();
        }

        public DynamicEvent GetDynamicEventDetails(Guid eventId)
        {
            throw new NotImplementedException();
        }

        public DynamicEvent GetDynamicEventDetails(Guid eventId, CultureInfo language)
        {
            Contract.Requires(language != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId)
        {
            Contract.Ensures(Contract.Result<Task<DynamicEvent>>() != null);
            throw new NotImplementedException();
        }

        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<DynamicEvent>>() != null);
            throw new NotImplementedException();
        }

        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<DynamicEvent>>() != null);
            throw new NotImplementedException();
        }

        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<DynamicEvent>>() != null);
            throw new NotImplementedException();
        }
    }
}