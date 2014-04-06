// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileServiceBindings.cs" company="">
//   
// </copyright>
// <summary>
//   The file service bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Sample.ServiceBindings
{
    using global::GW2DotNET.V1.Files;

    using Ninject.Modules;

    /// <summary>The file service bindings.</summary>
    public class FileServiceBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IFileService>().To<FileService>();
        }
    }
}