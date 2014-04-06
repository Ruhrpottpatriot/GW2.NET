// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The recipe service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.Recipes;

    using global::GW2DotNET.V1.Recipes.Details;

    using Ninject.Modules;

    /// <summary>The recipe service bindings.</summary>
    public class RecipeServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IRecipeService>().To<RecipeService>();
            this.Bind<IRecipeDetailsService>().To<RecipeDetailsService>();
        }
    }
}