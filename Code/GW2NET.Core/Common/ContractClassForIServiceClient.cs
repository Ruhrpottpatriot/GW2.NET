// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClientContracts.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ServiceClientContracts type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    [ContractClassFor(typeof(IServiceClient))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIServiceClient : IServiceClient
    {
        public IResponse<TResult> Send<TResult>(IRequest request)
        {
            Contract.Requires(request != null);
            Contract.Ensures(Contract.Result<IResponse<TResult>>() != null);
            Contract.Ensures(Contract.Result<IResponse<TResult>>().ExtensionData != null);
            throw new System.NotImplementedException();
        }

        public Task<IResponse<TResult>> SendAsync<TResult>(IRequest request)
        {
            Contract.Requires(request != null);
            Contract.Ensures(Contract.Result<Task<IResponse<TResult>>>() != null);
            Contract.Ensures(Contract.Result<Task<IResponse<TResult>>>().Result != null);
            Contract.Ensures(Contract.Result<Task<IResponse<TResult>>>().Result.ExtensionData != null);
            throw new System.NotImplementedException();
        }

        public Task<IResponse<TResult>> SendAsync<TResult>(IRequest request, CancellationToken cancellationToken)
        {
            Contract.Requires(request != null);
            Contract.Ensures(Contract.Result<Task<IResponse<TResult>>>() != null);
            Contract.Ensures(Contract.Result<Task<IResponse<TResult>>>().Result != null);
            Contract.Ensures(Contract.Result<Task<IResponse<TResult>>>().Result.ExtensionData != null);
            throw new System.NotImplementedException();
        }
    }
}