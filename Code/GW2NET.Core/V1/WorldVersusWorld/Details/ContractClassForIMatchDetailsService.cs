// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIMatchDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIMatchDetailsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.WorldVersusWorld;

    [ContractClassFor(typeof(IMatchDetailsService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIMatchDetailsService : IMatchDetailsService
    {
        public Match GetMatchDetails(string match)
        {
            throw new System.NotImplementedException();
        }

        public Task<Match> GetMatchDetailsAsync(string match)
        {
            Contract.Ensures(Contract.Result<Task<Match>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Match> GetMatchDetailsAsync(string match, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Match>>() != null);
            throw new System.NotImplementedException();
        }
    }
}