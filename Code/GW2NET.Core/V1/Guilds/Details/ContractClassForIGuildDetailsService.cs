// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIGuildDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIGuildDetailsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Guilds
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.Guilds;

    [ContractClassFor(typeof(IGuildDetailsService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIGuildDetailsService : IGuildDetailsService
    {
        public Guild GetGuildDetailsById(Guid guildId)
        {
            throw new NotImplementedException();
        }

        public Task<Guild> GetGuildDetailsByIdAsync(Guid guildId)
        {
            Contract.Ensures(Contract.Result<Task<Guild>>() != null);
            throw new NotImplementedException();
        }

        public Task<Guild> GetGuildDetailsByIdAsync(Guid guildId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Guild>>() != null);
            throw new NotImplementedException();
        }

        public Guild GetGuildDetailsByName(string guildName)
        {
            throw new NotImplementedException();
        }

        public Task<Guild> GetGuildDetailsByNameAsync(string guildName)
        {
            Contract.Ensures(Contract.Result<Task<Guild>>() != null);
            throw new NotImplementedException();
        }

        public Task<Guild> GetGuildDetailsByNameAsync(string guildName, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Guild>>() != null);
            throw new NotImplementedException();
        }
    }
}