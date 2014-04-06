// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The world service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.Worlds.Names;

    using Ninject.Modules;

    /// <summary>The world service bindings.</summary>
    public class WorldServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IWorldNameService>().To<WorldNameService>();
        }
    }
}