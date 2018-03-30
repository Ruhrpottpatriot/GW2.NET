// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AccountDTO" /> to objects of type <see cref="Account" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Accounts.Converter
{
    using System;

    using GW2NET.Accounts;
    using GW2NET.Common;
    using GW2NET.V2.Accounts.Json;

    /// <summary>Converts objects of type <see cref="AccountDTO"/> to objects of type <see cref="Account"/>.</summary>
    public sealed class AccountConverter : IConverter<AccountDTO, Account>
    {
        /// <inheritdoc />
        public Account Convert(AccountDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return new Account
            {
                Guilds = value.Guilds,
                Id = value.Id,
                Name = value.Name,
                World = value.World
            };
        }
    }
}