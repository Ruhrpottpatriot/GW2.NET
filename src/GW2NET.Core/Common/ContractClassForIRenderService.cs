// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIRenderService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIRenderService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    [ContractClassFor(typeof(IRenderService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIRenderService : IRenderService
    {
        public byte[] GetImage(IRenderable file, string imageFormat)
        {
            Contract.Requires(file != null);
            Contract.Requires(imageFormat != null);
            Contract.Requires(imageFormat == "jpg" || imageFormat == "png");
            throw new System.NotImplementedException();
        }

        public Task<byte[]> GetImageAsync(IRenderable file, string imageFormat)
        {
            Contract.Requires(file != null);
            Contract.Requires(imageFormat != null);
            Contract.Requires(imageFormat == "jpg" || imageFormat == "png");
            throw new System.NotImplementedException();
        }

        public Task<byte[]> GetImageAsync(IRenderable file, string imageFormat, CancellationToken cancellationToken)
        {
            Contract.Requires(file != null);
            Contract.Requires(imageFormat != null);
            Contract.Requires(imageFormat == "jpg" || imageFormat == "png");
            throw new System.NotImplementedException();
        }
    }
}