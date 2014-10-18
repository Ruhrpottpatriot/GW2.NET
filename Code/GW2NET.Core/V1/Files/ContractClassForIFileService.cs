// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIFileService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIFileService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Files
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.Files;

    [ContractClassFor(typeof(IFileService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIFileService : IFileService
    {
        public IDictionary<string, Asset> GetFiles()
        {
            Contract.Ensures(Contract.Result<IDictionary<string, Asset>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<string, Asset>> GetFilesAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<string, Asset>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<string, Asset>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<string, Asset>> GetFilesAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<string, Asset>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<string, Asset>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}