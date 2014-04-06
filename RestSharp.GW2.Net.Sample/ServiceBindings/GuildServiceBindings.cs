// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The guild service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.Guilds.Details;

    using Ninject.Modules;

    /// <summary>The guild service bindings.</summary>
    public class GuildServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IGuildDetailsService>().To<GuildDetailsService>();
        }
    }
}