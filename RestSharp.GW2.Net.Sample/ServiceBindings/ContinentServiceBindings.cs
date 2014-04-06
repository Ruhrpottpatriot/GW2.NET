// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The continent service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.Continents;

    using Ninject.Modules;

    /// <summary>The continent service bindings.</summary>
    public class ContinentServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IContinentService>().To<ContinentService>().WhenInjectedInto<IContinentServiceCache>();
            this.Bind<IContinentService>().To<ContinentServiceCache>();
        }
    }
}