// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClientBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using System;

    using global::GW2DotNET.V1.Common;

    using global::GW2DotNET.V1.Rendering;

    using Ninject;
    using Ninject.Modules;

    /// <summary>The service bindings.</summary>
    public class ServiceClientBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<Uri>().ToConstant(new Uri(Services.DataServiceUrl)).Named("DataServiceUrl");
            this.Bind<Uri>().ToConstant(new Uri(Services.RenderServiceUrl)).Named("RenderServiceUrl");

            this.Bind<IServiceClient>()
                .To<global::RestSharp.GW2DotNET.ServiceClient>()
                .WhenInjectedInto<IRenderService>()
                .WithConstructorArgument("baseUrl", context => context.Kernel.Get<Uri>("RenderServiceUrl"));

            this.Bind<IServiceClient>()
                .To<global::RestSharp.GW2DotNET.ServiceClient>()
                .WithConstructorArgument("baseUrl", context => context.Kernel.Get<Uri>("DataServiceUrl"));
        }
    }
}