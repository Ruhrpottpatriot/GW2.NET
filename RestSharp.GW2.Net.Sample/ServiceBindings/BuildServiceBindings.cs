// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The build service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.Builds;

    using Ninject.Modules;

    /// <summary>The build service bindings.</summary>
    public class BuildServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IBuildService>().To<BuildService>();
        }
    }
}