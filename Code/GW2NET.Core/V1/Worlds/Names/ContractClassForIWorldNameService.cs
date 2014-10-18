// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIWorldNameService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIWorldNameService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Worlds
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.Worlds;

    [ContractClassFor(typeof(IWorldNameService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIWorldNameService : IWorldNameService
    {
        public IDictionary<int, World> GetWorldNames()
        {
            Contract.Ensures(Contract.Result<IDictionary<int, World>>() != null);
            throw new System.NotImplementedException();
        }

        public IDictionary<int, World> GetWorldNames(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<IDictionary<int, World>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, World>> GetWorldNamesAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, World>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, World>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, World>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, World>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, World>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, World>> GetWorldNamesAsync(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, World>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, World>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, World>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, World>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, World>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}