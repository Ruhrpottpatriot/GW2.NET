// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WvW.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WvW type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.WvW.MatchDetails;
using GW2DotNET.V1.Core.WvW.MatchDetails.Models;
using GW2DotNET.V1.Core.WvW.Matches;
using GW2DotNET.V1.Core.WvW.Matches.Models;
using GW2DotNET.V1.Core.WvW.ObjectiveNames;

using NUnit.Core;
using NUnit.Framework;

using Objective = GW2DotNET.V1.Core.WvW.ObjectiveNames.Models.Objective;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    public class MatchListTests
    {
        private IApiClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ApiClient.Create(new Version(1, 0));
        }

        [Test]
        public void GetMatches()
        {
            MatchesRequest request = new MatchesRequest();

            MatchesResponse response = request.GetResponse(this.client).DeserializeResponse();

            List<Match> matches = response.Matches.ToList();

            Assert.IsNotNull(matches);
            Assert.IsNotEmpty(matches);

            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MatchesResponse).FullName);

            foreach (var match in matches)
            {
                Assert.IsEmpty(match.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Match).FullName);
            }

            Trace.WriteLine(string.Format("Number of matches: {0}", matches.Count));
        }

        [Test]
        public async void GetMatchesAsync()
        {
            MatchesRequest request = new MatchesRequest();

            MatchesResponse response = (await request.GetResponseAsync(this.client)).DeserializeResponse();

            List<Match> matches = response.Matches.ToList();

            Assert.IsNotNull(matches);
            Assert.IsNotEmpty(matches);

            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MatchesResponse).FullName);

            foreach (var match in matches)
            {
                Assert.IsEmpty(match.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Match).FullName);
            }

            Trace.WriteLine(string.Format("Number of matches: {0}", matches.Count));
        }
    }

    public class MatchDetailTests
    {
        private IApiClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ApiClient.Create(new Version(1, 0));
        }


        [Test]
        public void GetMatchDetails()
        {
            MatchDetailsRequest request = new MatchDetailsRequest("1-1");

            MatchDetailsResponse response = request.GetResponse(this.client).DeserializeResponse();
            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MatchDetailsResponse).FullName);

            Scoreboard scoreboard = response.Scores;
            Assert.IsNotNull(scoreboard);
            Assert.IsEmpty(scoreboard.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Scoreboard).FullName);

            foreach (var map in response.Maps)
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
                    Assert.IsEmpty(objective.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Objective).FullName);
                }

                Assert.IsNotNull(map.Scores);
                Assert.IsEmpty(map.Scores.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Scoreboard).FullName);
            }
        }

        [Test]
        public async void GetMatchDetailsAsync()
        {
            MatchDetailsRequest request = new MatchDetailsRequest("1-1");

            MatchDetailsResponse response = (await request.GetResponseAsync(this.client)).DeserializeResponse();
            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MatchDetailsResponse).FullName);

            Scoreboard scoreboard = response.Scores;
            Assert.IsNotNull(scoreboard);
            Assert.IsEmpty(scoreboard.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Scoreboard).FullName);

            foreach (var map in response.Maps)
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
                    Assert.IsEmpty(objective.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Objective).FullName);
                }

                Assert.IsNotNull(map.Scores);
                Assert.IsEmpty(map.Scores.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Scoreboard).FullName);
            }
        }
    }

    public class ObjectiveNamesTest
    {
        private IApiClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ApiClient.Create(new Version(1, 0));
        }

        [Test]
        public void GetObjectiveNames()
        {
            ObjectiveNamesRequest request = new ObjectiveNamesRequest();

            ObjectiveNamesResponse response = request.GetResponse(this.client).DeserializeResponse();
            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ObjectiveNamesResponse).FullName);

            List<Objective> objectiveNames = response.Objectives.ToList();

            Assert.IsNotNull(objectiveNames);
            Assert.IsNotEmpty(objectiveNames);

            foreach (var objectiveName in objectiveNames)
            {
                Assert.IsNotNull(objectiveName);
                Assert.IsEmpty(objectiveName.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Objective).FullName);
            }

            Trace.WriteLine(string.Format("Number of objectives: {0}", objectiveNames.Count));
        }

        [Test]
        public async void GetObjectiveNamesAsync()
        {
            ObjectiveNamesRequest request = new ObjectiveNamesRequest();

            ObjectiveNamesResponse response = (await request.GetResponseAsync(this.client)).DeserializeResponse();
            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ObjectiveNamesResponse).FullName);

            List<Objective> objectiveNames = response.Objectives.ToList();

            Assert.IsNotNull(objectiveNames);
            Assert.IsNotEmpty(objectiveNames);

            foreach (var objectiveName in objectiveNames)
            {
                Assert.IsNotNull(objectiveName);
                Assert.IsEmpty(objectiveName.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Objective).FullName);
            }

            Trace.WriteLine(string.Format("Number of objectives: {0}", objectiveNames.Count));
        }

        [Test]
        public void GetObjectiveNamesGerman()
        {
            ObjectiveNamesRequest request = new ObjectiveNamesRequest(SupportedLanguages.German);

            ObjectiveNamesResponse response = request.GetResponse(this.client).DeserializeResponse();
            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ObjectiveNamesResponse).FullName);

            List<Objective> objectiveNames = response.Objectives.ToList();

            Assert.IsNotNull(objectiveNames);
            Assert.IsNotEmpty(objectiveNames);

            foreach (var objectiveName in objectiveNames)
            {
                Assert.IsNotNull(objectiveName);
                Assert.IsEmpty(objectiveName.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Objective).FullName);
            }

            Trace.WriteLine(string.Format("Number of objectives: {0}", objectiveNames.Count));
        }

        [Test]
        public void GetObjectiveNamesFrench()
        {
            ObjectiveNamesRequest request = new ObjectiveNamesRequest(SupportedLanguages.French);

            ObjectiveNamesResponse response = request.GetResponse(this.client).DeserializeResponse();
            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ObjectiveNamesResponse).FullName);

            List<Objective> objectiveNames = response.Objectives.ToList();

            Assert.IsNotNull(objectiveNames);
            Assert.IsNotEmpty(objectiveNames);

            foreach (var objectiveName in objectiveNames)
            {
                Assert.IsNotNull(objectiveName);
                Assert.IsEmpty(objectiveName.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Objective).FullName);
            }

            Trace.WriteLine(string.Format("Number of objectives: {0}", objectiveNames.Count));
        }

        [Test]
        public void GetObjectiveNamesSpanish()
        {
            ObjectiveNamesRequest request = new ObjectiveNamesRequest(SupportedLanguages.Spanish);

            ObjectiveNamesResponse response = request.GetResponse(this.client).DeserializeResponse();
            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ObjectiveNamesResponse).FullName);

            List<Objective> objectiveNames = response.Objectives.ToList();

            Assert.IsNotNull(objectiveNames);
            Assert.IsNotEmpty(objectiveNames);

            foreach (var objectiveName in objectiveNames)
            {
                Assert.IsNotNull(objectiveName);
                Assert.IsEmpty(objectiveName.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Objective).FullName);
            }

            Trace.WriteLine(string.Format("Number of objectives: {0}", objectiveNames.Count));
        }
    }
}
