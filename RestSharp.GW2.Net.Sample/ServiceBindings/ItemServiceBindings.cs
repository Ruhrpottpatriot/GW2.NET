// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The item service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.Items;

    using global::GW2DotNET.V1.Items.Details;

    using Ninject.Modules;

    /// <summary>The item service bindings.</summary>
    public class ItemServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IItemService>().To<ItemService>().WhenInjectedInto<IItemServiceCache>();
            this.Bind<IItemService>().To<ItemServiceCache>();
            this.Bind<IItemDetailsService>().To<ItemDetailsService>();
        }
    }
}