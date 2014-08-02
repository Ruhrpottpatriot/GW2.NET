// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClientContracts.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The service client contracts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common
{
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common.Serializers;

    /// <summary>The service client contracts.</summary>
    [ContractClassFor(typeof(IServiceClient))]
    internal abstract class ServiceClientContracts : IServiceClient
    {
        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="serializer">The serialization engine.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public IResponse<TResult> Send<TResult>(IRequest request, ISerializer<TResult> serializer)
        {
            Contract.Requires(request != null);
            Contract.Requires(serializer != null);
            Contract.Ensures(Contract.Result<IResponse<TResult>>() != null);
            Contract.Ensures(Contract.Result<IResponse<TResult>>().ExtensionData != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="serializer">The serialization engine.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<IResponse<TResult>> SendAsync<TResult>(IRequest request, ISerializer<TResult> serializer)
        {
            Contract.Requires(request != null);
            Contract.Requires(serializer != null);
            Contract.Ensures(Contract.Result<Task<IResponse<TResult>>>() != null);
            Contract.Ensures(Contract.Result<Task<IResponse<TResult>>>().Result != null);
            Contract.Ensures(Contract.Result<Task<IResponse<TResult>>>().Result.ExtensionData != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="serializer">The serialization engine.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<IResponse<TResult>> SendAsync<TResult>(IRequest request, ISerializer<TResult> serializer, CancellationToken cancellationToken)
        {
            Contract.Requires(request != null);
            Contract.Requires(serializer != null);
            Contract.Ensures(Contract.Result<Task<IResponse<TResult>>>() != null);
            Contract.Ensures(Contract.Result<Task<IResponse<TResult>>>().Result != null);
            Contract.Ensures(Contract.Result<Task<IResponse<TResult>>>().Result.ExtensionData != null);
            throw new System.NotImplementedException();
        }
    }
}