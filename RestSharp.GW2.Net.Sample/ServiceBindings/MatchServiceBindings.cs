// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The match service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.WorldVersusWorld.Matches;

    using global::GW2DotNET.V1.WorldVersusWorld.Matches.Details;

    using global::GW2DotNET.V1.WorldVersusWorld.Objectives.Names;

    using Ninject.Modules;

    /// <summary>The match service bindings.</summary>
    public class MatchServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IMatchService>().To<MatchService>();
            this.Bind<IMatchDetailsService>().To<MatchDetailsService>();
            this.Bind<IObjectiveNameService>().To<ObjectiveNameService>();
        }
    }
}