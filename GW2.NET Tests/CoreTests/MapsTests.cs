// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapsTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapsTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;

using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.MapsInformation;
using GW2DotNET.V1.Core.MapsInformation.Continents;
using GW2DotNET.V1.Core.MapsInformation.Details;
using GW2DotNET.V1.Core.MapsInformation.Floors;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregion;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregion.Locations;
using GW2DotNET.V1.Core.MapsInformation.Names;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    public class MapsTests
    {
        private IApiClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ApiClient.Create(new Version(1, 0));
        }

        [Test]
        public void GetMapNames()
        {
            var request  = new MapNamesRequest();
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var mapNames = response.Deserialize();

            Assert.IsNotNull(mapNames);
            Assert.IsNotEmpty(mapNames);
            Assert.IsEmpty(mapNames.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MapNames).FullName);

            foreach (var mapName in mapNames)
            {
                Assert.IsEmpty(mapName.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MapName).FullName);
            }

            Trace.WriteLine(string.Format("Number of maps: {0}", mapNames.Count));
        }

        [Test]
        public void GetMapDetails()
        {
            var request  = new MapDetailsRequest();
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var mapsDetailsResult = response.Deserialize();

            Assert.IsNotNull(mapsDetailsResult);
            Assert.IsEmpty(mapsDetailsResult.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MapsDetailsResult).FullName);

            var mapsDetails = mapsDetailsResult.Maps;

            Assert.IsNotEmpty(mapsDetails);
            Assert.IsEmpty(mapsDetailsResult.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MapsDetails).FullName);

            foreach (var mapDetails in mapsDetails)
            {
                Assert.IsEmpty(mapDetails.Value.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MapName).FullName);
            }

            Trace.WriteLine(string.Format("Number of maps: {0}", mapsDetails.Count));
        }

        [Test]
        public void GetMapFloor()
        {
            var continentId = 1;
            var floorId     = 1;
            var request     = new MapFloorRequest(continentId, floorId);
            var response    = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var mapFloor = response.Deserialize();

            Assert.IsNotNull(mapFloor);
            Assert.IsEmpty(mapFloor.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MapFloor).FullName);

            var mapRegions = mapFloor.MapRegions;

            Assert.IsNotEmpty(mapRegions);
            Assert.IsEmpty(mapRegions.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MapRegions).FullName);

            Trace.WriteLine(string.Format("Number of map regions on floor '{0}': {1}\n", floorId, mapRegions.Count));
            foreach (var mapRegion in mapRegions.Values)
            {
                Assert.IsEmpty(mapRegion.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MapRegion).FullName);

                Assert.IsEmpty(mapRegion.Maps.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Maps).FullName);

                Trace.WriteLine(string.Format("Number of maps in region '{0}': {1}\n", mapRegion.Name, mapRegion.Maps.Count));
                foreach (var map in mapRegion.Maps.Values)
                {
                    Trace.WriteLine(map.Name);
                    Assert.IsEmpty(map.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Map).FullName);

                    Assert.IsEmpty(map.PointsOfInterest.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(PointsOfInterest).FullName);

                    Trace.WriteLine(string.Format("{0}x POI", map.PointsOfInterest.Count));
                    foreach (var pointOfInterest in map.PointsOfInterest)
                    {
                        Assert.IsEmpty(pointOfInterest.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(PointOfInterest).FullName);
                    }

                    Assert.IsEmpty(map.Tasks.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(RenownTasks).FullName);

                    Trace.WriteLine(string.Format("{0}x Renown heart", map.Tasks.Count));
                    foreach (var renownTask in map.Tasks)
                    {
                        Assert.IsEmpty(renownTask.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(RenownTask).FullName);
                    }

                    Assert.IsEmpty(map.SkillChallenges.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(SkillChallenges).FullName);

                    Trace.WriteLine(string.Format("{0}x Skill challenge", map.SkillChallenges.Count));
                    foreach (var skillChallenge in map.SkillChallenges)
                    {
                        Assert.IsEmpty(skillChallenge.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(SkillChallenge).FullName);
                    }

                    Assert.IsEmpty(map.Sectors.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Sectors).FullName);

                    Trace.WriteLine(string.Format("{0}x Sector\n", map.Sectors.Count));
                    foreach (var sector in map.Sectors)
                    {
                        Assert.IsEmpty(sector.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Sector).FullName);
                    }
                }
            }
        }

        [Test]
        public void GetContinents()
        {
            var request  = new MapContinentsRequest();
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var continentsResult = response.Deserialize();

            Assert.IsNotNull(continentsResult.Continents);
            Assert.IsNotEmpty(continentsResult.Continents);
            Assert.IsEmpty(continentsResult.Continents.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MapContinentsResult).FullName);

            foreach (var pair in continentsResult.Continents)
            {
                Assert.IsEmpty(pair.Value.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(MapContinent).FullName);
            }

            Trace.WriteLine(string.Format("Number of continents: {0}", continentsResult.Continents.Count));
        }
    }
}
