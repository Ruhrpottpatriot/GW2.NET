// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIMatchDiscoveryService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIMatchDiscoveryService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.WorldVersusWorld;

    [ContractClassFor(typeof(IMatchDiscoveryService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIMatchDiscoveryService : IMatchDiscoveryService
    {
        public IDictionary<string, Matchup> GetMatches()
        {
            Contract.Ensures(Contract.Result<IDictionary<string, Matchup>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<string, Matchup>> GetMatchesAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<string, Matchup>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<string, Matchup>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<string, Matchup>> GetMatchesAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<string, Matchup>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<string, Matchup>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}