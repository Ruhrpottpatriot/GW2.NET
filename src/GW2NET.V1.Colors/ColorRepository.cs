// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/colors.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.V1.Colors.Converters;
using GW2NET.V1.Colors.Json;

namespace GW2NET.V1.Colors
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Colors;
    using GW2NET.Common;

    /// <summary>Represents a repository that retrieves data from the /v1/colors.json interface.</summary>
    public class ColorRepository : IColorRepository
    {
        private readonly IConverter<ColorCollectionDataContract, ICollection<ColorPalette>> converterForColorPaletteCollection;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ColorRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public ColorRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForColorPaletteCollection())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ColorRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForColorPaletteCollection">The converter for <see cref="ICollection{ColorPalette}"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="converterForColorPaletteCollection"/> is a null reference.</exception>
        internal ColorRepository(IServiceClient serviceClient, IConverter<ColorCollectionDataContract, ICollection<ColorPalette>> converterForColorPaletteCollection)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (converterForColorPaletteCollection == null)
            {
                throw new ArgumentNullException("converterForColorPaletteCollection", "Precondition: converterForColorPaletteCollection != null");
            }

            this.serviceClient = serviceClient;
            this.converterForColorPaletteCollection = converterForColorPaletteCollection;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ColorPalette IRepository<int, ColorPalette>.Find(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<int, ColorPalette> IRepository<int, ColorPalette>.FindAll()
        {
            IColorRepository self = this;
            var request = new ColorRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ColorCollectionDataContract>(request);
            if (response.Content == null || response.Content.Colors == null)
            {
                return new DictionaryRange<int, ColorPalette>(0);
            }

            var values = this.converterForColorPaletteCollection.Convert(response.Content);
            var colorPalettes = new DictionaryRange<int, ColorPalette>(values.Count)
            {
                SubtotalCount = values.Count,
                TotalCount = values.Count
            };

            foreach (var colorPalette in values)
            {
                colorPalette.Culture = request.Culture;
                colorPalettes.Add(colorPalette.ColorId, colorPalette);
            }

            return colorPalettes;
        }

        /// <inheritdoc />
        IDictionaryRange<int, ColorPalette> IRepository<int, ColorPalette>.FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ColorPalette>> IRepository<int, ColorPalette>.FindAllAsync()
        {
            return ((IColorRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ColorPalette>> IRepository<int, ColorPalette>.FindAllAsync(CancellationToken cancellationToken)
        {
            IColorRepository self = this;
            var request = new ColorRequest
            {
                Culture = self.Culture
            };
            return this.serviceClient.SendAsync<ColorCollectionDataContract>(request, cancellationToken).ContinueWith<IDictionaryRange<int, ColorPalette>>(
                task =>
                {
                    var response = task.Result;
                    if (response.Content == null || response.Content.Colors == null)
                    {
                        return new DictionaryRange<int, ColorPalette>(0);
                    }

                    var values = this.converterForColorPaletteCollection.Convert(response.Content);
                    var colorPalettes = new DictionaryRange<int, ColorPalette>(values.Count)
                    {
                        SubtotalCount = values.Count,
                        TotalCount = values.Count
                    };

                    foreach (var colorPalette in values)
                    {
                        colorPalette.Culture = request.Culture;
                        colorPalettes.Add(colorPalette.ColorId, colorPalette);
                    }

                    return colorPalettes;
                },
            cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ColorPalette>> IRepository<int, ColorPalette>.FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ColorPalette>> IRepository<int, ColorPalette>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ColorPalette> IRepository<int, ColorPalette>.FindAsync(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ColorPalette> IRepository<int, ColorPalette>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<ColorPalette> IPaginator<ColorPalette>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<ColorPalette> IPaginator<ColorPalette>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<ColorPalette>> IPaginator<ColorPalette>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<ColorPalette>> IPaginator<ColorPalette>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<ColorPalette>> IPaginator<ColorPalette>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<ColorPalette>> IPaginator<ColorPalette>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}