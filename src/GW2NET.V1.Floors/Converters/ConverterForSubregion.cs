// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSubregion.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SubregionDataContract" /> to objects of type <see cref="Subregion" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Common.Converters;
using GW2NET.Common.Drawing;
using GW2NET.Maps;
using GW2NET.V1.Floors.Json;

namespace GW2NET.V1.Floors.Converters
{
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
        internal ConverterForSubregion(IConverter<double[][], Rectangle> converterForRectangle, IConverter<ICollection<PointOfInterestDataContract>, ICollection<PointOfInterest>> converterForPointOfInterestCollection, IConverter<ICollection<RenownTaskDataContract>, ICollection<RenownTask>> converterForRenownTaskCollection, IConverter<ICollection<SkillChallengeDataContract>, ICollection<SkillChallenge>> converterForSkillChallengeCollection, IConverter<ICollection<SectorDataContract>, ICollection<Sector>> converterForSectorCollection)
        {
            Contract.Requires(converterForRectangle != null);
            Contract.Requires(converterForPointOfInterestCollection != null);
            Contract.Requires(converterForRenownTaskCollection != null);
            Contract.Requires(converterForSkillChallengeCollection != null);
            Contract.Requires(converterForSectorCollection != null);
            this.converterForRectangle = converterForRectangle;
            this.converterForPointOfInterestCollection = converterForPointOfInterestCollection;
            this.converterForRenownTaskCollection = converterForRenownTaskCollection;
            this.converterForSkillChallengeCollection = converterForSkillChallengeCollection;
            this.converterForSectorCollection = converterForSectorCollection;
        }

        /// <summary>Converts the given object of type <see cref="SubregionDataContract"/> to an object of type <see cref="Subregion"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Subregion Convert(SubregionDataContract value)
        {
            Contract.Assume(value != null);

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
            if (pointsOfInterest != null)
            {
                subRegion.PointsOfInterest = this.converterForPointOfInterestCollection.Convert(pointsOfInterest);
            }

            var renownTasks = value.Tasks;
            if (renownTasks != null)
            {
                subRegion.Tasks = this.converterForRenownTaskCollection.Convert(renownTasks);
            }

            var skillChallenges = value.SkillChallenges;
            if (skillChallenges != null)
            {
                subRegion.SkillChallenges = this.converterForSkillChallengeCollection.Convert(skillChallenges);
            }

            var sectors = value.Sectors;
            if (sectors != null)
            {
                subRegion.Sectors = this.converterForSectorCollection.Convert(sectors);
            }

            // Return the map object
            return subRegion;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForRectangle != null);
            Contract.Invariant(this.converterForPointOfInterestCollection != null);
            Contract.Invariant(this.converterForRenownTaskCollection != null);
            Contract.Invariant(this.converterForSkillChallengeCollection != null);
            Contract.Invariant(this.converterForSectorCollection != null);
        }
    }
}