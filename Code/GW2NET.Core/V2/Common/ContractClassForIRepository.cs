// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    [ContractClassFor(typeof(IRepository<,>))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIRepository<TKey, TValue> : IRepository<TKey, TValue>
    {
        public abstract ICollection<TKey> Discover();

        public abstract Task<ICollection<TKey>> DiscoverAsync();

        public abstract Task<ICollection<TKey>> DiscoverAsync(CancellationToken cancellationToken);

        public TValue Find(TKey identifier)
        {
            throw new System.NotImplementedException();
        }

        public IDictionaryRange<TKey, TValue> FindAll()
        {
            Contract.Ensures(Contract.Result<IDictionaryRange<TKey, TValue>>() != null);
            throw new System.NotImplementedException();
        }

        public IDictionaryRange<TKey, TValue> FindAll(ICollection<TKey> identifiers)
        {
            Contract.Requires(identifiers != null);
            Contract.Requires(identifiers.Count > 0);
            Contract.Ensures(Contract.Result<IDictionaryRange<TKey, TValue>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionaryRange<TKey, TValue>> FindAllAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionaryRange<TKey, TValue>> FindAllAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionaryRange<TKey, TValue>> FindAllAsync(ICollection<TKey> identifiers)
        {
            Contract.Requires(identifiers != null);
            Contract.Requires(identifiers.Count > 0);
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionaryRange<TKey, TValue>> FindAllAsync(ICollection<TKey> identifiers, CancellationToken cancellationToken)
        {
            Contract.Requires(identifiers != null);
            Contract.Requires(identifiers.Count > 0);
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<TValue> FindAsync(TKey identifier)
        {
            Contract.Ensures(Contract.Result<Task>() != null);
            throw new System.NotImplementedException();
        }

        public Task<TValue> FindAsync(TKey identifier, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task>() != null);
            throw new System.NotImplementedException();
        }

        public abstract ICollectionPage<TValue> FindPage(int pageIndex);

        public abstract ICollectionPage<TValue> FindPage(int pageIndex, int pageSize);

        public abstract Task<ICollectionPage<TValue>> FindPageAsync(int pageIndex);

        public abstract Task<ICollectionPage<TValue>> FindPageAsync(int pageIndex, CancellationToken cancellationToken);

        public abstract Task<ICollectionPage<TValue>> FindPageAsync(int pageIndex, int pageSize);

        public abstract Task<ICollectionPage<TValue>> FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken);
    }
}