// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The skin service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.Skins;
    using global::GW2DotNET.V1.Skins.Details;

    using Ninject.Modules;

    /// <summary>The skin service bindings.</summary>
    public class SkinServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<ISkinService>().To<SkinService>();
            this.Bind<ISkinDetailsService>().To<SkinDetailsService>();
        }
    }
}