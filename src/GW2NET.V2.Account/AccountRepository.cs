// <copyright file="AccountRepository.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Accounts
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using GW2NET.Accounts;
    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.V2.Accounts.Json;
    using Handlers;

    /// <summary>Represents a repository that retrieves data from the authorized /v2/account interface.</summary>
    public class AccountRepository : IAccountRepository
    {
        /// <summary>Initializes a new instance of the <see cref="AccountRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="apiKey"></param>
        /// <param name="responseConverter">The response converter.</param>
        public AccountRepository(IServiceClient serviceClient, string apiKey, IConverter<AccountDTO, Account> responseConverter)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            this.ApiKey = apiKey;
            this.Client = serviceClient ?? throw new ArgumentNullException(nameof(serviceClient));
            this.ResponseConverter = new ResponseConverter<AccountDTO, Account>(responseConverter);
        }

        public string ApiKey { get; }

        public IServiceClient Client { get; }

        public IConverter<IResponse<AccountDTO>, Account> ResponseConverter { get; }

        /// <inheritdoc />
        Task<Account> IAccountRepository.GetInformationAsync()
        {
            return ((IAccountRepository)this).GetInformationAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Account> IAccountRepository.GetInformationAsync(CancellationToken cancellationToken)
        {
            var request = ApiQuerySelector.Init(new CultureInfo("en"))
                .V2Authorized(this.ApiKey)
                .Account()
                .BuildSingle();

            var response = await this.Client.SendAsync<AccountDTO>(request, cancellationToken).ConfigureAwait(false);
            return this.ResponseConverter.Convert(response, null);
        }
    }
}