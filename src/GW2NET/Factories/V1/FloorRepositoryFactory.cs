// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories.V1
{
    using System;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Maps;
    using GW2NET.V1.Floors;
    using GW2NET.V1.Floors.Converters;
    using GW2NET.V1.Floors.Json;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class FloorRepositoryFactory
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FloorRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public FloorRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository.</returns>
        public IFloorRepository this[int continentId]
        {
            get
            {
                return this.ForDefaultCulture(continentId);
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <param name="language">The two-letter language code.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="language"/> is a null reference.</exception>
        /// <returns>A repository.</returns>
        public IFloorRepository this[int continentId, string language]
        {
            get
            {
                if (language == null)
                {
                    throw new ArgumentNullException("language");
                }

                return this.ForCulture(continentId, new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <param name="culture">The culture.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="culture"/> is a null reference.</exception>
        /// <returns>A repository.</returns>
        public IFloorRepository this[int continentId, CultureInfo culture]
        {
            get
            {
                if (culture == null)
                {
                    throw new ArgumentNullException("culture");
                }

                return this.ForCulture(continentId, culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository.</returns>
        public IFloorRepository ForDefaultCulture(int continentId)
        {
            var pointOfInterestConverterFactory = new PointOfInterestConverterFactory();
            var vector2DConverter = new Vector2DConverter();
            var rectangleConverter = new RectangleConverter(vector2DConverter);
            var pointOfInterestConverter = new PointOfInterestConverter(pointOfInterestConverterFactory, vector2DConverter);
            var pointOfInterestCollectionConverter = new CollectionConverter<PointOfInterestDTO, PointOfInterest>(pointOfInterestConverter);
            var renownTaskConverter = new RenownTaskConverter(vector2DConverter);
            var renownTaskCollectionConverter = new CollectionConverter<RenownTaskDTO, RenownTask>(renownTaskConverter);
            var skillChallengeConverter = new SkillChallengeConverter(vector2DConverter);
            var skillChallengeCollectionConverter = new CollectionConverter<SkillChallengeDTO, SkillChallenge>(skillChallengeConverter);
            var outputConverter = new SectorConverter(vector2DConverter);
            var sectorCollectionConverter = new CollectionConverter<SectorDTO, Sector>(outputConverter);
            var subregionConverter = new SubregionConverter(rectangleConverter, pointOfInterestCollectionConverter, renownTaskCollectionConverter, skillChallengeCollectionConverter, sectorCollectionConverter);
            var keyValuePairConverter = new SubregionKeyValuePairConverter(subregionConverter);
            var subregionKeyValuePairConverter = new DictionaryConverter<string, SubregionDTO, int, Subregion>(keyValuePairConverter);
            var regionConverter = new RegionConverter(vector2DConverter, subregionKeyValuePairConverter);
            var regionKeyValuePairConverter = new RegionKeyValuePairConverter(regionConverter);
            var regionCollectionConverter = new DictionaryConverter<string, RegionDTO, int, Region>(regionKeyValuePairConverter);
            var size2DConverter = new Size2DConverter();
            var floorConverter = new FloorConverter(size2DConverter, rectangleConverter, regionCollectionConverter);
            return new FloorRepository(continentId, this.serviceClient, floorConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <param name="culture">The culture.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="culture"/> is a null reference.</exception>
        /// <returns>A repository.</returns>
        public IFloorRepository ForCulture(int continentId, CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException("culture");
            }

            IFloorRepository repository = this.ForDefaultCulture(continentId);
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository.</returns>
        public IFloorRepository ForCurrentCulture(int continentId)
        {
            return this.ForCulture(continentId, CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository.</returns>
        public IFloorRepository ForCurrentUICulture(int continentId)
        {
            return this.ForCulture(continentId, CultureInfo.CurrentUICulture);
        }
    }
}