// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIBuildService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIBuildService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Builds
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Builds;

    [ContractClassFor(typeof(IBuildService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIBuildService : IBuildService
    {
        public Build GetBuild()
        {
            throw new System.NotImplementedException();
        }

        public Task<Build> GetBuildAsync()
        {
            Contract.Ensures(Contract.Result<Task<Build>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Build> GetBuildAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Build>>() != null);
            throw new System.NotImplementedException();
        }
    }
}