// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIPaginator.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIPaginator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.V2.Common;

    [ContractClassFor(typeof(IPaginator<>))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIPaginator<T> : IPaginator<T>
    {
        public ICollectionPage<T> FindPage(int pageIndex)
        {
            Contract.Requires(pageIndex >= 0);
            Contract.Ensures(Contract.Result<ICollectionPage<T>>() != null);
            throw new System.NotImplementedException();
        }

        public ICollectionPage<T> FindPage(int pageIndex, int pageSize)
        {
            Contract.Requires(pageIndex >= 0);
            Contract.Requires(pageSize > 0);
            Contract.Ensures(Contract.Result<ICollectionPage<T>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<ICollectionPage<T>> FindPageAsync(int pageIndex)
        {
            Contract.Requires(pageIndex >= 0);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<ICollectionPage<T>> FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            Contract.Requires(pageIndex >= 0);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<ICollectionPage<T>> FindPageAsync(int pageIndex, int pageSize)
        {
            Contract.Requires(pageIndex >= 0);
            Contract.Requires(pageSize > 0);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<ICollectionPage<T>> FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            Contract.Requires(pageIndex >= 0);
            Contract.Requires(pageSize > 0);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}