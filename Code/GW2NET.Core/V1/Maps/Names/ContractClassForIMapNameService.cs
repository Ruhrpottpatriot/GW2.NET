// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIMapNameService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIMapNameService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.Maps;

    [ContractClassFor(typeof(IMapNameService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIMapNameService : IMapNameService
    {
        public IDictionary<int, Map> GetMapNames()
        {
            Contract.Ensures(Contract.Result<IDictionary<int, Map>>() != null);
            throw new System.NotImplementedException();
        }

        public IDictionary<int, Map> GetMapNames(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<IDictionary<int, Map>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, Map>> GetMapNamesAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Map>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Map>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, Map>> GetMapNamesAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Map>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Map>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, Map>> GetMapNamesAsync(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Map>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Map>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, Map>> GetMapNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Map>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, Map>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}