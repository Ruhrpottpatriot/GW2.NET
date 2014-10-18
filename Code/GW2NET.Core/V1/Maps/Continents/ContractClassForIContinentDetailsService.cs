// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIContinentDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIContinentDetailsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.Maps;

    [ContractClassFor(typeof(IContinentDetailsService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIContinentDetailsService : IContinentDetailsService
    {
        public IDictionary<int, Continent> GetContinents()
        {
            Contract.Ensures(Contract.Result<IDictionary<int, Continent>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, Continent>> GetContinentsAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Continent>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Continent>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, Continent>> GetContinentsAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Continent>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Continent>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}