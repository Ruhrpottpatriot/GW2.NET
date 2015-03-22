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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

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
        internal MapConverter(IConverter<double[][], Rectangle> rectangleConverter, IConverter<ICollection<PointOfInterestDataContract>, ICollection<PointOfInterest>> converterForPointOfInterestCollection, IConverter<ICollection<TaskDataContract>, ICollection<RenownTask>> taskCollectionConverter, IConverter<ICollection<SkillChallengeDataContract>, ICollection<SkillChallenge>> skillChallengeCollectionConverter, IConverter<ICollection<SectorDataContract>, ICollection<Sector>> sectorCollectionConverter)
        {
            Contract.Requires(rectangleConverter != null);
            Contract.Requires(converterForPointOfInterestCollection != null);
            Contract.Requires(taskCollectionConverter != null);
            Contract.Requires(skillChallengeCollectionConverter != null);
            Contract.Requires(sectorCollectionConverter != null);
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
            Contract.Assume(value != null);

            // Create a new map object
            var subRegion = new Subregion
                                {
                                    // ReSharper disable once PossibleNullReferenceException
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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when DataContracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.rectangleConverter != null);
            Contract.Invariant(this.converterForPointOfInterestCollection != null);
            Contract.Invariant(this.taskCollectionConverter != null);
            Contract.Invariant(this.skillChallengeCollectionConverter != null);
            Contract.Invariant(this.sectorCollectionConverter != null);
        }
    }
}