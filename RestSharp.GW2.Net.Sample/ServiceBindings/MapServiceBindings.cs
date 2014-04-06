// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The map service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.Maps;

    using global::GW2DotNET.V1.Maps.Floors;

    using global::GW2DotNET.V1.Maps.Names;

    using Ninject.Modules;

    /// <summary>The map service bindings.</summary>
    public class MapServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IMapService>().To<MapService>();
            this.Bind<IMapNameService>().To<MapNameService>();
            this.Bind<IMapFloorService>().To<MapFloorService>();
        }
    }
}