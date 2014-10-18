// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIColorService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIColorService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Colors
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.Colors;

    [ContractClassFor(typeof(IColorService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIColorService : IColorService
    {
        public IDictionary<int, ColorPalette> GetColors()
        {
            Contract.Ensures(Contract.Result<IDictionary<int, ColorPalette>>() != null);
            throw new System.NotImplementedException();
        }

        public IDictionary<int, ColorPalette> GetColors(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<IDictionary<int, ColorPalette>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, ColorPalette>> GetColorsAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, ColorPalette>> GetColorsAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, ColorPalette>> GetColorsAsync(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<int, ColorPalette>> GetColorsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}