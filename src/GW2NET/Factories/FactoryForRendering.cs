// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForRendering.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the rendering service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories
{
    using System;

    using GW2NET.Common;
    using GW2NET.Rendering;

    /// <summary>Provides access to the rendering service.</summary>
    public class FactoryForRendering : ServiceFactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForRendering"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public FactoryForRendering(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets access to the rendering service.</summary>
        public IRenderService RenderService
        {
            get
            {
                return new RenderService(this.ServiceClient);
            }
        }
    }
}