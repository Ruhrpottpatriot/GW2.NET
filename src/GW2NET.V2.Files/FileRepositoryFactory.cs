// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating a file repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Files
{
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Files;

    /// <summary>Provides methods for creating a file repository.</summary>
    public class FileRepositoryFactory : RepositoryFactoryBase<IFileRepository>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FileRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FileRepositoryFactory(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IFileRepository ForDefaultCulture()
        {
            return new FileRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IFileRepository ForCulture(CultureInfo culture)
        {
            return new FileRepository(this.serviceClient);
        }
    }
}
