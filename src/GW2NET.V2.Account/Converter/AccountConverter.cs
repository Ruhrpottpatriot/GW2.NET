// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AccountDataContract" /> to objects of type <see cref="Account" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Accounts
{
    using System;
    using GW2NET.Accounts;
    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="AccountDataContract"/> to objects of type <see cref="Account"/>.</summary>
    internal sealed class AccountConverter : IConverter<AccountDataContract, Account>
    {
        /// <inheritdoc />
        public Account Convert(AccountDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
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