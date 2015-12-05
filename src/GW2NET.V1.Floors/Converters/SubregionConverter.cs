// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubregionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SubregionDTO" /> to objects of type <see cref="Subregion" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Floors.Converters
{
    using System;
    using System.Collections.Generic;
    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;
    using GW2NET.V1.Floors.Json;

    /// <summary>Converts objects of type <see cref="SubregionDTO"/> to objects of type <see cref="Subregion"/>.</summary>
    public sealed class SubregionConverter : IConverter<SubregionDTO, Subregion>
    {
        private readonly IConverter<ICollection<PointOfInterestDTO>, ICollection<PointOfInterest>> pointOfInterestCollectionConverter;

        private readonly IConverter<double[][], Rectangle> rectangleConverter;

        private readonly IConverter<ICollection<RenownTaskDTO>, ICollection<RenownTask>> renownTaskCollectionConverter;

        private readonly IConverter<ICollection<SectorDTO>, ICollection<Sector>> sectorCollectionConverter;

        private readonly IConverter<ICollection<SkillChallengeDTO>, ICollection<SkillChallenge>> skillChallengeCollectionConverter;

        /// <summary>Initializes a new instance of the <see cref="SubregionConverter"/> class.</summary>
        /// <param name="rectangleConverter">The converter for <see cref="Rectangle"/>.</param>
        /// <param name="pointOfInterestCollectionConverter">The converter for <see cref="ICollection{PointOfInterest}"/>.</param>
        /// <param name="renownTaskCollectionConverter">The converter for <see cref="ICollection{RenownTask}"/>.</param>
        /// <param name="skillChallengeCollectionConverter">The converter for <see cref="ICollection{SkillChallenge}"/>.</param>
        /// <param name="sectorCollectionConverter">The converter for <see cref="ICollection{Sector}"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="rectangleConverter"/> or <paramref name="pointOfInterestCollectionConverter"/> or <paramref name="renownTaskCollectionConverter"/> or <paramref name="sectorCollectionConverter"/> or <paramref name="skillChallengeCollectionConverter"/> is a null reference.</exception>
        public SubregionConverter(IConverter<double[][], Rectangle> rectangleConverter, IConverter<ICollection<PointOfInterestDTO>, ICollection<PointOfInterest>> pointOfInterestCollectionConverter, IConverter<ICollection<RenownTaskDTO>, ICollection<RenownTask>> renownTaskCollectionConverter, IConverter<ICollection<SkillChallengeDTO>, ICollection<SkillChallenge>> skillChallengeCollectionConverter, IConverter<ICollection<SectorDTO>, ICollection<Sector>> sectorCollectionConverter)
        {
            if (rectangleConverter == null)
            {
                throw new ArgumentNullException("rectangleConverter");
            }

            if (pointOfInterestCollectionConverter == null)
            {
                throw new ArgumentNullException("pointOfInterestCollectionConverter");
            }

            if (renownTaskCollectionConverter == null)
            {
                throw new ArgumentNullException("renownTaskCollectionConverter");
            }

            if (skillChallengeCollectionConverter == null)
            {
                throw new ArgumentNullException("skillChallengeCollectionConverter");
            }

            if (sectorCollectionConverter == null)
            {
                throw new ArgumentNullException("sectorCollectionConverter");
            }

            this.rectangleConverter = rectangleConverter;
            this.pointOfInterestCollectionConverter = pointOfInterestCollectionConverter;
            this.renownTaskCollectionConverter = renownTaskCollectionConverter;
            this.skillChallengeCollectionConverter = skillChallengeCollectionConverter;
            this.sectorCollectionConverter = sectorCollectionConverter;
        }

        /// <inheritdoc />
        public Subregion Convert(SubregionDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
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
                subRegion.MapRectangle = this.rectangleConverter.Convert(mapDimensions, state);
            }

            var continentDimensions = value.ContinentRectangle;
            if (continentDimensions != null && continentDimensions.Length == 2)
            {
                subRegion.ContinentRectangle = this.rectangleConverter.Convert(continentDimensions, state);
            }

            var pointsOfInterest = value.PointsOfInterest;
            if (pointsOfInterest != null)
            {
                subRegion.PointsOfInterest = this.pointOfInterestCollectionConverter.Convert(pointsOfInterest, state);
            }

            var renownTasks = value.Tasks;
            if (renownTasks == null)
            {
                subRegion.Tasks = new List<RenownTask>(0);
            }
            else
            {
                subRegion.Tasks = this.renownTaskCollectionConverter.Convert(renownTasks, state);
            }

            var skillChallenges = value.SkillChallenges;
            if (skillChallenges == null)
            {
                subRegion.SkillChallenges = new List<SkillChallenge>(0);
            }
            else
            {
                subRegion.SkillChallenges = this.skillChallengeCollectionConverter.Convert(skillChallenges, state);
            }

            var sectors = value.Sectors;
            if (sectors == null)
            {
                subRegion.Sectors = new List<Sector>(0);
            }
            else
            {
                subRegion.Sectors = this.sectorCollectionConverter.Convert(sectors, state);
            }

            // Return the map object
            return subRegion;
        }
    }
}