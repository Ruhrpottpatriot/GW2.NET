// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/colors.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Colors
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Colors;
    using GW2NET.V1.Colors.Json;
    using GW2NET.V1.Colors.Json.Converters;

    /// <summary>Represents a repository that retrieves data from the /v1/colors.json interface.</summary>
    public class ColorRepository : IRepository<int, ColorPalette>, ILocalizable
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ColorCollectionDataContract, ICollection<ColorPalette>> converterForColorPaletteCollection;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ColorRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ColorRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForColorPaletteCollection())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ColorRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForColorPaletteCollection">The converter for <see cref="ICollection{ColorPalette}"/>.</param>
        internal ColorRepository(IServiceClient serviceClient, IConverter<ColorCollectionDataContract, ICollection<ColorPalette>> converterForColorPaletteCollection)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForColorPaletteCollection != null);
            Contract.Ensures(this.serviceClient != null);
            Contract.Ensures(this.converterForColorPaletteCollection != null);
            this.serviceClient = serviceClient;
            this.converterForColorPaletteCollection = converterForColorPaletteCollection;
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public ICollection<int> Discover()
        {
            throw new NotSupportedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="ColorPalette"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="ColorPalette"/> with the specified identifier.</returns>
        public ColorPalette Find(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="ColorPalette"/>.</summary>
        /// <returns>A collection of every <see cref="ColorPalette"/>.</returns>
        public IDictionaryRange<int, ColorPalette> FindAll()
        {
            var locale = this.Culture;
            var request = new ColorRequest { Culture = locale };
            var response = this.serviceClient.Send<ColorCollectionDataContract>(request);
            if (response.Content == null || response.Content.Colors == null)
            {
                return new DictionaryRange<int, ColorPalette>(0);
            }

            var colorPalettes = new DictionaryRange<int, ColorPalette>(response.Content.Colors.Count) { SubtotalCount = response.Content.Colors.Count, TotalCount = response.Content.Colors.Count };

            foreach (var colorPalette in this.converterForColorPaletteCollection.Convert(response.Content))
            {
                colorPalette.Locale = locale;
                colorPalettes.Add(colorPalette.ColorId, colorPalette);
            }

            return colorPalettes;
        }

        /// <summary>Finds every <see cref="ColorPalette"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="ColorPalette"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<int, ColorPalette> FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="ColorPalette"/>.</summary>
        /// <returns>A collection of every <see cref="ColorPalette"/>.</returns>
        public Task<IDictionaryRange<int, ColorPalette>> FindAllAsync()
        {
            return this.FindAllAsync(CancellationToken.None);
        }

        /// <summary>Finds every <see cref="ColorPalette"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="ColorPalette"/></returns>
        public Task<IDictionaryRange<int, ColorPalette>> FindAllAsync(CancellationToken cancellationToken)
        {
            var locale = this.Culture;
            var request = new ColorRequest { Culture = locale };
            return this.serviceClient.SendAsync<ColorCollectionDataContract>(request, cancellationToken)
                .ContinueWith<IDictionaryRange<int, ColorPalette>>(task =>
                {
                    var response = task.Result;
                    if (response.Content == null || response.Content.Colors == null)
                    {
                        return new DictionaryRange<int, ColorPalette>(0);
                    }

                    var colorPalettes = new DictionaryRange<int, ColorPalette>(response.Content.Colors.Count) { SubtotalCount = response.Content.Colors.Count, TotalCount = response.Content.Colors.Count };

                    foreach (var colorPalette in this.converterForColorPaletteCollection.Convert(response.Content))
                    {
                        colorPalette.Locale = locale;
                        colorPalettes.Add(colorPalette.ColorId, colorPalette);
                    }

                    return colorPalettes;
                }, cancellationToken);
        }

        /// <summary>Finds every <see cref="ColorPalette"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="ColorPalette"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, ColorPalette>> FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="ColorPalette"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="ColorPalette"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, ColorPalette>> FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="ColorPalette"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="ColorPalette"/> with the specified identifier.</returns>
        public Task<ColorPalette> FindAsync(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="ColorPalette"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="ColorPalette"/> with the specified identifier.</returns>
        public Task<ColorPalette> FindAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<ColorPalette> FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page number and maximum size.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<ColorPalette> FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<ColorPalette>> FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<ColorPalette>> FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<ColorPalette>> FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<ColorPalette>> FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}