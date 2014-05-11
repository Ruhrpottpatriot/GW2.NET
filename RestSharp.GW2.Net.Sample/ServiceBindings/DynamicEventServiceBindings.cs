// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The dynamic event service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.DynamicEvents;

    using global::GW2DotNET.V1.DynamicEvents.Details;

    using global::GW2DotNET.V1.DynamicEvents.Names;
    using global::GW2DotNET.V1.DynamicEvents.Rotations;

    using Ninject.Modules;

    /// <summary>The dynamic event service bindings.</summary>
    public class DynamicEventServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IDynamicEventService>().To<DynamicEventService>();
            this.Bind<IDynamicEventNameService>().To<DynamicEventNameService>();
            this.Bind<IDynamicEventRotationService>().To<DynamicEventRotationService>();
            this.Bind<IDynamicEventDetailsService>().To<DynamicEventDetailsService>();
        }
    }
}