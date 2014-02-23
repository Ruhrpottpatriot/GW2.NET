// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WvW.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WvW type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.WorldVersusWorldInformation;
using GW2DotNET.V1.Core.WorldVersusWorldInformation.Catalogs;
using GW2DotNET.V1.Core.WorldVersusWorldInformation.Details;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    public class WorldVersusWorldTests
    {
        private IApiClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ApiClient.Create();
        }

        [Test]
        public void GetMatches()
        {
            var request = new MatchesRequest();
            var response = request.GetResponse(this.client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var result = response.Deserialize();

            Assert.IsNotNull(result);
            Assert.IsEmpty(result.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MatchesResult).FullName);

            var matches = result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsNotEmpty(matches);
            Assert.IsEmpty(matches.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Matches).FullName);

            foreach (var match in matches)
            {
                Assert.IsEmpty(match.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Match).FullName);
            }

            Trace.WriteLine(string.Format("Number of matches: {0}", matches.Count));
        }

        [Test]
        public void GetMatchDetails()
        {
            var request = new MatchDetailsRequest("1-1");
            var response = request.GetResponse(this.client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var result = response.Deserialize();

            Assert.IsNotNull(result);
            Assert.IsEmpty(result.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MatchesResult).FullName);

            Scoreboard scoreboard = result.Scores;

            Assert.IsNotNull(scoreboard);
            Assert.IsEmpty(scoreboard.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Scoreboard).FullName);

            foreach (var map in result.Maps)
            {
                Assert.IsNotNull(map);
                Assert.IsEmpty(map.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Map).FullName);

                Assert.IsNotNull(map.Bonuses);
                foreach (var bonus in map.Bonuses)
                {
                    Assert.IsNotNull(bonus);
                    Assert.IsEmpty(bonus.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Bonus).FullName);
                }

                Assert.IsNotNull(map.Objectives);
                foreach (var objective in map.Objectives)
                {
                    Assert.IsNotNull(objective);
                    Assert.IsEmpty(objective.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ObjectiveName).FullName);
                }

                Assert.IsNotNull(map.Scores);
                Assert.IsEmpty(map.Scores.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Scoreboard).FullName);
            }
        }

        [Test]
        public void GetObjectiveNames()
        {
            var request = new ObjectiveNamesRequest();
            var response = request.GetResponse(this.client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var objectiveNames = response.Deserialize();

            Assert.IsNotNull(objectiveNames);
            Assert.IsNotEmpty(objectiveNames);
            Assert.IsEmpty(objectiveNames.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ObjectiveNames).FullName);

            foreach (var objectiveName in objectiveNames)
            {
                Assert.IsNotNull(objectiveName);
                Assert.IsEmpty(objectiveName.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ObjectiveName).FullName);
            }

            Trace.WriteLine(string.Format("Number of objectives: {0}", objectiveNames.Count));
        }
    }



}
