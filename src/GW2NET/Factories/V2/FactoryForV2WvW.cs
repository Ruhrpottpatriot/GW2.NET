using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <summary>Initializes a new instance of the <see cref="FactoryForV1WvW"/> class. Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public FactoryForV2WvW(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets access to the matches data source.</summary>
        public IMatchRepository Matches
        {
            get
            {
                var matchupConverter = new MatchupConverter();
                var scoreboardConverter = new ScoreboardConverter();
                var competitiveMapConverterFactory = new CompetitiveMapConverterFactory();
                var teamColorConverter = new TeamColorConverter();
                var objectiveConverter = new ObjectiveConverter(teamColorConverter);
                var mapBonusConverterFactory = new MapBonusConverterFactory();
                var mapBonusConverter = new MapBonusConverter(mapBonusConverterFactory, teamColorConverter);
                var competitiveMapConverter = new CompetitiveMapConverter(competitiveMapConverterFactory, scoreboardConverter, objectiveConverter, mapBonusConverter);
                var matchConverter = new MatchConverter(scoreboardConverter, competitiveMapConverter);
                return new MatchRepository(this.ServiceClient, matchupConverter, matchConverter);
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
