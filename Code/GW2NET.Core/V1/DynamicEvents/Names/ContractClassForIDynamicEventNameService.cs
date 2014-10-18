// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIDynamicEventNameService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIDynamicEventNameService type.
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

    [ContractClassFor(typeof(IDynamicEventNameService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIDynamicEventNameService : IDynamicEventNameService
    {
        public IDictionary<Guid, DynamicEvent> GetDynamicEventNames()
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEvent>>() != null);
            throw new NotImplementedException();
        }

        public IDictionary<Guid, DynamicEvent> GetDynamicEventNames(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEvent>>() != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>().Result != null);
            throw new NotImplementedException();
        }

        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<Guid, DynamicEvent>>>().Result != null);
            throw new NotImplementedException();
        }
    }
}