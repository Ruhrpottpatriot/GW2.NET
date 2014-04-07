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

    using Ninject.Modules;

    /// <summary>The dynamic event service bindings.</summary>
    public class DynamicEventServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IDynamicEventService>().To<DynamicEventService>().WhenInjectedInto<IDynamicEventServiceCache>();
            this.Bind<IDynamicEventService>().To<DynamicEventServiceCache>();
            this.Bind<IDynamicEventNameService>().To<DynamicEventNameService>().WhenInjectedInto<IDynamicEventNameServiceCache>();
            this.Bind<IDynamicEventNameService>().To<DynamicEventNameServiceCache>();
            this.Bind<IDynamicEventDetailsService>().To<DynamicEventDetailsService>().WhenInjectedInto<IDynamicEventDetailsServiceCache>();
            this.Bind<IDynamicEventDetailsService>().To<DynamicEventDetailsServiceCache>();
        }
    }
}