// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIObjectiveNameService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIObjectiveNameService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.WorldVersusWorld;

    [ContractClassFor(typeof(IObjectiveNameService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIObjectiveNameService : IObjectiveNameService
    {
        public IDictionary<int, ObjectiveName> GetObjectiveNames()
        {
            Contract.Ensures(Contract.Result<IDictionary<int, ObjectiveName>>() != null);
            throw new System.NotImplementedException();
        }

        public IDictionary<int, ObjectiveName> GetObjectiveNames(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<IDictionary<int, ObjectiveName>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ObjectiveName>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}