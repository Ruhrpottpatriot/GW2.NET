// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIItemDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIItemDetailsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.Items;

    [ContractClassFor(typeof(IItemDetailsService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIItemDetailsService : IItemDetailsService
    {
        public Item GetItemDetails(int item)
        {
            throw new System.NotImplementedException();
        }

        public Item GetItemDetails(int item, CultureInfo language)
        {
            Contract.Requires(language != null);
            throw new System.NotImplementedException();
        }

        public Task<Item> GetItemDetailsAsync(int item)
        {
            Contract.Ensures(Contract.Result<Task<Item>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Item> GetItemDetailsAsync(int item, CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<Item>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Item> GetItemDetailsAsync(int item, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Item>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Item> GetItemDetailsAsync(int item, CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<Item>>() != null);
            throw new System.NotImplementedException();
        }
    }
}