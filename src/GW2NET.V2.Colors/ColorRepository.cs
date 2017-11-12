// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ColorRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Colors
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Colors;
    using GW2NET.Common;
    using GW2NET.Common.Converters;

    /// <summary>Represents a repository that retrieves data from the /v2/colors interface.</summary>
    public class ColorRepository : IColorRepository
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> converterForIdentifiersResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ColorPaletteDataContract>, ColorPalette> converterForResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<ColorPaletteDataContract>>, IDictionaryRange<int, ColorPalette>> converterForBulkResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<ColorPaletteDataContract>>, ICollectionPage<ColorPalette>> converterForPageResponse;

        /// <summary>Initializes a new instance of the <see cref="ColorRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ColorRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterAdapter<ICollection<int>>(), new ColorPaletteConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ColorRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="identifierConverter">The identifier converter.</param>
        /// <param name="colorPaletteConverter">The color palette converter.</param>
        private ColorRepository(
            IServiceClient serviceClient
            , IConverter<ICollection<int>, ICollection<int>> identifierConverter
            , IConverter<ColorPaletteDataContract, ColorPalette> colorPaletteConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (identifierConverter == null)
            {
                throw new ArgumentNullException("identifierConverter", "Precondition: identifierConverter != null");
            }

            if (colorPaletteConverter == null)
            {
                throw new ArgumentNullException("colorPaletteConverter", "Precondition: colorPaletteConverter != null");
            }

            this.serviceClient = serviceClient;
            this.converterForIdentifiersResponse = new ConverterForResponse<ICollection<int>, ICollection<int>>(identifierConverter);
            this.converterForResponse = new ConverterForResponse<ColorPaletteDataContract, ColorPalette>(colorPaletteConverter);
            this.converterForBulkResponse = new ConverterForDictionaryRangeResponse<ColorPaletteDataContract, int, ColorPalette>(colorPaletteConverter, color => color.ColorId);
            this.converterForPageResponse = new ConverterForCollectionPageResponse<ColorPaletteDataContract, ColorPalette>(colorPaletteConverter);
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new ColorDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.converterForIdentifiersResponse.Convert(response) ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            IColorRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new ColorDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ConfigureAwait(false);
            var ids = this.converterForIdentifiersResponse.Convert(response);
            if (ids == null)
            {
                return new List<int>(0);
            }

            return ids;
        }

        /// <inheritdoc />
        ICollectionPage<ColorPalette> IPaginator<ColorPalette>.FindPage(int pageIndex)
        {
            IColorRepository self = this;
            var request = new ColorPalettePageRequest
            {
                Page = pageIndex,
                Culture = self.Culture
            };

            var response = this.serviceClient.Send<ICollection<ColorPaletteDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
        }

        /// <inheritdoc />
        ICollectionPage<ColorPalette> IPaginator<ColorPalette>.FindPage(int pageIndex, int pageSize)
        {
            IColorRepository self = this;
            var request = new ColorPalettePageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<ColorPaletteDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<ColorPalette>> IPaginator<ColorPalette>.FindPageAsync(int pageIndex)
        {
            IColorRepository self = this;
            return self.FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<ColorPalette>> IPaginator<ColorPalette>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            IColorRepository self = this;
            var request = new ColorPalettePageRequest
            {
                Page = pageIndex,
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<ColorPaletteDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<ColorPalette>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<ColorPalette>> IPaginator<ColorPalette>.FindPageAsync(int pageIndex, int pageSize)
        {
            IColorRepository self = this;
            return self.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<ColorPalette>> IPaginator<ColorPalette>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            IColorRepository self = this;
            var request = new ColorPalettePageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<ColorPaletteDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<ColorPalette>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        ColorPalette IRepository<int, ColorPalette>.Find(int identifier)
        {
            IColorRepository self = this;
            var request = new ColorPaletteDetailRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = self.Culture
            };

            var response = this.serviceClient.Send<ColorPaletteDataContract>(request);
            return this.converterForResponse.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, ColorPalette> IRepository<int, ColorPalette>.FindAll()
        {
            IColorRepository self = this;
            var request = new ColorPaletteBulkRequest { Culture = self.Culture };

            var response = this.serviceClient.Send<ICollection<ColorPaletteDataContract>>(request);
            return this.converterForBulkResponse.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, ColorPalette> IRepository<int, ColorPalette>.FindAll(ICollection<int> identifiers)
        {
            IColorRepository self = this;
            var request = new ColorPaletteBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = self.Culture
            };

            var response = this.serviceClient.Send<ICollection<ColorPaletteDataContract>>(request);
            return this.converterForBulkResponse.Convert(response);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ColorPalette>> IRepository<int, ColorPalette>.FindAllAsync()
        {
            IColorRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, ColorPalette>> IRepository<int, ColorPalette>.FindAllAsync(CancellationToken cancellationToken)
        {
            IColorRepository self = this;
            var request = new ColorPaletteBulkRequest { Culture = self.Culture };
            var response = await this.serviceClient.SendAsync<ICollection<ColorPaletteDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForBulkResponse.Convert(response);
            if (values == null)
            {
                return new DictionaryRange<int, ColorPalette>(0);
            }

            return values;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ColorPalette>> IRepository<int, ColorPalette>.FindAllAsync(ICollection<int> identifiers)
        {
            IColorRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, ColorPalette>> IRepository<int, ColorPalette>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            IColorRepository self = this;
            var request = new ColorPaletteBulkRequest
            {
                Culture = self.Culture,
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList()
            };

            var response = await this.serviceClient.SendAsync<ICollection<ColorPaletteDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForBulkResponse.Convert(response);
            if (values == null)
            {
                return new DictionaryRange<int, ColorPalette>(0);
            }

            return values;
        }

        /// <inheritdoc />
        Task<ColorPalette> IRepository<int, ColorPalette>.FindAsync(int identifier)
        {
            return ((IColorRepository)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ColorPalette> IRepository<int, ColorPalette>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            IColorRepository self = this;
            var request = new ColorPaletteDetailRequest
            {
                Culture = self.Culture,
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo)
            };

            var response = await this.serviceClient.SendAsync<ColorPaletteDataContract>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForResponse.Convert(response);
        }
    }
}