// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentsTest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContinentsTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.ContinentsInformation;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    public class ContinentsTest
    {
        private IApiClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ApiClient.Create();
        }

        [Test]
        public void GetContinents()
        {
            var request  = new ContinentsRequest();
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var continentsResult = response.Deserialize();

            Assert.IsNotNull(continentsResult.Continents);
            Assert.IsNotEmpty(continentsResult.Continents);
            Assert.IsEmpty(continentsResult.Continents.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ContinentsResult).FullName);

            foreach (var pair in continentsResult.Continents)
            {
                Assert.IsEmpty(pair.Value.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Continent).FullName);
            }

            Trace.WriteLine(string.Format("Number of continents: {0}", continentsResult.Continents.Count));
        }

        [Test]
        public async void GetContinentsAsync()
        {
            var request  = new ContinentsRequest();
            var response = await request.GetResponseAsync(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var continentsResult = response.Deserialize();

            Assert.IsNotNull(continentsResult.Continents);
            Assert.IsNotEmpty(continentsResult.Continents);
            Assert.IsEmpty(continentsResult.Continents.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ContinentsResult).FullName);

            foreach (var pair in continentsResult.Continents)
            {
                Assert.IsEmpty(pair.Value.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Continent).FullName);
            }

            Trace.WriteLine(string.Format("Number of continents: {0}", continentsResult.Continents.Count));
        }
    }
}
