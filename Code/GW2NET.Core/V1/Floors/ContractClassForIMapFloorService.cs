// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIMapFloorService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIMapFloorService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Floors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.Maps;

    [ContractClassFor(typeof(IMapFloorService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIMapFloorService : IMapFloorService
    {
        public Floor GetMapFloor(int continent, int floor)
        {
            throw new System.NotImplementedException();
        }

        public Floor GetMapFloor(int continent, int floor, CultureInfo language)
        {
            Contract.Requires(language != null);
            throw new System.NotImplementedException();
        }

        public Task<Floor> GetMapFloorAsync(int continent, int floor)
        {
            Contract.Ensures(Contract.Result<Task<Floor>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Floor> GetMapFloorAsync(int continent, int floor, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Floor>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Floor> GetMapFloorAsync(int continent, int floor, CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<Floor>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Floor> GetMapFloorAsync(int continent, int floor, CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<Floor>>() != null);
            throw new System.NotImplementedException();
        }
    }
}