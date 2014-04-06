// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The color service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.Colors;

    using Ninject.Modules;

    /// <summary>The color service bindings.</summary>
    public class ColorServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IColorService>().To<ColorService>().WhenInjectedInto<IColorServiceCache>();
            this.Bind<IColorService>().To<ColorServiceCache>();
        }
    }
}