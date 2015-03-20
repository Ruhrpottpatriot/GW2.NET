// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRepositoryFactoryV2.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating a file repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Files
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Files;
    using GW2NET.V2.Worlds;

    /// <summary>Provides methods for creating a file repository.</summary>
    public class FileRepositoryFactoryV2 : RepositoryFactoryBase<IFileRepositoryV2>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FileRepositoryFactoryV2"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FileRepositoryFactoryV2(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IFileRepositoryV2 ForDefaultCulture()
        {
            Contract.Ensures(Contract.Result<IFileRepositoryV2>() != null);
            return new FileRepositoryV2(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IFileRepositoryV2 ForCulture(CultureInfo culture)
        {
            throw new NotSupportedException("Different cultures are not supported by this endpoint.");
        }
        
        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when COdeCOntracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}
