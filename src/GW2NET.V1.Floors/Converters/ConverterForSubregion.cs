// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSubregion.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SubregionDataContract" /> to objects of type <see cref="Subregion" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Common;
using GW2NET.Common.Converters;
using GW2NET.Common.Drawing;
using GW2NET.Maps;
using GW2NET.V1.Floors.Json;

namespace GW2NET.V1.Floors.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="SubregionDataContract"/> to objects of type <see cref="Subregion"/>.</summary>
    internal sealed class ConverterForSubregion : IConverter<SubregionDataContract, Subregion>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<PointOfInterestDataContract>, ICollection<PointOfInterest>> converterForPointOfInterestCollection;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[][], Rectangle> converterForRectangle;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<RenownTaskDataContract>, ICollection<RenownTask>> converterForRenownTaskCollection;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<SectorDataContract>, ICollection<Sector>> converterForSectorCollection;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<SkillChallengeDataContract>, ICollection<SkillChallenge>> converterForSkillChallengeCollection;

        /// <summary>Initializes a new instance of the <see cref="ConverterForSubregion"/> class.</summary>
        public ConverterForSubregion()
            : this(new ConverterForRectangle(), new ConverterForCollection<PointOfInterestDataContract, PointOfInterest>(new ConverterForPointOfInterest()), new ConverterForCollection<RenownTaskDataContract, RenownTask>(new ConverterForRenownTask()), new ConverterForCollection<SkillChallengeDataContract, SkillChallenge>(new ConverterForSkillChallenge()), new ConverterForCollection<SectorDataContract, Sector>(new ConverterForSector()))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForSubregion"/> class.</summary>
        /// <param name="converterForRectangle">The converter for <see cref="Rectangle"/>.</param>
        /// <param name="converterForPointOfInterestCollection">The converter for <see cref="ICollection{PointOfInterest}"/>.</param>
        /// <param name="converterForRenownTaskCollection">The converter for <see cref="ICollection{RenownTask}"/>.</param>
        /// <param name="converterForSkillChallengeCollection">The converter for <see cref="ICollection{SkillChallenge}"/>.</param>
        /// <param name="converterForSectorCollection">The converter for <see cref="ICollection{Sector}"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForRectangle"/> or <paramref name="converterForPointOfInterestCollection"/> or <paramref name="converterForRenownTaskCollection"/> or <paramref name="converterForSectorCollection"/> or <paramref name="converterForSkillChallengeCollection"/> is a null reference.</exception>
        internal ConverterForSubregion(IConverter<double[][], Rectangle> converterForRectangle, IConverter<ICollection<PointOfInterestDataContract>, ICollection<PointOfInterest>> converterForPointOfInterestCollection, IConverter<ICollection<RenownTaskDataContract>, ICollection<RenownTask>> converterForRenownTaskCollection, IConverter<ICollection<SkillChallengeDataContract>, ICollection<SkillChallenge>> converterForSkillChallengeCollection, IConverter<ICollection<SectorDataContract>, ICollection<Sector>> converterForSectorCollection)
        {
            if (converterForRectangle == null)
            {
                throw new ArgumentNullException("converterForRectangle", "Precondition: converterForRectangle != null");
            }

            if (converterForPointOfInterestCollection == null)
            {
                throw new ArgumentNullException("converterForPointOfInterestCollection", "Precondition: converterForPointOfInterestCollection != null");
            }

            if (converterForRenownTaskCollection == null)
            {
                throw new ArgumentNullException("converterForRenownTaskCollection", "Precondition: converterForRenownTaskCollection != null");
            }

            if (converterForSkillChallengeCollection == null)
            {
                throw new ArgumentNullException("converterForSkillChallengeCollection", "Precondition: converterForSkillChallengeCollection != null");
            }

            if (converterForSectorCollection == null)
            {
                throw new ArgumentNullException("converterForSectorCollection", "Precondition: converterForSectorCollection != null");
            }

            this.converterForRectangle = converterForRectangle;
            this.converterForPointOfInterestCollection = converterForPointOfInterestCollection;
            this.converterForRenownTaskCollection = converterForRenownTaskCollection;
            this.converterForSkillChallengeCollection = converterForSkillChallengeCollection;
            this.converterForSectorCollection = converterForSectorCollection;
        }

        /// <inheritdoc />
        public Subregion Convert(SubregionDataContract value)
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
                subRegion.MapRectangle = this.converterForRectangle.Convert(mapDimensions);
            }

            var continentDimensions = value.ContinentRectangle;
            if (continentDimensions != null && continentDimensions.Length == 2)
            {
                subRegion.ContinentRectangle = this.converterForRectangle.Convert(continentDimensions);
            }

            var pointsOfInterest = value.PointsOfInterest;
            if (pointsOfInterest == null)
            {
                subRegion.PointsOfInterest = new List<PointOfInterest>(0);
            }
            else
            {
                subRegion.PointsOfInterest = this.converterForPointOfInterestCollection.Convert(pointsOfInterest);
            }

            var renownTasks = value.Tasks;
            if (renownTasks == null)
            {
                subRegion.Tasks = new List<RenownTask>(0);
            }
            else
            {
                subRegion.Tasks = this.converterForRenownTaskCollection.Convert(renownTasks);
            }

            var skillChallenges = value.SkillChallenges;
            if (skillChallenges == null)
            {
                subRegion.SkillChallenges = new List<SkillChallenge>(0);
            }
            else
            {
                subRegion.SkillChallenges = this.converterForSkillChallengeCollection.Convert(skillChallenges);
            }

            var sectors = value.Sectors;
            if (sectors == null)
            {
                subRegion.Sectors = new List<Sector>(0);
            }
            else
            {
                subRegion.Sectors = this.converterForSectorCollection.Convert(sectors);
            }

            // Return the map object
            return subRegion;
        }
    }
}
