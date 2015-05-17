// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type  to objects of type .
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;

    /// <summary>Converts objects of type <see cref="MapDataContract"/> to objects of type <see cref="Subregion"/>.</summary>
    internal sealed class MapConverter : IConverter<MapDataContract, Subregion>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<PointOfInterestDataContract>, ICollection<PointOfInterest>> converterForPointOfInterestCollection;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[][], Rectangle> rectangleConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<TaskDataContract>, ICollection<RenownTask>> taskCollectionConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<SectorDataContract>, ICollection<Sector>> sectorCollectionConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<SkillChallengeDataContract>, ICollection<SkillChallenge>> skillChallengeCollectionConverter;

        /// <summary>Initializes a new instance of the <see cref="MapConverter"/> class.</summary>
        public MapConverter()
            : this(new RectangleConverter(), new ConverterForCollection<PointOfInterestDataContract, PointOfInterest>(new PointOfInterestConverter()), new ConverterForCollection<TaskDataContract, RenownTask>(new TaskConverter()), new ConverterForCollection<SkillChallengeDataContract, SkillChallenge>(new SkillChallengeConverter()), new ConverterForCollection<SectorDataContract, Sector>(new SectorConverter()))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapConverter"/> class.</summary>
        /// <param name="rectangleConverter">The converter for <see cref="Rectangle"/>.</param>
        /// <param name="converterForPointOfInterestCollection">The converter for <see cref="ICollection{PointOfInterest}"/>.</param>
        /// <param name="taskCollectionConverter">The converter for <see cref="ICollection{RenownTask}"/>.</param>
        /// <param name="skillChallengeCollectionConverter">The converter for <see cref="ICollection{SkillChallenge}"/>.</param>
        /// <param name="sectorCollectionConverter">The converter for <see cref="ICollection{Sector}"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="rectangleConverter"/> or <paramref name="converterForPointOfInterestCollection"/> or <paramref name="taskCollectionConverter"/> or <paramref name="skillChallengeCollectionConverter"/> or <paramref name="sectorCollectionConverter"/> is a null reference.</exception>
        internal MapConverter(
            IConverter<double[][], Rectangle> rectangleConverter
            , IConverter<ICollection<PointOfInterestDataContract>, ICollection<PointOfInterest>> converterForPointOfInterestCollection
            , IConverter<ICollection<TaskDataContract>, ICollection<RenownTask>> taskCollectionConverter
            , IConverter<ICollection<SkillChallengeDataContract>, ICollection<SkillChallenge>> skillChallengeCollectionConverter
            , IConverter<ICollection<SectorDataContract>, ICollection<Sector>> sectorCollectionConverter)
        {
            if (rectangleConverter == null)
            {
                throw new ArgumentNullException("rectangleConverter", "Precondition: rectangleConverter != null");
            }

            if (converterForPointOfInterestCollection == null)
            {
                throw new ArgumentNullException("converterForPointOfInterestCollection", "Precondition: converterForPointOfInterestCollection != null");
            }

            if (taskCollectionConverter == null)
            {
                throw new ArgumentNullException("taskCollectionConverter", "Precondition: taskCollectionConverter != null");
            }

            if (skillChallengeCollectionConverter == null)
            {
                throw new ArgumentNullException("skillChallengeCollectionConverter", "Precondition: skillChallengeCollectionConverter != null");
            }

            if (sectorCollectionConverter == null)
            {
                throw new ArgumentNullException("sectorCollectionConverter", "Precondition: sectorCollectionConverter != null");
            }

            this.rectangleConverter = rectangleConverter;
            this.converterForPointOfInterestCollection = converterForPointOfInterestCollection;
            this.taskCollectionConverter = taskCollectionConverter;
            this.skillChallengeCollectionConverter = skillChallengeCollectionConverter;
            this.sectorCollectionConverter = sectorCollectionConverter;
        }

        /// <summary>Converts the given object of type <see cref="MapDataContract"/> to an object of type <see cref="Subregion"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Subregion Convert(MapDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            // Create a new map object
            var subRegion = new Subregion
                                {
                                    Name = value.Name,
                                    MinimumLevel = value.MinimumLevel,
                                    MaximumLevel = value.MaximumLevel,
                                    DefaultFloor = value.DefaultFloor
                                };

            var mapDimensions = value.MapRectangle;
            if (mapDimensions != null && mapDimensions.Length == 2)
            {
                subRegion.MapRectangle = this.rectangleConverter.Convert(mapDimensions);
            }

            var continentDimensions = value.ContinentRectangle;
            if (continentDimensions != null && continentDimensions.Length == 2)
            {
                subRegion.ContinentRectangle = this.rectangleConverter.Convert(continentDimensions);
            }

            var pointsOfInterest = value.PointsOfInterest;
            if (pointsOfInterest != null)
            {
                subRegion.PointsOfInterest = this.converterForPointOfInterestCollection.Convert(pointsOfInterest);
            }

            var renownTasks = value.Tasks;
            if (renownTasks != null)
            {
                subRegion.Tasks = this.taskCollectionConverter.Convert(renownTasks);
            }

            var skillChallenges = value.SkillChallenges;
            if (skillChallenges != null)
            {
                subRegion.SkillChallenges = this.skillChallengeCollectionConverter.Convert(skillChallenges);
            }

            var sectors = value.Sectors;
            if (sectors != null)
            {
                subRegion.Sectors = this.sectorCollectionConverter.Convert(sectors);
            }

            // Return the map object
            return subRegion;
        }
    }
}