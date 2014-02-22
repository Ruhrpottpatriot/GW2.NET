// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Continents.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Continents type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.Continents;
using GW2DotNET.V1.Core.Continents.Models;

using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    public class ContinentsTest
    {
        [Test]
        public void GetContinents()
        {
            ContinentsRequest request = new ContinentsRequest();

            ContinentsResponse response = request.GetResponse(ApiClient.Create()).Deserialize();

            IDictionary<int, Continent> continents = response.Continents;

            Assert.IsNotNull(continents);
            Assert.IsNotEmpty(continents);

            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ContinentsResponse).FullName);

            foreach (var pair in continents)
            {
                Assert.IsEmpty(pair.Value.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Continent).FullName);
            }

            Trace.WriteLine(string.Format("Number of continents: {0}", continents.Count));
        }

        [Test]
        public async void GetContinentsAsync()
        {
            ContinentsRequest request = new ContinentsRequest();

            ContinentsResponse response = (await request.GetResponseAsync(ApiClient.Create())).Deserialize();

            IDictionary<int, Continent> continents = response.Continents;

            Assert.IsNotNull(continents);
            Assert.IsNotEmpty(continents);

            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ContinentsResponse).FullName);

            foreach (var pair in continents)
            {
                Assert.IsEmpty(pair.Value.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Continent).FullName);
            }

            Trace.WriteLine(string.Format("Number of continents: {0}", continents.Count));
        }
    }
}
