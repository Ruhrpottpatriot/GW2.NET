// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForV1WvW.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to WvW data sources.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories.V2
{
    using System;

    using GW2NET.Common;
    using GW2NET.V2.WorldVersusWorld.Matches;
    using GW2NET.V2.WorldVersusWorld.Matches.Converters;
    using GW2NET.WorldVersusWorld;

    /// <summary>Provides access to world versus world data sources.</summary>
    public class FactoryForV2WvW : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForV2WvW"/> class. Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public FactoryForV2WvW(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets access to the matches data source.</summary>
        public IMatchIdRepository Matches
        {
            get
            {
                var scoreboardConverter = new TeamStatConverter();
                var competitiveMapConverterFactory = new CompetitiveMapConverterFactory();
                var teamColorConverter = new TeamColorConverter();
                var objectiveConverter = new ObjectiveConverter(teamColorConverter);
                var mapBonusConverterFactory = new MapBonusConverterFactory();
                var mapBonusConverter = new MapBonusConverter(mapBonusConverterFactory, teamColorConverter);
                var competitiveMapConverter = new CompetitiveMapConverter(competitiveMapConverterFactory, scoreboardConverter, objectiveConverter, mapBonusConverter);
                var matchConverter = new MatchConverter(scoreboardConverter, competitiveMapConverter);
                return new MatchRepository(this.ServiceClient, matchConverter);
            }
        }

        public IMatchWorldRepository MatchesByWorld
        {
            get
            {
                return (IMatchWorldRepository)this.Matches;
            }
        }

        /// <summary>Gets access to the objective names data source.</summary>
        public ObjectiveNameRepositoryFactory Objectives
        {
            get
            {
                return new ObjectiveNameRepositoryFactory(this.ServiceClient);
            }
        }
    }
}