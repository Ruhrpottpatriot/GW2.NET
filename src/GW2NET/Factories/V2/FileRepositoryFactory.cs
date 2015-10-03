// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating a file repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories.V2
{
    using System;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Files;
    using GW2NET.V2.Files;
    using GW2NET.V2.Files.Converters;
    using GW2NET.V2.Files.Json;

    /// <summary>Provides methods for creating a file repository.</summary>
    public class FileRepositoryFactory : RepositoryFactoryBase<IFileRepository>
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FileRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        public FileRepositoryFactory(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        public override IFileRepository ForDefaultCulture()
        {
            var assetConverter = new AssetConverter();
            var identifiersConverter = new CollectionResponseConverter<string, string>(new ConverterAdapter<string>());
            var responseConverter = new ResponseConverter<FileDTO, Asset>(assetConverter);
            var bulkResponseConverter = new DictionaryRangeResponseConverter<FileDTO, string, Asset>(assetConverter, value => value.Identifier);
            var pageResponseConverter = new CollectionPageResponseConverter<FileDTO, Asset>(assetConverter);
            return new FileRepository(this.serviceClient, identifiersConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
        }

        public override IFileRepository ForCulture(CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}
