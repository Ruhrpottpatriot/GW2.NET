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
    using GW2NET.Common.Converters;
    using GW2NET.V2.Accounts.Json;

    /// <summary>Represents a repository that retrieves data from the authorized /v2/account interface.</summary>
    public class AccountRepository : IAccountRepository
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Infrastructure. Holds a reference to the response converter.
        /// </summary>
        private readonly IConverter<IResponse<AccountDTO>, Account> responseConverter;

        /// <summary>Initializes a new instance of the <see cref="AccountRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="responseConverter">The response converter.</param>
        public AccountRepository(IServiceClient serviceClient, IConverter<AccountDTO, Account> responseConverter)
        {
            this.serviceClient = serviceClient;
            this.responseConverter = new ResponseConverter<AccountDTO, Account>(responseConverter);
        }

        /// <inheritdoc />
        Account IAccountRepository.GetInformation()
        {
            IRequest request = new AccountRequest();
            IResponse<AccountDTO> response = this.serviceClient.Send<AccountDTO>(request);
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
            var response = this.serviceClient.SendAsync<AccountDTO>(request, cancellationToken);
            return response.ContinueWith<Account>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <summary>Converts an asynchronous response to the type requested.</summary>
        /// <param name="task">The task to convert.</param>
        /// <returns>An <see cref="Account"/>.</returns>
        private Account ConvertAsyncResponse(Task<IResponse<AccountDTO>> task)
        {
            Debug.Assert(task != null, "task != null");

            return this.responseConverter.Convert(task.Result, null);
        }
    }
}