// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIDiscoverable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIDiscoverable type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    [ContractClassFor(typeof(IDiscoverable<>))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIDiscoverable<T> : IDiscoverable<T>
    {
        public ICollection<T> Discover()
        {
            Contract.Ensures(Contract.Result<ICollection<T>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<ICollection<T>> DiscoverAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<T>> DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}