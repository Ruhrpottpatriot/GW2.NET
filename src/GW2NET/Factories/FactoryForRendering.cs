// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForRendering.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the rendering service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Rendering;

    /// <summary>Provides access to the rendering service.</summary>
    public class FactoryForRendering : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForRendering"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForRendering(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Provides access to the rendering service.</summary>
        public IRenderService RenderService
        {
            get
            {
                Contract.Ensures(Contract.Result<IRenderService>() != null);
                return new RenderService(this.ServiceClient);
            }
        }
    }
}