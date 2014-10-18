// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForISkinDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForISkinDetailsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Skins
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.Skins;

    [ContractClassFor(typeof(ISkinDetailsService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForISkinDetailsService : ISkinDetailsService
    {
        public Skin GetSkinDetails(int skin)
        {
            throw new System.NotImplementedException();
        }

        public Skin GetSkinDetails(int skin, CultureInfo language)
        {
            Contract.Requires(language != null);
            throw new System.NotImplementedException();
        }

        public Task<Skin> GetSkinDetailsAsync(int skin)
        {
            Contract.Ensures(Contract.Result<Task<Skin>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Skin> GetSkinDetailsAsync(int skin, CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<Skin>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Skin> GetSkinDetailsAsync(int skin, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Skin>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<Skin> GetSkinDetailsAsync(int skin, CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<Skin>>() != null);
            throw new System.NotImplementedException();
        }
    }
}