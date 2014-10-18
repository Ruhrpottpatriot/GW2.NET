// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIItemDiscoveryService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIItemDiscoveryService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    [ContractClassFor(typeof(IItemDiscoveryService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIItemDiscoveryService : IItemDiscoveryService
    {
        public ICollection<int> GetItems()
        {
            Contract.Ensures(Contract.Result<ICollection<int>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<ICollection<int>> GetItemsAsync()
        {
            Contract.Ensures(Contract.Result<Task<ICollection<int>>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<ICollection<int>> GetItemsAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<ICollection<int>>>() != null);
            throw new System.NotImplementedException();
        }
    }
}