// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the authorized /va/account interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Accounts
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using GW2NET.Accounts;
    using GW2NET.Common;

    /// <summary>Represents a repository that retrieves data from the authorized /v2/account interface.</summary>
    public class AccountRepository : IAccountRepository
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Infrastructure. Holds a reference to the response converter.
        /// </summary>
        private readonly IConverter<IResponse<AccountDataContract>, Account> responseConverter;

        /// <summary>Initializes a new instance of the <see cref="AccountRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public AccountRepository(IServiceClient serviceClient)
            : this(serviceClient, new AccountConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AccountRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="responseConverter">The response converter.</param>
        private AccountRepository(IServiceClient serviceClient, IConverter<AccountDataContract, Account> responseConverter)
        {
            this.serviceClient = serviceClient;
            this.responseConverter = new ConverterForResponse<AccountDataContract, Account>(responseConverter);
        }

        /// <inheritdoc />
        Account IAccountRepository.GetInformation()
        {
            IRequest request = new AccountRequest();
            IResponse<AccountDataContract> response = this.serviceClient.Send<AccountDataContract>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<Account> IAccountRepository.GetInformationAsync()
        {
            return ((IAccountRepository)this).GetInformationAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Account> IAccountRepository.GetInformationAsync(CancellationToken cancellationToken)
        {
            var request = new AccountRequest();
            var response = this.serviceClient.SendAsync<AccountDataContract>(request, cancellationToken);
            return response.ContinueWith<Account>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <summary>Converts an asynchronous response to the type requested.</summary>
        /// <param name="task">The task to convert.</param>
        /// <returns>An <see cref="Account"/>.</returns>
        private Account ConvertAsyncResponse(Task<IResponse<AccountDataContract>> task)
        {
            Debug.Assert(task != null, "task != null");

            return this.responseConverter.Convert(task.Result, null);
        }
    }
}