// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WorldTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;

using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.WorldsInformation.Names;
using GW2DotNET.V1.RestSharp;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    public class WorldTests
    {
        private IServiceClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ServiceClient.Create(new Version(1, 0));
        }

        [Test]
        public void GetWorldNames()
        {
            var request  = new WorldNamesRequest();
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var worldNames = response.Deserialize();

            Assert.IsNotNull(worldNames);
            Assert.IsEmpty(worldNames.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(WorldNames).FullName);

            foreach (var worldName in worldNames)
            {
                Assert.IsEmpty(worldName.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(WorldName).FullName);
            }

            Trace.WriteLine(string.Format("Number of worlds: {0}", worldNames.Count));
        }

    }
}
