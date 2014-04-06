// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The render service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.Rendering;

    using Ninject.Modules;

    /// <summary>The render service bindings.</summary>
    public class RenderServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IRenderService>().To<RenderService>();
        }
    }
}