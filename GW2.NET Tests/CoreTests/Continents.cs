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
    public class Continents
    {
        [Test]
        public void GetContinents()
        {
            ContinentsRequest request = new ContinentsRequest();

            ContinentsResponse response = request.GetResponse(ApiClient.Create()).DeserializeResponse();

            IDictionary<int, Continent> continents = response.Continents;

            Assert.IsNotNull(continents);
            Assert.IsNotEmpty(continents);

            Trace.WriteLine(string.Format("Number of continents: {0}", continents.Count));
        }

        [Test]
        public async void GetContinentsAsync()
        {
            ContinentsRequest request = new ContinentsRequest();

            ContinentsResponse response = (await request.GetResponseAsync(ApiClient.Create())).DeserializeResponse();

            IDictionary<int, Continent> continents = response.Continents;

            Assert.IsNotNull(continents);
            Assert.IsNotEmpty(continents);

            Trace.WriteLine(string.Format("Number of continents: {0}", continents.Count));
        }
    }
}
